using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities
{
    public class Joueur
    {
        public int IdUser { get; set; }

        /// <summary>
        /// Ensemble des participations de ce joueur.
        /// </summary>
        public ICollection<Participer> Participations { get; set; } = new List<Participer>();

        /// <summary>
        /// Ensemble des votes de ce joueur.
        /// </summary>
        public ICollection<Voter> Votes { get; set; } = new List<Voter>();
    }
}
