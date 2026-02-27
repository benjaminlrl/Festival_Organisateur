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
    public class OrganisateurService : IOrganisateurService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="OrganisateurService"/>.
        /// </summary>
        /// <param name="context">Contexte de données utilisé pour les opérations persistées.</param>
        public OrganisateurService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retourne la liste complète des organisateur présents en base.
        /// Exécute immédiatement la requête via <c>ToList()</c>.
        /// </summary>
        /// <returns>Liste d'objets <see cref="Organisateur"/>.</returns>
        public List<Organisateur> Lister()
        {
            // Include(e => e.Espace) pour éviter le chargement paresseux lors de l'affichage.
            return _context.Organisateur
                           .Include(t => t.Role)
                           .ToList();
        }

        /// <summary>
        /// Récupère un organisateur par son login.
        /// </summary>
        /// <param name="Login">Login de l'organisateur cherché.</param>
        /// <returns>L'entité <see cref="Organisateur"/> si trouvée, sinon null.</returns>
        public Organisateur? Obtenir(string Login)
        {
            // Find utilise le cache du contexte s'il existe, sinon interroge la base.
            return _context.Organisateur.Find(Login);
        }

        /// <summary>
        /// Crée un nouvel organisateur en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Organisateur"/> à créer.</param>
        public void Creer(Organisateur organisateur)
        {
            // Regarde si le login n'existe pas déjà
            if(Obtenir(organisateur.Login) != null)
                throw new InvalidOperationException("Ce login est déjà pris.");
            // Ajout de l'entité au contexte puis persistance immédiate.
            organisateur.motPasse = BCrypt.Net.BCrypt.HashPassword(organisateur.motPasse);
            _context.Organisateur.Add(organisateur);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un organisateur existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Organisateur"/>.</param>
        public void Modifier(Organisateur organisateur)
        {
            _context.Organisateur.Update(organisateur);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un organisateur identifié par son login s'il existe.
        /// </summary>
        /// <param name="Login">Login de l'organisateur à supprimer.</param>
        public void Supprimer(string Login)
        {
            // Recherche de l'entité (utilise le cache si possible).
            var organisateur = _context.Organisateur.Find(Login);
            if (organisateur != null)
                _context.Organisateur.Remove(organisateur);
                _context.SaveChanges();
        }

        /// <summary>
        /// Vérifie si les informations d'identification fournies correspondent à un organisateur existant.
        /// </summary>
        /// <param name="motDePasse">Le mot de passe hashé de l'organisateur.</param>
        /// <param name="identifiant">Le login de l'organisateur.</param>
        /// <returns>True si il est identique, false si non</returns>
        public bool EstIdentique(string motDePasse, string identifiant)
        {
            var organisateur = _context.Organisateur.Find(identifiant);
            if (organisateur == null)
                return false;
            return BCrypt.Net.BCrypt.Verify(motDePasse, organisateur.motPasse);
        }
    }

}
