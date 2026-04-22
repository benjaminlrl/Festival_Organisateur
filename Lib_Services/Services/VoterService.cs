using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Services
{
    public class VoterService : IVoterService
    {
        private readonly ApplicationDbContext _context;
        private readonly int nbVotesMax;

        /// <summary>
        /// Constructeur avec injection du contexte de données.
        /// </summary>
        /// <param name="context">Contexte EF <see cref="ApplicationDbContext"/>.</param>
        public VoterService(ApplicationDbContext context)
        {
            _context = context;
            nbVotesMax = ConstanteService.Voter.NbMaxVotes;
        }

        /// <summary>
        /// Retourne tous les Votes présents dans la base de données.
        /// Si un filtre est fourni, retourne uniquement 
        /// les Votes dont le contenu correspond au filtre.
        /// </summary>
        /// <param name="filtre">Optionnel : contenu à filtrer.</param>
        /// <returns>Liste de <see cref="Voter"/>.</returns>
        public List<Voter> Lister(string filtre = "")
        {
            // Utilise le DbSet Votes pour matérialiser la collection en mémoire.
            return _context.Voter
                .Include(v => v.Plateforme)
                .Include(v => v.Jeu)
                .Where(v => v.DateVote.ToString().Contains(filtre))
                .ToList();
        }

        /// <summary>
        /// Pour un utilisateur donné par son id, retourne uniquement
        /// les Votes présents dans la base de données.
        /// </summary>
        /// <param name="idUser">Id unique de l'utilisateur</param>
        /// <param name="filtre">Filtre de la recherche<param>
        /// <returns>Liste de <see cref="Voter"/>.</returns>
        public List<Voter> ListerPourUnUtilisateur(int idUser, string filtre = "")
        {
            return _context.Voter
                .Include(v => v.Plateforme)
                .Include(v => v.Jeu)
                .Where(v => v.IdUser == idUser
                    && (v.Plateforme.Libelle.Contains(filtre) 
                        || v.Jeu.Titre.Contains(filtre) 
                        || v.DateVote.ToString().Contains(filtre)))
                .ToList();

        }

        /// <summary>
        /// Récupère un Vote identifié par l'id de l'utilisateur, 
        /// l'id du jeu et l'id de la plateforme, 
        /// puis persiste la modification.
        /// </summary>
        /// <param name="idUser">Id de l'utilisateur</param>
        /// <param name="idJeu">Id du jeu voté</param>
        /// <param name="idPlateforme">Id de la plateforme associé au jeu</param>
        /// <returns>L'objet <see cref="Voter"/> ou null si aucun vote n'est trouvé.</returns>
        public Voter? Obtenir(int idJeu, int idPlateforme, int idUser)
        {
            // Find retourne null si l'entité n'existe pas.
            return _context.Voter.Find(idJeu, idPlateforme, idUser);
        }

        /// <summary>
        /// Crée un nouveau Vote et persiste la modification.
        /// </summary>
        /// <param name="Vote">Objet <see cref="Voter"/> à ajouter.</param>
        public void Creer(Voter vote)
        {
            _context.Voter.Add(vote);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un Vote existant et persiste la modification.
        /// </summary>
        /// <param name="Vote">Objet <see cref="Voter"/> contenant les valeurs mises à jour.</param>
        public void Modifier(Voter vote)
        {
            // Marque l'entité comme modifiée puis sauvegarde.
            _context.Voter.Update(vote);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un Vote identifié par l'id de l'utilisateur, 
        /// l'id du jeu et l'id de la plateforme, 
        /// puis persiste la modification.
        /// </summary>
        /// <param name="idUser">Id de l'utilisateur</param>
        /// <param name="idJeu">Id du jeu voté</param>
        /// <param name="idPlateforme">Id de la plateforme associé au jeu</param>
        public void Supprimer(int idJeu, int idPlateforme, int idUser)
        {
            // Récupération de l'entité ; vérification de nullité avant suppression.
            var vote = _context.Voter.Find(idJeu, idPlateforme, idUser);
            if (vote != null)
            {
                _context.Voter.Remove(vote);
                // Suppression en cascade des postes de jeu associés à la Vote. 
                // Puisqu'un poste de jeu a obligatoirmeent une Vote.
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Permet de vérifier les propriétés associés a une Vote.
        /// </summary>
        /// <param name="vote">La Vote à valider</param>
        /// <returns>La liste contenant toutes les erreurs</returns>
        public List<string> ValiderVote(Voter vote)
        {
            // liste des erreurs
            var erreurs = new List<string>();

            if (vote.IdUser <= 0)
                erreurs.Add("L'identifiant de l'utilisateur doit être supérieur à zéro.");

            // L'utilisateur ne peut pas voter plus de NB_VOTES_MAX fois pour un même jeu sur une même plateforme.
            if (_context.Voter.Count(v => v.IdUser == vote.IdUser) >= nbVotesMax)
                erreurs.Add($"Vous ne pouvez pas voter plus de {nbVotesMax} fois");

            // Si l'utilisateur a déjà voté pour ce jeu sur cette plateforme, il ne peut pas voter à nouveau.
            if (Obtenir(vote.IdJeu, vote.IdPlateforme, vote.IdUser) != null)
                erreurs.Add($"Vous avez déjà voter pour ce mot !");

            return erreurs;
        }

    }
}
