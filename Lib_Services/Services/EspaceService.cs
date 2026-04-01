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
                .Include(e => e.Tournois)
                .ToList();
            return
                _context.Espaces
                .Include(e => e.PostesJeu)
                .Include(e => e.Tournois)
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
            return _context.Espaces.Find(idEspace);
        }

        /// <summary>
        /// Crée un nouvel espace en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Espace"/> à créer.</param>
        public void Creer(Espace espace)
        {
            // Ajout de l'entité au contexte puis persistance immédiate.
            _context.Espaces.Add(espace);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un espace existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Espace"/>.</param>
        public void Modifier(Espace espace)
        {
            _context.Espaces.Update(espace);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un espace identifié par son identifiant s'il existe.
        /// </summary>
        /// <param name="idEspace">Identifiant de l'espace à supprimer.</param>
        public void Supprimer(int idEspace)
        {
            // Recherche de l'entité (utilise le cache si possible).
            var espace = _context.Espaces.Find(idEspace);
            if (espace != null)
            {
                _context.Espaces.Remove(espace);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Permet de vérifier les propriétés associés a un espace.
        /// </summary>
        /// <param name="espace">L'esapce à valider</param>
        /// <returns>La liste contenant toutes les erreurs</returns>
        public List<string> ValiderEspace(Espace espace)
        {
            // liste des erreurs
            var erreurs = new List<string>();

            if (string.IsNullOrWhiteSpace(espace.Nom))
                erreurs.Add("Le nom est requis.");

            if (string.IsNullOrWhiteSpace(espace.Description))
                erreurs.Add("La description est requise.");

            if (espace.Superficie < 9)
                erreurs.Add("La superficie ne peut pas être inférieur à 9.");

            if (espace.Superficie > 60)
                erreurs.Add("La superficie ne peut pas être supérieur à 60.");

            if (espace.CapaciteMaxi < 0)
                erreurs.Add("La capacité maximale doit être positive.");

            if (espace.CapaciteMaxi > 50)
                erreurs.Add("La superficie ne peut pas être supérieur à 50.");

            return erreurs;
        }
    }

}
