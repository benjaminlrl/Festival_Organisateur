using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities
{
    /// <summary>
    /// Représente un Lot qu'on attribue à un Tournoi
    /// il dispose d'un libelle, d'une valeur totale,
    /// d'un rang d'attribution, si il est attribué ou non,
    /// le tournoi auquel il est associé et d'un id de lot
    /// </summary>
    public class Lot
    {
        /// <summary>
        /// Libelle du lot.
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// La valeur totale du lot.
        /// </summary>
        public float ValeurTotale { get; set; }

        /// <summary>
        /// Le rang attribué du lot.
        /// </summary>
        public int RangAttribution { get; set; }

        /// <summary>
        /// Si le lot est attribué ou non.
        /// True si attribué à un tournoi, false si non.
        /// </summary>
        public Boolean EstAttribue { get; set; }

        /// <summary>
        /// Tournoi associé au lot
        /// </summary>
        public Tournoi Tournoi { get; set; }

        /// <summary>
        /// Le numero du tournoi associé au lot
        /// </summary>
        public int NumeroTournoi { get; set; }

        /// <summary>
        /// Ensemble des composants du lot
        /// </summary>
        public ICollection<LotComposant> LotComposant { get; set; } = new List<LotComposant>();

        /// <summary>
        /// id du lot.
        /// </summary>
        public int Numero { get; set; }

    }
}
