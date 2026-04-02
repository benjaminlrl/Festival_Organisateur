using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Services
{
    /// <summary>
    /// Service métier responsable des opérations CRUD sur l'entité <see cref="Participer"/>.
    /// </summary>
    public class ParticiperService : IParticiperService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="ParticiperService"/>.
        /// </summary>
        /// <param name="context">Contexte de données utilisé pour les opérations persistées.</param>
        public ParticiperService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retourne la liste complète des Participer présents en base.
        /// Exécute immédiatement la requête via <c>ToList()</c>.
        /// </summary>
        /// <param name="filtre">Optionnel : libellé à filtrer.</param>
        /// <returns>Liste d'objets <see cref="Participer"/>.</returns>
        public List<Participer> Lister(string filtre = "")
        {
            // Include(t => t.Role) pour éviter le chargement paresseux lors de l'affichage.
            return
                _context.Participer
                .Include(p => p.Tournoi)
                .Include(p => p.Lot)
                .Where(p => p.NumeroTournoi.ToString().Contains(filtre)
                    || p.NumeroTournoi.ToString().Contains(filtre)
                    || p.Rang.ToString().Contains(filtre)
                    || (p.Commentaire ?? "").Contains(filtre)
                    || p.DateHeureInscription.ToString().Contains(filtre)
                    || (p.ScoreFinal.HasValue).ToString().Contains(filtre)
                    || (p.LotRemis.HasValue).ToString().Contains(filtre))
                .ToList();
        }

        /// <summary>
        /// Récupère un Participant par son id et son numéro de tournoi.
        /// </summary>
        /// <param name="Login">Login de l'Participer cherché.</param>
        /// <returns>L'entité <see cref="Participer"/> si trouvée, sinon null.</returns>
        public Participer? Obtenir(int idUser, int numeroTournoi)
        {
            return _context.Participer
                           .Include(p => p.Tournoi)
                           .Include(p => p.Lot)
                           .FirstOrDefault(p => p.IdUser == idUser && p.NumeroTournoi == numeroTournoi);
        }

        /// <summary>
        /// Crée un nouvel Participer en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Participer"/> à créer.</param>
        public void Creer(Participer Participer)
        {
            // Ajout de l'entité au contexte puis persistance immédiate.
            _context.Participer.Add(Participer);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un Participant existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Participer"/>.</param>
        public void Modifier(Participer Participer)
        {
            _context.Participer.Update(Participer);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un Participant identifié par son id et son tournoi associé s'il existe.
        /// </summary>
        /// <param name="idUser">Id unique de l'utilisateur à supprimer.</param>
        /// <param name="numeroTournoi">Numero du tournoi associé à la participation à supprimer.</param>
        public void Supprimer(int idUser, int numeroTournoi)
        {
            // Recherche de l'entité (utilise le cache si possible).
            var Participer = _context.Participer.Find(idUser, numeroTournoi);
            if (Participer != null)
            {
                _context.Participer.Remove(Participer);
                _context.SaveChanges();
            }
        }        
    }

}
