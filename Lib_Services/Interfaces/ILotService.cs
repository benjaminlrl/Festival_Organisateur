using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface ILotService
    {
        #region Lecture
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
        List<Lot> Lister(string filtre = "", string propriete = "", string ordre = "");

        /// <summary>
        /// Récupère un lot par son numéro
        /// </summary>
        /// <param name="numero">numero du lot cherché.</param>
        /// <returns>L'entité <see cref="Lot"/> si trouvée, sinon null.</returns>
        Lot? Obtenir(int numero);
        #endregion

        #region CUD
        /// <summary>
        /// Crée un nouveau Lot en base
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Lot"/> à créer.</param>
        void Creer(Lot lot);

        /// <summary>
        /// Met à jour un Lot existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Lot"/>.</param>
        void Modifier(Lot lot);

        /// <summary>
        /// Supprime un Lot identifié en base.
        /// </summary>
        /// <param name="lot">Instance de <see cref="Lot"/> à supprimer.</param>
        void Supprimer(Lot lot);
        #endregion

        #region Validations
        /// <summary>
        /// Permet de voir si un lot est conformes aux règles de sécurité suivantes lors de l'ajout et la modification
        /// </summary>
        /// <param name="lot">Instance de <see cref="Lot"/> à créer.</param>
        /// <param name="estModification">Indique si la validation est pour une modification (true) ou une création (false).</param>
        /// <returns>la liste des msgs d'erreurs.</returns>
        void ValiderLot(Lot lot, bool estModification = false);

        /// <summary>
        /// Permet de voir si un lot est conformes aux règles de sécurité suivantes lors de la suppression
        /// </summary>
        /// <param name="lot">Instance de <see cref="Lot"/> à créer.</param>
        /// <returns>la liste des msgs d'erreurs.</returns>
        void ValiderSuppressionLot(Lot lot);
        #endregion
    }
}
