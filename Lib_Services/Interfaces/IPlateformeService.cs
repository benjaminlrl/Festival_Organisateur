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
        List<Plateforme> Lister(string filtre = "", string property = "", string ordre = "");

        /// <summary>
        /// Récupère une plateforme par son identifiant.
        /// </summary>
        /// <param name="idPlateforme">Identifiant de la plateforme recherchée.</param>
        /// <returns>Instance de <see cref="Plateforme"/> si trouvée, sinon null.</returns>
        public Plateforme? Obtenir(int idPlateforme);
        #endregion
        void Creer(Plateforme plateforme);
        void Modifier(Plateforme plateforme);
        void Supprimer(int idplateforme);
        List<Plateforme> Lister(string filtre);
        List<string> ValiderPlateforme(Plateforme plateforme);
    }
}
