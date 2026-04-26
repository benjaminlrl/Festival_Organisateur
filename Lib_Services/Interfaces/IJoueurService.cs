using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IJoueurService
    {
        #region Lecture
        /// <summary>
        ///  Retourne la liste complète des espaces présents en base, 
        ///  avec possibilité de filtrer par nom ou description.
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Nom, Description, Superficie, CapaciteMaxi) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <returns>Liste d'objets <see cref="Espace"/>.</returns>
        List<Joueur> Lister(string filtre = "", string colonne = "Nom", string ordre = "ASC");
       
        /// <summary>
        /// Récupère un espace par son identifiant.
        /// </summary>
        /// <param name="idEspace">Identifiant de l'espace cherché.</param>
        /// <returns>L'entité <see cref="Espace"/> si trouvée, sinon null.</returns>
        Joueur? Obtenir(int idUser);
        #endregion
        #region CUD
        /// <summary>
        /// Crée un nouvel espace en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Espace"/> à créer.</param>
        void Creer(Joueur joueur);

        /// <summary>
        /// Supprime un espace identifié par son identifiant s'il existe.
        /// </summary>
        /// <param name="idEspace">Identifiant de l'espace à supprimer.</param>
        void Supprimer(int idUser);
        #endregion
        #region Validations 
        #endregion
    }
}
