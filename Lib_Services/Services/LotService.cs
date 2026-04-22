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

        #region Lectures

        /// <summary>
        ///  Retourne la liste complète des lots présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Nom, Description, Superficie, CapaciteMaxi) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="property">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Lot"/>.</returns>
        public List<Lot> Lister(string filtre = "", string property = "", string ordre = "")
        {
            IQueryable<Lot> query = _context.Lots
                        .Include(l => l.LotComposant)
                        .Include(l => l.Tournoi);

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(l => l.Libelle.Contains(filtre)
                        || l.ValeurTotale.ToString().Contains(filtre)
                        || l.RangAttribution.ToString().Contains(filtre)
                        || l.Numero.ToString().Contains(filtre)
                        || l.Tournoi.Nom.Contains(filtre)
                        || l.LotComposant.Any(lc => lc.Libelle.Contains(filtre)));

            query = property switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "Libelle" => ordre == "ASC" ? query.OrderBy(j => j.Libelle) : query.OrderByDescending(j => j.Libelle),
                "ValeurTotale" => ordre == "ASC" ? query.OrderBy(j => j.ValeurTotale) : query.OrderByDescending(j => j.ValeurTotale),
                "RangAttribution" => ordre == "ASC" ? query.OrderBy(j => j.RangAttribution) : query.OrderByDescending(j => j.RangAttribution),
                "Numero" => ordre == "ASC" ? query.OrderBy(j => j.Numero) : query.OrderByDescending(j => j.Numero),
                "Tournoi" => ordre == "ASC" ? query.OrderBy(j => j.Tournoi) : query.OrderByDescending(j => j.Tournoi),
                "LotComposant" => ordre == "ASC" ? query.OrderBy(j => j.LotComposant) : query.OrderByDescending(j => j.LotComposant),
                _ => query.OrderBy(j => j.Libelle) // valeur par défaut
            };

            return query.ToList();
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
        #endregion
        #region CUD
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

        #endregion
        #region Validations
        /// <summary>
        /// Permet de voir si un lot est conformes aux règles de sécurité suivantes
        /// </summary>
        /// <param name="lot">Instance de <see cref="Lot"/> à créer.</param>
        /// <returns>la liste des msgs d'erreurs.</returns>
        public List<string> ValiderLot(Lot lot)
        {
            // liste des erreurs
            var erreurs = new List<string>();

            if (string.IsNullOrWhiteSpace(lot.Libelle))
            {
                erreurs.Add("Le libelle ne peut pas être vide.");
            }
            if (lot.Libelle.Length > 50)
            {
                erreurs.Add("Le libelle ne peut pas faire plus de 20 charactères.");
            }
            if (lot.RangAttribution < 0)
            {
                erreurs.Add("Le rang ne peut pas être négatif");
            }
            return erreurs;
        }
        #endregion
    }
}
