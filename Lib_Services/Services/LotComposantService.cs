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
    /// Service métier responsable des opérations CRUD sur l'entité <see cref="LotComposant"/>.
    /// </summary>
    public class LotComposantService : ILotComposantService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="LotComposantService"/>.
        /// </summary>
        /// <param name="context">Contexte de données utilisé pour les opérations persistées.</param>
        public LotComposantService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retourne la liste complète des lots composants présents en base.
        /// Exécute immédiatement la requête via <c>ToList()</c>.
        /// </summary>
        /// <returns>Liste d'objets <see cref="LotComposant"/>.</returns>
        public List<LotComposant> Lister()
        {
            return _context.LotComposants.ToList();
        }

        /// <summary>
        /// Récupère un lotcomposant par son numero.
        /// </summary>
        /// <param name="numero">numero du lotcomposant cherché.</param>
        /// <returns>L'entité <see cref="LotComposant"/> si trouvée, sinon null.</returns>
        public LotComposant? Obtenir(int numero)
        {
            return _context.LotComposants
                           .FirstOrDefault(o => o.Numero == numero);
        }

        /// <summary>
        /// Crée un nouvel lotcomposant en base
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="LotComposant"/> à créer.</param>
        public void Creer(LotComposant lotComposant)
        {
            // Ajout de l'entité au contexte puis persistance immédiate.
            _context.LotComposants.Add(lotComposant);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un lotcomposant existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="LotComposant"/>.</param>
        public void Modifier(LotComposant lotComposant)
        {
            _context.LotComposants.Update(lotComposant);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un lotcomposant identifié par son login s'il existe.
        /// </summary>
        /// <param name="numero">numero du lotcomposant à supprimer.</param>
        public void Supprimer(int numero)
        {
            // Recherche de l'entité (utilise le cache si possible).
            var lotComposant = _context.LotComposants.Find(numero);
            if (lotComposant != null)
            {
                _context.LotComposants.Remove(lotComposant);
                _context.SaveChanges();
            }
        }
    }
}
