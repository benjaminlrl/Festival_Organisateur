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

        /// <summary>
        /// Récupère un jeu par son identifiant.
        /// </summary>
        /// <param name="idPlateforme">Identifiant du jeu recherché.</param>
        /// <returns>Instance de <see cref="Jeu"/> si trouvée, sinon null.</returns>
        Jeu? Obtenir(int idJeu);

        /// <summary>
        /// Récupère un jeu par son titre.
        /// </summary>
        /// <param name="titreJeu">Titre du jeu recherché.</param>
        /// <returns>Instance de <see cref="Jeu"/> si trouvée, sinon null.</returns>
        public Jeu? ObtenirParTitre(string titreJeu);
        #endregion
        #region CUD

        /// <summary>
        /// Crée un nouveau jeu et persiste la modification.
        /// </summary>
        /// <param name="jeu">Objet <see cref="Jeu"/> à ajouter.</param>
        void Creer(Jeu jeu);

        /// <summary>
        /// Met à jour un jeu existant et persiste la modification.
        /// </summary>
        /// <param name="jeu">Objet <see cref="Jeu"/> contenant les valeurs mises à jour.</param>
        void Modifier(Jeu? jeu);

        /// <summary>
        /// Supprime un jeu identifié par son identifiant si il existe.
        /// </summary>
        /// <param name="idPlateforme">Identifiant du jeu à supprimer.</param>
        void Supprimer(int idJeu);
        #endregion

        #region Validations
        /// <summary>
        /// Permet de vérifier les propriétés associés a un jeu avant l'ajout ou la modification.
        /// </summary>
        /// <param name="jeu">Le jeu à valider</param>
        /// <param name="estModification">Indique si la validation est effectuée dans le cadre d'une modification</param>
        /// <returns></returns>
        void ValiderJeu(Jeu jeu, bool estModification = false);

        /// <summary>
        /// Permet de vérifier les propriétés associés a un jeu avant la suppression.
        /// </summary>
        /// <param name="jeu">Le jeu à valider</param>
        /// <param name="estModification">Indique si la validation est effectuée dans le cadre d'une modification</param>
        /// <returns></returns>
        void ValiderSuppressionJeu(Jeu jeu, bool estModification = false);
        #endregion
    }
}
