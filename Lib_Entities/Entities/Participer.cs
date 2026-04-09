using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities
{
    public class Participer
    {
        public int IdUser { get; set; }
        public int NumeroTournoi { get; set; }
        public Tournoi? Tournoi { get; set; }
        /// <summary>
        /// Propriété récupérée utilisée pour l'affichage (DataGridView).
        /// Renvoie le nom du tournoi de façon null-safe ;
        /// retourne chaîne vide si l'espace est null.
        /// </summary>
        public string NomTournoi => Tournoi?.Nom ?? string.Empty;
        public int Rang{ get; set; }
        public int? Evaluation { get; set; }
        public string? Commentaire { get; set; }
        public DateTime DateHeureInscription { get; set; }
        public int? ScoreFinal { get; set; }
        /// <summary>
        /// Inidque si le lot a été remis ou non au participant.
        /// </summary>
        public bool LotRemis { get; set; }

    }
}
