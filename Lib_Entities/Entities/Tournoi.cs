using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib_Entities.Entities
{
    /// <summary>
    /// Représente un tournoi . 
    /// Chaque tournoi dispose d'un numéro incrémenté, d'un nom
    /// d'un nombre de participants, d'une date et d'une heure de début, 
    /// d'une durée.Elle a un statut (planifié, en cours, terminé) 
    /// et est associée à un espace de jeu .
    /// </summary>
    public class Tournoi
    {
        /// <summary>
        /// Numéro du tournoi .
        /// </summary>
        public int NumeroTournoi { get; set; }

        /// <summary>
        /// Date et heure de début du tournoi.
        /// </summary>
        public DateTime DateHeure { get; set; }

        /// <summary>
        /// Nombre de participants attendus au maximum.
        /// </summary>
        public int NbParticipants { get; set; }

        /// <summary>
        /// Durée prévue  en minutes.
        /// </summary>
        public int DureePrevue { get; set; }

        /// <summary>
        /// Nom .
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Statut courant ("Planifié", "EnCours", "Terminé").
        /// </summary>
        public string Statut { get; set; }

        /// <summary>
        /// L'id de l'espace associé à ce tournoi ( id utile pour la gestion du formulaire et 
        /// accès)
        /// </summary>
        public int IdEspace { get; set; }

        /// <summary>
        /// Espace associé.
        /// </summary>
        public Espace Espace { get; set; }

        /// <summary>
        /// Propriété récupérée utilisée pour l'affichage (DataGridView).
        /// Renvoie le nom de l'espace de façon null-safe ;
        /// retourne chaîne vide si l'espace est null.
        /// </summary>
        public string NomEspace => Espace?.Nom ?? string.Empty;

        /// <summary>
        /// L'id du associé à ce tournoi ( id utile pour la gestion du formulaire et 
        /// accès)
        /// </summary>
        public int IdJeu { get; set; }

        /// <summary>
        /// Espace associé.
        /// </summary>
        public Jeu Jeu { get; set; }

        /// <summary>
        /// Propriété récupérée utilisée pour l'affichage (DataGridView).
        /// Renvoie le nom de l'espace de façon null-safe ;
        /// retourne chaîne vide si l'espace est null.
        /// </summary>
        public string TitreJeu => Jeu?.Titre ?? string.Empty;


        /// <summary>
        /// Lot concerné pour le Tournoi
        /// </summary>
        public ICollection<Lot> Lot { get; set; }

        /// <summary>
        /// Nombre de participants inscrits au tournoi. Cette propriété n'est pas mappée à la base de données
        /// </summary>
        [NotMapped]
        public int NbParticipantsInscrits { get; set; }
    }

}
