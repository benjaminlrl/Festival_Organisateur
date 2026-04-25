using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IRoleService
    {
        #region Lecture

        /// <summary>
        /// Récupère un role par son libelle.
        /// </summary>
        /// <param name="Libelle">Le libelle du rôle cherché.</param>
        /// <returns>L'entité <see cref="Role"/> si trouvée, sinon null.</returns>
        Role? Obtenir(string Libelle);

        /// <summary>
        ///  Retourne la liste complète des roles présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Libelle, IdRole) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Role"/>.</returns>
        List<Role> Lister(string filtre = "", string propriete = "", string ordre = "");
        #endregion
        #region CUD
        /// <summary>
        /// Crée un nouveau role en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="role">Instance de <see cref="Role"/> à créer.</param>
        void Creer(Role role);

        /// <summary>
        /// Met à jour un role existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Role"/>.</param>
        void Modifier(Role role);

        /// <summary>
        /// Supprime un role
        /// </summary>
        /// <param name="role">Instance modifiée de <see cref="Role"/>.</param>
        void Supprimer(Role role);
        #endregion
        
    }
}
