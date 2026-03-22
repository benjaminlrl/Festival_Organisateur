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
    /// Service métier responsable des opérations CRUD sur l'entité <see cref="Espace"/>.
    /// </summary>
    public class EspaceService : IEspaceService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="EspaceService"/>.
        /// </summary>
        /// <param name="context">Contexte de données utilisé pour les opérations persistées.</param>
        public EspaceService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retourne la liste complète des espaces présents en base.
        /// Charge également les postes de jeu associés à chaque espace.
        /// Si un filtre est fourni, retourne les espaces 
        /// dont le nom ou la description correspond au filtre.
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <returns>Liste d'objets <see cref="Espace"/>.</returns>
        public List<Espace> Lister(string filtre = "")
        {
            // ToList force l'exécution de la requête et charge les entités en mémoire.
            if (string.IsNullOrWhiteSpace(filtre))
                return _context.Espaces
                .Include(e => e.PostesJeu)
                .ToList();
            return
                _context.Espaces
                .Include(e => e.PostesJeu)
                .Where(e => e.Nom.Contains(filtre)
                    || e.Description.Contains(filtre))
                .ToList();
        }

        /// <summary>
        /// Récupère un espace par son identifiant.
        /// </summary>
        /// <param name="idEspace">Identifiant de l'espace cherché.</param>
        /// <returns>L'entité <see cref="Espace"/> si trouvée, sinon null.</returns>
        public Espace? Obtenir(int idEspace)
        {
            // Find utilise le cache du contexte s'il existe, sinon interroge la base.
            return _context.Espace.Find(idEspace);
        }

        /// <summary>
        /// Crée un nouvel espace en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Espace"/> à créer.</param>
        public void Creer(Espace espace)
        {
            // Ajout de l'entité au contexte puis persistance immédiate.
            _context.Espace.Add(espace);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un espace existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Espace"/>.</param>
        public void Modifier(Espace espace)
        {
            _context.Espace.Update(espace);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un espace identifié par son identifiant s'il existe.
        /// </summary>
        /// <param name="idEspace">Identifiant de l'espace à supprimer.</param>
        public void Supprimer(int idEspace)
        {
            // Recherche de l'entité (utilise le cache si possible).
            var espace = _context.Espace.Find(idEspace);
            if (espace != null)
            {
                _context.Espace.Remove(espace);
                _context.SaveChanges();
            }
        }
    }

}
