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
    /// Service métier responsable des opérations CRUD sur l'entité <see cref="Organisateur"/>.
    /// </summary>
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
        /// Récupère un role par son libelle.
        /// </summary>
        /// <param name="Libelle">Le libelle du rôle cherché.</param>
        /// <returns>L'entité <see cref="Role"/> si trouvée, sinon null.</returns>
        public Role? Obtenir(string Libelle)
        {
            // Find utilise le cache du contexte s'il existe, sinon interroge la base.
            return _context.Role.FirstOrDefault(r => r.Libelle == Libelle);
        }

        /// <summary>
        /// Crée un nouveau role en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="role">Instance de <see cref="Role"/> à créer.</param>
        public void Creer(Role role)
        {
            // Regarde si le login n'existe pas déjà
            if(Obtenir(role.Libelle) != null)
                throw new InvalidOperationException("Ce nom de rôle est déjà pris");
            // Ajout de l'entité au contexte puis persistance immédiate.
            _context.Role.Add(role);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un role existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Role"/>.</param>
        public void Modifier(Role role)
        {
            _context.Role.Update(role);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un role
        /// </summary>
        /// <param name="role">Instance modifiée de <see cref="Role"/>.</param>
        public void Supprimer(Role role)
        {
            // Recherche de l'entité (utilise le cache si possible).
            var roleChercher = _context.Organisateur.Find(role);
            if (roleChercher != null)
                _context.Organisateur.Remove(roleChercher);
                _context.SaveChanges();
        }

        /// <summary>
        /// Retourne la liste complète des rôles
        /// </summary>
        /// <returns>Liste des tournois.</returns>
        public List<Role> Lister()
        {
            return _context.Role.ToList();
        }
    }

}
