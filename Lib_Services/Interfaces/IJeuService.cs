using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IJeuService
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
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Jeu"/>.</returns>
        List<Jeu> Lister(string filtre = "", string propriete = "", string ordre = "");
        Jeu? Obtenir(int idJeu);
        #endregion
        #region CUD
        void Creer(Jeu jeu);
        void Modifier(Jeu jeu);
        void Supprimer(int idJeu);
        #endregion
        #region Validations
        /// <summary>
        /// Permet de vérifier les propriétés associés a un jeu.
        /// </summary>
        /// <param name="jeu">Le jeu à valider</param>
        /// <returns></returns>
        List<string> ValiderJeu(Jeu jeu);
        #endregion
    }
}
