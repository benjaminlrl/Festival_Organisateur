using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IParticiperService
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
        /// <returns>Liste d'objets <see cref="Participer"/>.</returns>
        List<Participer> Lister(string filtre = "", string propriete = "", string ordre = "");

        /// <summary>
        ///  Retourne la liste complète des jeux présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Nom, Description, Superficie, CapaciteMaxi) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="idUser">id du joueur</param>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Participer"/>.</returns>
        public List<Participer> ListerParJoueur(int idUser, string filtre = "", string propriete = "", string ordre = "");

        /// <summary>
        /// Permet d'obtenir la liste des id des participants inscrits à au moins un tournoi.
        /// </summary>
        /// <returns>Liste des identifiants des participants.</returns>
        List<object> ListerIdsParticipants();
        /// <summary>
        /// Récupère un Participant par son id et son numéro de tournoi.
        /// </summary>
        /// <param name="Login">Login de l'Participer cherché.</param>
        /// <returns>L'entité <see cref="Participer"/> si trouvée, sinon null.</returns>
        Participer? Obtenir(int idUser, int numeroTournoi);

        #endregion

        #region CUD

        /// <summary>
        /// Crée un nouvel Participer en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Participer"/> à créer.</param>
        void Creer(Participer participer);

        /// <summary>
        /// Met à jour un Participant existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Participer"/>.</param>
        void Modifier(Participer? participer);

        /// <summary>
        /// Supprime un Participant identifié par son id et son tournoi associé s'il existe.
        /// </summary>
        /// <param name="idUser">Id unique de l'utilisateur à supprimer.</param>
        /// <param name="numeroTournoi">Numero du tournoi associé à la participation à supprimer.</param>
        /// <param name="forcerTournoi">Vraie si on veutr forcer la suppression malgrès un tournoi En cours<param>
        void Supprimer(int idUser, int numeroTournoi, bool forcerTournoi = false);
        #endregion

        #region Statistiques
        /// <summary>
        /// Permet de récupérer le podium Par tournoi
        /// </summary>
        /// <param name="numeroTournoi">Id du tournoi</param>
        /// <returns>Le classement des 10 meilleurs participants pour le tournoi spécifié.</returns>
        List<Participer> ObtenirTop10ParTournoi(int numeroTournoi);

        /// <summary>
        /// Permet d'obtenir le nombre de participants inscrits à un tournoi donné.
        /// </summary>
        /// <param name="numeroTournoi">Numero unique du tournoi associé à la participation</param>
        /// <returns>Le nombre de participants inscrit au tournoi</returns>
        int ObtenirNombreParticipantsParTournoi(int numeroTournoi);

        /// <summary>
        /// Calcule la moyenne des évaluations attribuées aux participations d'un tournoi spécifié. 
        /// </summary>
        /// <param name="numeroTournoi">Le numéro unique identifiant le tournoi pour lequel la moyenne des évaluations doit être calculée.</param>
        /// <returns>La moyenne des évaluations pour le tournoi spécifié. Retourne 0,0 si aucune évaluation n'est disponible.</returns>
        double? ObtenirMoyenneEvaluationParTournoi(int numeroTournoi);
        #endregion

        #region Validations
        /// <summary>
        /// Permet de vérifier les propriétés associés a une plateforme.
        /// </summary>
        /// <param name="participer">La participation à valider</param>
        /// <returns>La liste contenant toutes les erreurs</returns>
        void ValiderParticipation(Participer participer, bool estModification = false);

        /// <summary>
        /// Valide les propriétés d'une instance de <see cref="Participer"/> peut être supprimer ou non.
        /// </summary>
        /// <param name="participer">Instance de <see cref="Participer"/> à valider.</param>
        /// <param name="forcerSupp">Vraie pour forcer la suppression malgrès un tournoi en cours</param>
        /// <exception cref="ParticiperException">Exception levée si une validation échoue.</exception>
        public void ValiderSuppressionParticipation(Participer? participer, bool forcerSupp = false);
        #endregion
    }
}
