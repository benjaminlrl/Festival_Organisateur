using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Services
{
    public class SoumisVoteService : ISoumisVoteService
    {
        private readonly ApplicationDbContext _context;
        private IJeuService _jeuService;
        private IPlateformeService _plateformeService;

        /// <summary>
        /// Constructeur avec injection du contexte de données.
        /// </summary>
        /// <param name="context">Contexte EF <see cref="ApplicationDbContext"/>.</param>
        public SoumisVoteService(ApplicationDbContext context)
        {
            _context = context;
            _jeuService = new JeuService(context);
            _plateformeService = new PlateformeService(context);
        }

        /// <summary>
        /// Retourne tous les SoumisVotes présents dans la base de données.
        /// Si un filtre est fourni, retourne uniquement 
        /// les SoumisVotes dont le contenu correspond au filtre.
        /// </summary>
        /// <param name="filtre">Optionnel : contenu à filtrer.</param>
        /// <returns>Liste de <see cref="SoumisVote"/>.</returns>
        public List<SoumisVote> Lister(string filtre = "")
        {
            // Utilise le DbSet SoumisVotes pour matérialiser la collection en mémoire.
            if (string.IsNullOrWhiteSpace(filtre))
                return _context.SoumisVotes
                     .Include(v => v.Plateforme)
                     .Include(v => v.Jeu)
                     .ToList();
            return
                _context.SoumisVotes
                .Include(v => v.Plateforme)
                .Include(v => v.Jeu)
                .Where(v => v.DateDebutVote.ToString().Contains(filtre)
                        || v.DateFinVote.ToString().Contains(filtre)
                        || v.Plateforme.Libelle.Contains(filtre)
                        || v.Jeu.Titre.Contains(filtre))
                .ToList();
        }

        /// <summary>
        /// Modifie un SoumisVote identifié par l'id de l'utilisateur, 
        /// l'id du jeu et l'id de la plateforme, 
        /// puis persiste la modification.
        /// </summary>
        /// <param name="idJeu">Id du jeu voté</param>
        /// <param name="idPlateforme">Id de la plateforme associé au jeu</param>
        /// <returns></returns>
        public SoumisVote? Obtenir(int idJeu, int idPlateforme)
        {
            // Find retourne null si l'entité n'existe pas.
            return _context.SoumisVotes.Find(idJeu, idPlateforme);
        }

        /// <summary>
        /// Crée un nouveau SoumisVote et persiste la modification.
        /// </summary>
        /// <param name="soumisVote">Objet <see cref="SoumisVote"/> à ajouter.</param>
        public void Creer(SoumisVote soumisVote)
        {
            if (Obtenir(soumisVote.IdJeu, soumisVote.IdPlateforme) != null)
                return;
            _context.SoumisVotes.Add(soumisVote);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un SoumisVote existant et persiste la modification.
        /// </summary>
        /// <param name="soumisVote">Objet <see cref="SoumisVote"/> contenant les valeurs mises à jour.</param>
        public void Modifier(SoumisVote soumisVote)
        {
            // Marque l'entité comme modifiée puis sauvegarde.
            _context.SoumisVotes.Update(soumisVote);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un SoumisVote identifié par l'id de l'utilisateur, 
        /// l'id du jeu et l'id de la plateforme, 
        /// puis persiste la modification.
        /// </summary>
        /// <param name="idJeu">Id du jeu voté</param>
        /// <param name="idPlateforme">Id de la plateforme associé au jeu</param>
        public void Supprimer(int idJeu, int idPlateforme)
        {
            // Récupération de l'entité ; vérification de nullité avant suppression.
            var soumisVote = _context.SoumisVotes.Find(idJeu, idPlateforme);
            if (soumisVote != null)
            {
                _context.SoumisVotes.Remove(soumisVote);
                // Suppression en cascade des postes de jeu associés à la SoumisVote. 
                // Puisqu'un poste de jeu a obligatoirmeent une SoumisVote.
                _context.SaveChanges();
            }
        }
        #region Statistiques de vote
        /// <summary>
        /// Permet d'obtenir le taux de vote (%) pour un jeu passé en paramètre,
        /// </summary>
        /// <param name="idJeu">Id unique du jeu</param>
        /// <returns></returns>
        public double CalculerTauxVoteJeu(int idJeu, DateTime dateDebut, DateTime dateFin)
        {
            int totalVotes = _context.Voter.Count(v => v.DateVote >= dateDebut && v.DateVote <= dateFin);
            if (totalVotes == 0) return 0;

            // Compte le nombre de votes associés au jeu
            int votesJeu = _context.Voter.Count(v => v.IdJeu == idJeu);

            return votesJeu / totalVotes * 100;
        }

        public int ObtenirVotesJeu(int idJeu,SoumisVote soumisVote)
        {
            int totalVotes = _context.Voter.Count(v => v.DateVote >= soumisVote.DateDebutVote 
                && v.DateVote <= soumisVote.DateFinVote);
            if (totalVotes == 0) return 0;

            // Compte le nombre de votes associés au jeu
            int votesJeu = _context.Voter.Count(v => v.IdJeu == idJeu);

            return votesJeu / totalVotes * 100;
        }

        /// <summary>
        /// Permet d'obtenir le taux de vote (%) pour un jeu et sa plateformepassé en paramètre,
        /// </summary>
        /// <param name="idJeu">Id unique du jeu</param>
        /// <param name="idPlateforme">Id unique de la plateforme associé au jeu</param>
        /// <returns></returns>
        public double CalculerTauxVoteJeuPlateforme(int idJeu, int idPlateforme)
        {
            int totalVotes = _context.Voter.Count();
            if (totalVotes == 0) return 0;

            // Compte le nombre de votes associés au jeu et à la plateforme
            int votesJeu = _context.Voter.Count(v => v.IdJeu == idJeu && v.IdPlateforme == idPlateforme);

            return votesJeu / totalVotes * 100;
        }

        /// <summary>
        /// Retourne le classement des binomes (jeu, plateforme) les plus votés
        /// </summary>
        /// <param name="soumisVote"></param>
        /// <returns>Le classement des binomes</returns>
        public List<Voter> ListerClassmentJeuxVotes()
        {
            return _context.Voter
                .Include(v => v.Jeu)
                .Include(v => v.Plateforme)
                .AsEnumerable() // Charge tout en mémoire pour que Include fonctionne avec GroupBy
                .GroupBy(v => new { v.IdJeu, v.IdPlateforme }) // Groupe par binôme (jeu, plateforme)
                .Select(g => new Voter
                {
                    IdJeu = g.Key.IdJeu,
                    IdPlateforme = g.Key.IdPlateforme,
                    Jeu = g.First().Jeu,           // Récupère l'objet Jeu depuis le 1er élément du groupe
                    Plateforme = g.First().Plateforme, // Récupère l'objet Plateforme depuis le 1er élément du groupe
                    NbVotes = g.Count()            // Compte le nombre de votes pour ce binôme
                })
                .OrderByDescending(v => v.NbVotes) // Trie du plus populaire au moins populaire
                .ToList();
        }

        #endregion
        #region Validations
        /// <summary>
        /// Permet de vérifier les propriétés associés a une SoumisVote.
        /// </summary>
        /// <param name="soumisVote">Le SoumisVote à valider</param>
        /// <returns>La liste contenant toutes les erreurs</returns>
        public List<string> ValiderSoumisVote(SoumisVote soumisVote)
        {
            // liste des erreurs
            var erreurs = new List<string>();

            if (_jeuService.Obtenir(soumisVote.IdJeu) == null)
                erreurs.Add("Le jeu associé n'existe pas.");

            if (_plateformeService.Obtenir(soumisVote.IdPlateforme) == null)
                erreurs.Add("La plateforme associée n'existe pas.");

            if (Obtenir(soumisVote.IdJeu, soumisVote.IdPlateforme) != null)
                erreurs.Add("Une autre SoumisVote existe déjà.");

            // Contrôles des dates
            if (soumisVote.DateDebutVote >= soumisVote.DateFinVote)
                erreurs.Add("La date de début doit être antérieure à la date de fin.");

            // Vérifier que les dates ne sont pas dans le passé
            if (soumisVote.DateDebutVote.Day < DateTime.Now.Day)
                erreurs.Add("La date de début doit être dans le futur.");

            if (soumisVote.DateFinVote.Day < DateTime.Now.Day)
                erreurs.Add("La date de fin doit être dans le futur.");

            return erreurs;
        }
        #endregion
    }
}
