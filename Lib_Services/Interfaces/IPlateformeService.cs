using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IPlateformeService
    {
        #region Lecture
        /// <summary>
        ///  Retourne la liste complète des plateformes présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Nom, Description, Superficie, CapaciteMaxi) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="property">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Plateforme"/>.</returns>
        List<Plateforme> Lister(string filtre = "", string propriete = "", string ordre = "");

        /// <summary>
        /// Récupère une plateforme par son identifiant.
        /// </summary>
        /// <param name="idPlateforme">Identifiant de la plateforme recherchée.</param>
        /// <returns>Instance de <see cref="Plateforme"/> si trouvée, sinon null.</returns>
        public Plateforme? Obtenir(int idPlateforme);
        #endregion
        #region CUD
        /// <summary>
        /// Crée une nouvelle plateforme et persiste la modification.
        /// </summary>
        /// <param name="plateforme">Objet <see cref="Plateforme"/> à ajouter.</param>
        void Creer(Plateforme plateforme);

        /// <summary>
        /// Met à jour une plateforme existante et persiste la modification.
        /// </summary>
        /// <param name="plateforme">Objet <see cref="Plateforme"/> contenant les valeurs mises à jour.</param>
        void Modifier(Plateforme plateforme);

        /// <summary>
        /// Supprime une plateforme identifiée par son identifiant si elle existe.
        /// </summary>
        /// <param name="idPlateforme">Identifiant de la plateforme à supprimer.</param>
        void Supprimer(int idplateforme);
        #endregion
        #region Validations

        /// <summary>
        /// Permet de vérifier les propriétés associés a une plateforme.
        /// </summary>
        /// <param name="plateforme">La plateforme à valider</param>
        /// <param name="estModification">Indique si la validation est effectuée dans le cadre d'une modification</param>
        /// <returns>La liste contenant toutes les erreurs</returns>
        void ValiderPlateforme(Plateforme plateforme, bool estModification = false);
        #endregion
    }
}
