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

        /// <summary>
        /// Constructeur avec injection du contexte de données.
        /// </summary>
        /// <param name="context">Contexte EF <see cref="ApplicationDbContext"/>.</param>
        public VoterService(ApplicationDbContext context)
        {
            _context = context;
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
            if (string.IsNullOrWhiteSpace(filtre))
                return _context.Votes
                     .Include(v => v.Plateforme)
                     .Include(v => v.Jeu)
                     .ToList();
            return
                _context.Votes
                .Include(v => v.Plateforme)
                .Include(v => v.Jeu)
                .Where(v => v.DateVote.ToString().Contains(filtre))
                .ToList();
        }

        /// <summary>
        /// Modifie un Vote identifié par l'id de l'utilisateur, 
        /// l'id du jeu et l'id de la plateforme, 
        /// puis persiste la modification.
        /// </summary>
        /// <param name="idUser">Id de l'utilisateur</param>
        /// <param name="idJeu">Id du jeu voté</param>
        /// <param name="idPlateforme">Id de la plateforme associé au jeu</param>
        /// <returns></returns>
        public Voter? Obtenir(int idUser, int idJeu, int idPlateforme)
        {
            // Find retourne null si l'entité n'existe pas.
            return _context.Votes.Find(new { idUser, idJeu, idPlateforme });
        }

        /// <summary>
        /// Crée un nouveau Vote et persiste la modification.
        /// </summary>
        /// <param name="Vote">Objet <see cref="Voter"/> à ajouter.</param>
        public void Creer(Voter vote)
        {
            _context.Votes.Add(vote);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un Vote existant et persiste la modification.
        /// </summary>
        /// <param name="Vote">Objet <see cref="Voter"/> contenant les valeurs mises à jour.</param>
        public void Modifier(Voter vote)
        {
            // Marque l'entité comme modifiée puis sauvegarde.
            _context.Votes.Update(vote);
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
        public void Supprimer(int idUser, int idJeu, int idPlateforme)
        {
            // Récupération de l'entité ; vérification de nullité avant suppression.
            var vote = _context.Votes.Find(new {idUser, idJeu, idPlateforme });
            if (vote != null)
            {
                _context.Votes.Remove(vote);
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

            //if (string.IsNullOrWhiteSpace(Vote.Libelle))
            //    erreurs.Add("Le libellé est requis.");

            //if (Vote.IdVote <= 0)
            //    erreurs.Add("Une Vote est requise.");

            //if (Lister(Vote.Libelle).Any(v => v.Libelle == Vote.Libelle && p.IdVote != Vote.IdVote))
            //    erreurs.Add("Une autre Vote avec ce libellé existe déjà.");

            return erreurs;
        }

    }
}
