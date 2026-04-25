using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface ITournoiService
    {
        #region Lecture
        /// <summary>
        ///  Retourne la liste complète des tournois présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Nom, NbParticipants, DureePrevue, DateHeure, Statut, Espace, Jeu, NumeroTournoi) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="property">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Tournoi"/>.</returns>
        List<Tournoi> Lister(string filtre = "", string property = "", string ordre="");
        /// <summary>
        /// Retourne la liste des tournois dont le statut est "Terminé" avec l'espace et le jeu associé chargé.
        /// </summary>
        /// <param name="idEspace">Id de l'espace</param>
        /// <returns>Les tournois terminés.</returns>
        List<Tournoi> ListerTournoisTerminesEspace(int idEspace);

        /// <summary>
        /// Retourne la liste des tournois dont le statut est "En cours" avec l'espace et le jeu associé chargé.
        /// </summary>
        /// <param name="idEspace">Id de l'espace</param>
        /// <returns>Les tournois en cours.</returns>
        List<Tournoi> ListerTournoisEnCoursEspace(int idEspace);

        /// <summary>
        /// Retourne la liste des tournois dont le statut est "Planifié" avec l'espace et le jeu associé chargé.
        /// </summary>
        /// <param name="idEspace">Id de l'espace</param>
        /// <returns>Les tournois planifiés.</returns>
        List<Tournoi> ListerTournoisPlanifiesEspace(int idEspace);

        /// <summary>
        /// Récupère un tournoi par son identifiant avec l'espace associé.
        /// Retourne null si aucun tournoi n'est trouvé.
        /// </summary>
        /// <param name="numeroTournoi">Identifiant du tournoi.</param>
        /// <returns>Instance <see cref="Tournoi"/> ou null.</returns>
        Tournoi? Obtenir(int numeroTournoi);
        #endregion
        #region CUD
        /// <summary>
        /// Crée un nouveau tournoi en base après validation métier minimale.
        /// Lance une <see cref="ArgumentException"/> si le nombre de participants est invalide.
        /// </summary>
        /// <param name="tournoi">Instance du tournoi à créer.</param>
        void Creer(Tournoi tournoi);

        /// <summary>
        /// Met à jour un tournoi existant en base.
        /// </summary>
        /// <param name="tournoi">Instance modifiée du tournoi</param>
        void Modifier(Tournoi tournoi);

        /// <summary>
        /// Supprime un tournoi identifié par son numéro si présent en base.
        /// </summary>
        /// <param name="numeroTournoi">Identifiant du tournoi à supprimer.</param>
        void Supprimer(int numeroTournoi);
        #endregion
        #region Validations
        /// <summary>
        /// Permet de vérifier les propriétés associés a un tournoi.
        /// </summary>
        /// <param name="jeu">Le jeu à valider</param>
        /// <returns>La liste contenant toutes les erreurs</returns>
        List<string> ValiderTournoi(Tournoi tournoi, bool estModification);
        #endregion
    }
}
