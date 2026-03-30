using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Lib_Services.Services
{
    /// <summary>
    /// Service métier responsable des opérations CRUD sur l'entité <see cref="Organisateur"/>.
    /// </summary>

    /// Administrateur :
    /// • CRUD → toutes les tables
    ///
    /// Gestionnaire du stock :
    /// • CRUD : Lot, LotComposant,
    /// • Consultation : Tournoi, Jeu, Espace, PosteJeu, Plateforme
    ///
    /// Gestionnaire de l’espace :
    /// • CRUD : Espace, PosteJeu, Tournoi
    /// • Consultation : Plateforme, Jeu, Participer
    ///
    /// Gestionnaire des tournois :
    /// • CRUD : Tournoi, Participer, SoumisVote
    /// • Consultation : Espace , PosteJeu, Plateforme, Jeu, Lot, Voter
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="RoleService"/>.
        /// </summary>
        /// <param name="context">Contexte de données utilisé pour les opérations persistées.</param>
        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retourne tout les roles présents dans la base de données.
        /// Si un filtre est fourni, retourne uniquement 
        /// les roles dont le libellé correspond au filtre.
        /// </summary>
        /// <param name="filtre">Optionnel : libellé à filtrer.</param>
        /// <returns>Liste de <see cref="Role"/>.</returns>
        public List<Role> Lister(string filtre = "")
        {
            // Utilise le DbSet Plateformes pour matérialiser la collection en mémoire.
            if (string.IsNullOrWhiteSpace(filtre))
                return _context.Roles
                     .Include(r => r.Organisateurs)
                     .ToList();
            return
                _context.Roles
                .Include(r => r.Organisateurs)
                .Where(r => r.Libelle.Contains(filtre))
                .ToList();
        }

        /// <summary>
        /// Récupère un role par son libelle.
        /// </summary>
        /// <param name="Libelle">Le libelle du rôle cherché.</param>
        /// <returns>L'entité <see cref="Role"/> si trouvée, sinon null.</returns>
        public Role? Obtenir(string Libelle)
        {
            return _context.Roles
                           .AsNoTracking()  // ← ajout
                           .FirstOrDefault(r => r.Libelle == Libelle);
        }

        /// <summary>
        /// Crée un nouveau role en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="role">Instance de <see cref="Role"/> à créer.</param>
        public void Creer(Role role)
        {
            // Ajout de l'entité au contexte puis persistance immédiate.
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un role existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Role"/>.</param>
        public void Modifier(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un role
        /// </summary>
        /// <param name="role">Instance modifiée de <see cref="Role"/>.</param>
        public void Supprimer(Role role)
        {
            // Recherche de l'entité (utilise le cache si possible).
            var roleChercher = _context.Roles.Find(role);
            if (roleChercher != null)
                _context.Roles.Remove(roleChercher);
                _context.SaveChanges();
        }


    }

}
