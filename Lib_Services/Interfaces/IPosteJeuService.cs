using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IPosteJeuService
    {

        #region Lecture
        /// <summary>
        ///  Retourne la liste complète des postes de jeu présents en base, 
        ///  avec possibilité de filtrer par nom ou description.
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Reference, NumeroPoste, NomPlateforme, NomEspace, Fonctionnel) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="PosteJeu"/>.</returns>
        List<PosteJeu> Lister(string filtre = "", string propriete = "Reference", string ordre = "ASC");

        /// <summary>
        ///  Retourne la liste complète des postes de jeu NON FONCTIONNELS présents en base, 
        ///  avec possibilité de filtrer par nom ou description.
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Reference, NumeroPoste, NomPlateforme, NomEspace, Fonctionnel) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="PosteJeu"/>.</returns>
        public List<PosteJeu> ListerPostesJeuNonFonctionnels(string filtre = "", string propriete = "Nom", string ordre = "ASC");

        /// <summary>
        /// Récupère un poste de jeu par son identifiant.
        /// </summary>
        /// <param name="idPosteJeu">Identifiant du poste de jeu recherché.</param>
        /// <returns>L'entité <see cref="PosteJeu"/> si trouvée ; sinon null.</returns
        PosteJeu? Obtenir(int idPosteJeu);

        /// <summary>
        /// Récupère un poste de jeu par sa référence.
        /// </summary>
        /// <param name="reference">Référence du poste de jeu recherché.</param>
        /// <returns>L'entité <see cref="PosteJeu"/> si trouvée ; sinon null.</returns>
        PosteJeu? ReferenceExiste(string reference);
        #endregion  
        #region CUD
        /// <summary>
        /// Ajoute un nouveau poste de jeu .
        /// </summary>
        /// <param name="posteJeu">Instance de <see cref="PosteJeu"/> à créer.</param>
        void Creer(PosteJeu posteJeu);

        /// <summary>
        /// Met à jour un poste de jeu existant et persiste la modification.
        /// </summary>
        /// <param name="posteJeu">Instance de <see cref="PosteJeu"/> contenant les valeurs mises à jour.</param>
        void Modifier(PosteJeu posteJeu);

        /// <summary>
        /// Supprime un poste de jeu identifié par son identifiant si présent.
        /// </summary>
        /// <param name="idPosteJeu">Identifiant du poste de jeu à supprimer.</param>
        void Supprimer(int idPosteJeu);
        #endregion
        #region Validations
        /// <summary>
        /// Valide les données d'un poste de jeu avant création ou modification.
        /// </summary>
        /// <param name="posteJeu">Le poste de jeu concerné</param>
        /// <returns>La liste des erreurs de type <see cref="string"/></returns>
        List<string> ValiderPosteJeu(PosteJeu posteJeu);
        #endregion
    }
}
