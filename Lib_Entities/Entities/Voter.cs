using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib_Entities.Entities
{
    /// <summary>
    /// Représente un vote,
    /// Un vote dispose d'un idUser, d'un idJeu, d'un idPlateforme et d'une date de vote.
    /// 
    /// </summary>
    public class Voter
    {
        public int IdUser { get; set; }
        public int IdJeu { get; set; }
        public int IdPlateforme { get; set; }
        public DateTime DateVote { get; set; }

        public Plateforme Plateforme { get; set; }
        /// <summary>
        /// Propriété récupérée utilisée pour l'affichage (DataGridView).
        /// Renvoie le libellé de la plateforme de façon null-safe ;
        /// retourne chaîne vide si l'espace est null.
        /// </summary>
        [NotMapped] 
        public string LibellePlateforme => Plateforme?.Libelle ?? string.Empty;
        public Jeu Jeu { get; set; }
        /// <summary>
        /// Propriété récupérée utilisée pour l'affichage (DataGridView).
        /// Renvoie le titre du jeu de façon null-safe ;
        /// retourne chaîne vide si l'espace est null.
        /// </summary>
        [NotMapped] 
        public string TitreJeu => Jeu?.Titre ?? string.Empty;

        /// <summary>
        /// Correspond au nombres de votes associés au binome (id_jeu,id_plateforme) pour le classement des votes
        /// </summary>
        [NotMapped]
        public int NbVotes { get; set; }
    }
}
