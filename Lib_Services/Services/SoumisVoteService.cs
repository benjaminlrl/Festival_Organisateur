using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Exceptions;
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
        #region Lecture
        /// <summary>
        ///  Retourne la liste des binomes jeu plateforme présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Libelle, IdRole) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="SoumisVote"/>.</returns>
        public List<SoumisVote> Lister(string filtre = "", string propriete = "", string ordre = "")
        {
            IQueryable<SoumisVote> query = _context.SoumisVotes
                .Include(sv => sv.Plateforme)
                .Include(sv => sv.Jeu);

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(sv => sv.Plateforme.Libelle.Contains(filtre)
                        || sv.Jeu.Titre.Contains(filtre)
                        || sv.DateDebutVote.ToString().Contains(filtre)
                        || sv.DateFinVote.ToString().Contains(filtre));

            query = propriete switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "Libelle" => ordre == "ASC" ? query.OrderBy(sv => sv.Plateforme.Libelle) : query.OrderByDescending(sv => sv.Plateforme.Libelle),
                "Titre" => ordre == "ASC" ? query.OrderBy(sv => sv.Jeu.Titre) : query.OrderByDescending(sv => sv.Jeu.Titre),
                "DateDebutVote" => ordre == "ASC" ? query.OrderBy(sv => sv.DateDebutVote) : query.OrderByDescending(sv => sv.DateDebutVote),
                "DateFinVote" => ordre == "ASC" ? query.OrderBy(sv => sv.DateFinVote) : query.OrderByDescending(sv => sv.DateFinVote),
                _ => query.OrderByDescending(sv => sv.DateDebutVote) // valeur par défaut
            };

            return query.ToList();
        }

        /// <summary>
        ///  Retourne la liste complète des roles présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Libelle, Titre)
        ///  et dans un ordre donné (ASC ou DESC).
        ///  
        /// Permet également de filtrer les résultats sur une période de vote donnée,
        /// 
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <param name="dateDebut">Optionnel, date de début de la période de vote</param>
        /// <param name="dateFin">Optionnel, date de fin de la période de vote</param>
        /// <returns>Liste d'objets <see cref="Voter"/>.</returns>
        public List<Voter> ListerClassmentJeuxVotes(string filtre = "", string propriete = "", string ordre = "", DateTime? dateDebut = null, DateTime? dateFin = null)
        {
            // IEnumerable si on utilise AsEnumerable() pour que le GroupBy soit traité en mémoire
            IEnumerable<Voter> query = _context.Voter
                .Include(v => v.Jeu)
                .Include(v => v.Plateforme)
                .Where(v => !dateDebut.HasValue || v.DateVote >= dateDebut.Value)
                .Where(v => !dateFin.HasValue || v.DateVote <= dateFin.Value)
                .AsEnumerable() // Charge tout en mémoire pour que Include fonctionne avec GroupBy
                .GroupBy(v => new { v.IdJeu, v.IdPlateforme }) // Groupe par binôme (jeu, plateforme)
                .Select(g => new Voter
                {
                    IdJeu = g.Key.IdJeu,
                    IdPlateforme = g.Key.IdPlateforme,
                    Jeu = g.First().Jeu,           // Récupère l'objet Jeu depuis le 1er élément du groupe
                    Plateforme = g.First().Plateforme, // Récupère l'objet Plateforme depuis le 1er élément du groupe
                    NbVotes = g.Count()            // Compte le nombre de votes pour ce binôme
                });

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(v => v.Plateforme.Libelle.Contains(filtre)
                        || v.Jeu.Titre.Contains(filtre));

            query = propriete switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "LibellePlateforme" => ordre == "ASC" ? query.OrderBy(v => v.Plateforme.Libelle) : query.OrderByDescending(v => v.Plateforme.Libelle),
                "TitreJeu" => ordre == "ASC" ? query.OrderBy(v => v.Jeu.Titre) : query.OrderByDescending(v => v.Jeu.Titre),
                "NbVotes" => ordre == "ASC" ? query.OrderBy(v => v.NbVotes) : query.OrderByDescending(v => v.NbVotes),
                _ => query.OrderBy(v => v.Jeu.Titre) // valeur par défaut
            };

            return query.ToList();
        }

        /// <summary>
        /// Retourne un SoumisVote identifié par l'id du jeu et l'id de la plateforme.
        /// AsNoTracking() est utilisé pour éviter les conflits de tracking lors des modifications.
        /// </summary>
        /// <param name="idJeu">Id du jeu voté</param>
        /// <param name="idPlateforme">Id de la plateforme associé au jeu</param>
        /// <returns>Le SoumisVote correspondant ou null s'il n'existe pas</returns>
        public SoumisVote? Obtenir(int idJeu, int idPlateforme)
        {
            // AsNoTracking() force EF Core à aller chercher l'entité directement en base de données
            // et non depuis le cache local (ChangeTracker).
            // Cela garantit que l'on compare les données réelles en BDD avec les données modifiées,
            // et évite les conflits de tracking lors des appels à Valider() puis Modifier().
            return _context.SoumisVotes
                .AsNoTracking()
                .FirstOrDefault(s => s.IdJeu == idJeu && s.IdPlateforme == idPlateforme);
        }

        #endregion
        #region CUD

        /// <summary>
        /// Crée un nouveau SoumisVote et persiste la modification.
        /// </summary>
        /// <param name="soumisVote">Objet <see cref="SoumisVote"/> à ajouter.</param>
        public void Creer(SoumisVote soumisVote)
        {
            ValiderSoumisVote(soumisVote, false);
            _context.SoumisVotes.Add(soumisVote);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un SoumisVote existant et persiste la modification.
        /// </summary>
        /// <param name="soumisVote">Objet <see cref="SoumisVote"/> contenant les valeurs mises à jour.</param>
        public void Modifier(SoumisVote soumisVote)
        {
            ValiderSoumisVote(soumisVote, true);
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
        #endregion
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

        #endregion
        #region Validations
        /// <summary>
        /// Permet de valider les données d'un SoumisVote avant création ou modification.
        /// </summary>
        /// <param name="soumisVote">SoumisVote à valider</param>
        /// <param name="estModification">Indique si c'est une modification ou une création</param>
        /// <exception cref="SoumisVoteException">Exception si les données du SoumisVote sont invalides</exception>
        public void ValiderSoumisVote(SoumisVote soumisVote, bool estModification = false)
        {
            if (_jeuService.Obtenir(soumisVote.IdJeu) == null)
                throw new SoumisVoteException("Le jeu associé n'existe pas.",
                    (int)SoumisVoteException.SoumisVoteErreur.JeuInexistant);

            if (_plateformeService.Obtenir(soumisVote.IdPlateforme) == null)
                throw new SoumisVoteException("La plateforme associée n'existe pas.",
                    (int)SoumisVoteException.SoumisVoteErreur.PlateformeInexistante);

            if (Obtenir(soumisVote.IdJeu, soumisVote.IdPlateforme) != null && !estModification)
                throw new SoumisVoteException("Une autre SoumisVote existe déjà.",
                    (int)SoumisVoteException.SoumisVoteErreur.DoublonSoumisVote);

            if (soumisVote.DateDebutVote.Date >= soumisVote.DateFinVote.Date)
                throw new SoumisVoteException("La date de début doit être antérieure à la date de fin.",
                    (int)SoumisVoteException.SoumisVoteErreur.DateDebutSuperieureFin);

            if (soumisVote.DateDebutVote.Date < DateTime.Now.Date)
                throw new SoumisVoteException("La date de début ne peut pas être dans le passé.",
                    (int)SoumisVoteException.SoumisVoteErreur.DateDebutDansLePasse);

            if (soumisVote.DateFinVote.Date < DateTime.Now.Date)
                throw new SoumisVoteException("La date de fin ne peut pas être dans le passé.",
                    (int)SoumisVoteException.SoumisVoteErreur.DateFinDansLePasse);

            if (estModification)
            {
                SoumisVote? enBdd = Obtenir(soumisVote.IdJeu, soumisVote.IdPlateforme);
                if (enBdd != null && enBdd.DateDebutVote.Date == soumisVote.DateDebutVote.Date
                    && enBdd.DateFinVote.Date == soumisVote.DateFinVote.Date)
                    throw new SoumisVoteException("Aucune modification détectée.",
                        (int)SoumisVoteException.SoumisVoteErreur.AucuneModification);
                
            }
        }
        #endregion
    }
}
