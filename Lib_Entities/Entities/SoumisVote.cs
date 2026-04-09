using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib_Entities.Entities
{
    public class SoumisVote
    {
        public DateTime DateDebutVote { get; set; }
        public DateTime DateFinVote { get; set; }
        public int IdJeu { get; set; }
        public int IdPlateforme { get; set; }
        public Plateforme Plateforme { get; set; }

        /// <summary>
        /// Propriété récupérée utilisée pour l'affichage (DataGridView).
        /// Renvoie le libellé de la plateforme de façon null-safe ;
        /// retourne chaîne vide si l'espace est null.
        /// </summary>
        public string LibellePlateforme => Plateforme?.Libelle ?? string.Empty;
        public Jeu Jeu { get; set; }
        /// <summary>
        /// Propriété récupérée utilisée pour l'affichage (DataGridView).
        /// Renvoie le titre du jeu de façon null-safe ;
        /// retourne chaîne vide si l'espace est null.
        /// </summary>
        public string TitreJeu => Jeu?.Titre ?? string.Empty;

        /// <summary>
        /// Correspond au taux de vote d'un jeu
        /// </summary>
        [NotMapped]
        public double TauxVoteJeu { get; set; }
    }
}
