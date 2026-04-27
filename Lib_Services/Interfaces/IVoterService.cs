using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IVoterService
    {
        #region Lecture
        /// <summary>
        /// Retourne tous les Votes présents dans la base de données.
        /// Si un filtre est fourni, retourne uniquement 
        /// les Votes dont le contenu correspond au filtre.
        /// </summary>
        /// <param name="filtre">Optionnel : contenu à filtrer.</param>
        /// <returns>Liste de <see cref="Voter"/>.</returns>
        List<Voter> Lister(string filtre);

        /// <summary>
        /// Pour un utilisateur donné par son id, retourne uniquement
        /// les Votes présents dans la base de données.
        /// </summary>
        /// <param name="idUser">Id unique de l'utilisateur</param>
        /// <param name="filtre">Filtre de la recherche<param>
        /// <returns>Liste de <see cref="Voter"/>.</returns>
        List<Voter> ListerPourUnUtilisateur(int idUser, string filtre);

        /// <summary>
        /// Récupère un Vote identifié par l'id de l'utilisateur, 
        /// l'id du jeu et l'id de la plateforme, 
        /// puis persiste la modification.
        /// </summary>
        /// <param name="idUser">Id de l'utilisateur</param>
        /// <param name="idJeu">Id du jeu voté</param>
        /// <param name="idPlateforme">Id de la plateforme associé au jeu</param>
        /// <returns>L'objet <see cref="Voter"/> ou null si aucun vote n'est trouvé.</returns>
        Voter? Obtenir(int idJeu, int idPlateforme, int idUser);
        #endregion

        #region CUD
        /// <summary>
        /// Crée un nouveau Vote et persiste la modification.
        /// </summary>
        /// <param name="Vote">Objet <see cref="Voter"/> à ajouter.</param>
        void Creer(Voter vote);

        /// <summary>
        /// Met à jour un Vote existant et persiste la modification.
        /// </summary>
        /// <param name="Vote">Objet <see cref="Voter"/> contenant les valeurs mises à jour.</param>
        void Modifier(Voter vote);

        /// <summary>
        /// Supprime un Vote identifié par l'id de l'utilisateur, 
        /// l'id du jeu et l'id de la plateforme, 
        /// puis persiste la modification.
        /// </summary>
        /// <param name="idUser">Id de l'utilisateur</param>
        /// <param name="idJeu">Id du jeu voté</param>
        /// <param name="idPlateforme">Id de la plateforme associé au jeu</param>
        void Supprimer(int idJeu, int idPlateforme, int idUser);
        #endregion       

        #region Validations

        /// <summary>
        /// Valide les propriétés associées à un vote.
        /// </summary>
        /// <param name="vote">Vote à valider</param>
        /// <param name="estModification">Indique si la validation est effectuée dans le cadre d'une modification.</param>
        /// <exception cref="VoteException">Exception si les données du vote sont invalides</exception>
        void ValiderVote(Voter vote, bool estModification = false);
        #endregion
    }
}
