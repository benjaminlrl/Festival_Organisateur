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
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Lot"/>.</returns>
        public List<Lot> Lister(string filtre = "", string propriete = "", string ordre = "")
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

            query = propriete switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "Libelle" => ordre == "ASC" ? query.OrderBy(l => l.Libelle) : query.OrderByDescending(l => l.Libelle),
                "ValeurTotale" => ordre == "ASC" ? query.OrderBy(l => l.ValeurTotale) : query.OrderByDescending(l => l.ValeurTotale),
                "RangAttribution" => ordre == "ASC" ? query.OrderBy(l => l.RangAttribution) : query.OrderByDescending(l => l.RangAttribution),
                "Numero" => ordre == "ASC" ? query.OrderBy(l => l.Numero) : query.OrderByDescending(l => l.Numero),
                "Tournoi" => ordre == "ASC" ? query.OrderBy(l => l.Tournoi) : query.OrderByDescending(l => l.Tournoi),
                "LotComposant" => ordre == "ASC" ? query.OrderBy(l => l.LotComposant) : query.OrderByDescending(l => l.LotComposant),
                _ => query.OrderByDescending(l => l.Numero) // valeur par défaut
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
            ValiderLot(lot, false);
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
            ValiderLot(lot, true);
            _context.Lots.Update(lot);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un Lot identifié en base.
        /// </summary>
        /// <param name="lot">Instance de <see cref="Lot"/> à supprimer.</param>
        public void Supprimer(Lot lot)
        {
            ValiderSuppressionLot(lot);
            _context.Lots.Remove(lot);
            _context.SaveChanges();
        }

        #endregion

        #region Validations
        /// <summary>
        /// Valide les propriétés d'une instance de <see cref="Lot"/> avant sa création ou sa modification.
        /// </summary>
        /// <param name="lot">Instance de <see cref="Lot"/> à valider.</param>
        /// <param name="estModification">Indique si la validation est pour une modification.</param>
        /// <exception cref="LotException">Exception levée si une validation échoue.</exception>
        public void ValiderLot(Lot lot, bool estModification = false)
        {
            if (string.IsNullOrWhiteSpace(lot.Libelle))
                throw new LotException("Le libellé ne peut pas être vide.",
                    (int)LotException.LotErreur.LibelleVide);

            if (string.IsNullOrWhiteSpace(lot.NumeroTournoi.ToString()))
                throw new LotException("Le tournoi ne peut pas être vide.",
                    (int)LotException.LotErreur.TournoiVide);

            if (lot.Libelle.Length > 50)
                throw new LotException("Le libellé ne peut pas dépasser 50 caractères.",
                    (int)LotException.LotErreur.LibelleTropLong);

            if (lot.RangAttribution < 0)
                throw new LotException("Le rang ne peut pas être négatif.",
                    (int)LotException.LotErreur.RangNegatif);

            if (lot.RangAttribution == 0)
                throw new LotException("Le rang ne peut pas être égale à 0.",
                    (int)LotException.LotErreur.RangZero);

            if (lot.RangAttribution > 10)
                throw new LotException("Le rang ne peut pas être supérieur à 10.",
                    (int)LotException.LotErreur.RangTropGrand);
        }

        /// <summary>
        /// Valide les propriétés d'une instance de <see cref="Lot"/> peut être supprimer ou non.
        /// </summary>
        /// <param name="lot">Instance de <see cref="Lot"/> à valider.</param>
        /// <exception cref="LotException">Exception levée si une validation échoue.</exception>
        public void ValiderSuppressionLot(Lot lot)
        {
            if (Obtenir(lot.Numero) == null)
                throw new LotException("Le lot n'existe pas en base de données'.",
                    (int)LotException.LotErreur.LotInexistant);
        }
        #endregion
    }
}
