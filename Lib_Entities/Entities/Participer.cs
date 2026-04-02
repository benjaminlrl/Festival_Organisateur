using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities
{
    public class Participer
    {
        public int id_user { get; set; }
        public int numero_tournoi { get; set; }
        public Tournoi? Tournoi { get; set; }
        /// <summary>
        /// Propriété récupérée utilisée pour l'affichage (DataGridView).
        /// Renvoie le nom du tournoi de façon null-safe ;
        /// retourne chaîne vide si l'espace est null.
        /// </summary>
        public string NomTournoi => Tournoi?.Nom ?? string.Empty;
        public int Rang{ get; set; }
        public int Evaluation { get; set; }
        public string? Commentaire { get; set; }
        public DateTime DateHeureInscription { get; set; }
        public int? ScoreFinal { get; set; }
        public int? LotRemis { get; set; }
        public Lot? Lot { get; set; }
        /// <summary>
        /// Propriété récupérée utilisée pour l'affichage (DataGridView).
        /// Renvoie le libellé de la plateforme de façon null-safe ;
        /// retourne chaîne vide si l'espace est null.
        /// </summary>
        public string LibelleLot => Lot?.Libelle ?? string.Empty;

    }
}
