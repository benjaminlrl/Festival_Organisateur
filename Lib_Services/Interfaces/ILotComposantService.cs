using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface ILotComposantService
    {
        #region Lecture
        /// <summary>
        ///  Retourne la liste complète des jeux présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Nom, Description, Superficie, CapaciteMaxi) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="property">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="LotComposant"/>.</returns>
        List<LotComposant> Lister(string filtre = "", string property = "", string ordre = "");

        /// <summary>
        /// Retourne la liste complète des lots composants contenant le numero du lot passé en paramètre
        /// Exécute immédiatement la requête via <c>ToList()</c>.
        /// </summary>
        /// <param name="numero">numero du lot qu'on cherche</param>
        /// <returns>Liste d'objets <see cref="LotComposant"/>.</returns>
        List<LotComposant> ListerParNumeroDunLot(int numero, string property = "", string ordre = "");

        /// <summary>
        /// Récupère un lotcomposant par son numero.
        /// </summary>
        /// <param name="numero">numero du lotcomposant cherché.</param>
        /// <returns>L'entité <see cref="LotComposant"/> si trouvée, sinon null.</returns>
        LotComposant? Obtenir(int numero);

        #endregion
        #region CUD

        /// <summary>
        /// Crée un nouvel lotcomposant en base
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="lotComposant">Instance de <see cref="LotComposant"/> à créer.</param>
        void Creer(LotComposant lotComposant);

        /// <summary>
        /// Met à jour un lotcomposant existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="lotComposant">Instance modifiée de <see cref="LotComposant"/>.</param>
        void Modifier(LotComposant lotComposant);

        /// <summary>
        /// Supprime un lotcomposant identifié par son login s'il existe.
        /// </summary>
        /// <param name="numero">numero du lotcomposant à supprimer.</param>
        void Supprimer(int numero);
        #endregion
        #region validations
        /// <summary>
        /// Permet de voir si un lot composant est conformes aux règles de sécurité suivantes
        /// </summary>
        /// <param name="lotComposant">Instance de <see cref="LotComposant"/> à créer.</param>
        /// <returns>la liste des msgs d'erreurs.</returns>
        public List<string> ValiderLotComposant(LotComposant lotComposant);
        #endregion
    }
}
