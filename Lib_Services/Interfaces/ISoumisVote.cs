using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface ISoumisVoteService
    {
        #region Lecture
        /// <summary>
        ///  Retourne la liste complète des roles présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Libelle, IdRole) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="property">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="SoumisVote"/>.</returns>
        public List<SoumisVote> Lister(string filtre = "", string property = "", string ordre = "");

        /// <summary>
        ///  Retourne la liste complète des roles présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Libelle, Titre)
        ///  et dans un ordre donné (ASC ou DESC).
        ///  
        /// Permet également de filtrer les résultats sur une période de vote donnée.
        /// 
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="property">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <param name="dateDebut">Optionnel, date de début de la période de vote</param>
        /// <param name="dateFin">Optionnel, date de fin de la période de vote</param>
        /// <returns>Liste d'objets <see cref="Voter"/>.</returns>
        public List<Voter> ListerClassmentJeuxVotes(string filtre = "", string property = "", string ordre = "", DateTime? dateDebut = null, DateTime? dateFin = null);

        /// <summary>
        /// Retourne un SoumisVote identifié par l'id du jeu et l'id de la plateforme.
        /// AsNoTracking() est utilisé pour éviter les conflits de tracking lors des modifications.
        /// </summary>
        /// <param name="idJeu">Id du jeu voté</param>
        /// <param name="idPlateforme">Id de la plateforme associé au jeu</param>
        /// <returns>Le SoumisVote correspondant ou null s'il n'existe pas</returns>
        SoumisVote? Obtenir(int idJeu, int idPlateforme);
        #endregion
        #region CUD

        /// <summary>
        /// Crée un nouveau SoumisVote et persiste la modification.
        /// </summary>
        /// <param name="soumisVote">Objet <see cref="SoumisVote"/> à ajouter.</param>
        void Creer(SoumisVote soumisVote);

        /// <summary>
        /// Met à jour un SoumisVote existant et persiste la modification.
        /// </summary>
        /// <param name="soumisVote">Objet <see cref="SoumisVote"/> contenant les valeurs mises à jour.</param>
        void Modifier(SoumisVote soumisVote);

        /// <summary>
        /// Supprime un SoumisVote identifié par l'id de l'utilisateur, 
        /// l'id du jeu et l'id de la plateforme, 
        /// puis persiste la modification.
        /// </summary>
        /// <param name="idJeu">Id du jeu voté</param>
        /// <param name="idPlateforme">Id de la plateforme associé au jeu</param>
        void Supprimer(int idJeu, int idPlateforme);
        #endregion
        #region Validations
        /// <summary>
        /// Permet de vérifier les propriétés associés a une SoumisVote.
        /// </summary>
        /// <param name="soumisVote">Le SoumisVote à valider</param>
        /// <returns>La liste contenant toutes les erreurs</returns>
        List<string> ValiderSoumisVote(SoumisVote soumisVote, bool estModification);
        #endregion
    }
}
