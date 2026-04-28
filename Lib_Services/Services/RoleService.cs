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
    /// • CRUD : Tournoi, Participer, JeuSoumisVote
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

        #region Lecture
        /// <summary>
        ///  Retourne la liste complète des roles présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Libelle, IdRole) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Role"/>.</returns>
        public List<Role> Lister(string filtre = "", string propriete = "", string ordre = "")
        {
            IQueryable<Role> query = _context.Roles
                .Include(r => r.Organisateurs);

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(r => r.Libelle.Contains(filtre));

            query = propriete switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "Libelle" => ordre == "ASC" ? query.OrderBy(r => r.Libelle) : query.OrderByDescending(r => r.Libelle),
                "IdRole" => ordre == "ASC" ? query.OrderBy(r => r.IdRole) : query.OrderByDescending(r => r.IdRole),
                _ => query.OrderByDescending(r => r.IdRole) // valeur par défaut
            };

            return query.ToList();
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
        #endregion
        #region CUD
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
        #endregion

    }

}
