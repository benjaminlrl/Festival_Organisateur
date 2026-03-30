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
    /// Service métier responsable des opérations CRUD sur l'entité <see cref="LotService"/>.
    /// </summary>
    public class LotService : ILotService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="LotService"/>.
        /// </summary>
        /// <param name="context">Contexte de données utilisé pour les opérations persistées.</param>
        public LotService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retourne la liste complète des lots composants présents en base.
        /// Exécute immédiatement la requête via <c>ToList()</c>.
        /// </summary>
        /// <param name="filtre">Optionnel : libellé à filtrer.</param>
        /// <returns>Liste d'objets <see cref="Lot"/>.</returns>
        public List<Lot> Lister(string filtre = "")
        {
            if (string.IsNullOrWhiteSpace(filtre))
                return _context.Lots
                     .ToList();
            return
                _context.Lots
                .Where(r => r.Libelle.Contains(filtre))
                .ToList();
        }

        /// <summary>
        /// Récupère un lot par son numéro
        /// </summary>
        /// <param name="numero">numero du lot cherché.</param>
        /// <returns>L'entité <see cref="Lot"/> si trouvée, sinon null.</returns>
        public Lot? Obtenir(int numero)
        {
            return _context.Lots
                           .FirstOrDefault(o => o.Numero == numero);
        }

        /// <summary>
        /// Crée un nouveau Lot en base
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Lot"/> à créer.</param>
        public void Creer(Lot lot)
        {
            // Ajout de l'entité au contexte puis persistance immédiate.
            _context.Lots.Add(lot);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un Lot existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Lot"/>.</param>
        public void Modifier(Lot lot)
        {
            _context.Lots.Update(lot);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un Lot identifié par son numero s'il existe.
        /// </summary>
        /// <param name="numero">numero du Lot à supprimer.</param>
        public void Supprimer(int numero)
        {
            // Recherche de l'entité (utilise le cache si possible).
            var lot = _context.Lots.Find(numero);
            if (lot != null)
            {
                _context.Lots.Remove(lot);
                _context.SaveChanges();
            }
        }
    }
}
