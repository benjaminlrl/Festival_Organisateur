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
        List<PosteJeu> Lister(string filtre = "", string propriete = "", string ordre = "");

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
        public List<PosteJeu> ListerPostesJeuNonFonctionnels(string filtre = "", string propriete = "", string ordre = "");

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

        /// <summary>
        /// permet de récupérer les postes de jeu associés à un espace donné,
        /// </summary>
        /// <param name="espace">L'espace dont on souhaite récupérer les postes de jeu</param>
        /// <returns>Liste des postes de jeu associés à l'espace</returns>
        List<PosteJeu> ListerPostesJeuDunEspace(Espace espace);
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
        /// <param name="estModification">Indique si la validation est pour une modification (true) ou une création (false)</param>
        /// <returns>La liste des erreurs de type <see cref="string"/></returns>
        void ValiderPosteJeu(PosteJeu posteJeu, bool estModification = false);
        #endregion

        #region Statistiques
        /// <summary>
        /// Permet d'obtenir le nombre total de postes de jeu enregistrés en base de données
        /// </summary>
        /// <param name="filtre">Optionnel, filtre sur les propriétés du poste de Jeu</param>
        /// <returns></returns>
        int NombrePostesJeu(string filtre = "");

        /// <summary>
        /// Permet d'obtenir le nombre de postes de jeu fonctionnel enregistrés en base de données
        /// </summary>
        /// <param name="filtre">Optionnel, filtre sur les propriétés du poste de Jeu</param>
        /// <returns></returns>
        int NombrePostesJeuFonctionnels(string filtre = "");

        /// <summary>
        /// Permet d'obtenir le nombre de postes de jeu enregistrés en base de données
        /// </summary>
        /// <param name="idEspace"></param>
        /// <param name="idPlateforme"></param>
        /// <returns></returns>
        int NombrePostesJeuEspacePlateforme(int idEspace, int idPlateforme);
        #endregion

        #region Méthodes
        /// <summary>
        /// Dans le cas ou le nom d'un espace est modifié, 
        /// cette méthode permet de mettre à jour 
        /// la référence de tous les postes de jeu associés à cet espace
        /// </summary>
        /// <param name="postesJeu"></param>
        /// <param name="nouveauNomEspace"></param>
        /// <exception cref="Exception"></exception>
        /// <returns>True si la mise à jour a réussi, false sinon</returns>
        void FormatRefPosteJeuEspaceNouvNom(List<PosteJeu> postesJeu, string nouveauNomEspace);
        #endregion
    }
}
