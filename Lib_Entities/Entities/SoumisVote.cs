using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities
{
    public class SoumisVote
    {
        public DateTime dateDebutVote { get; set; }
        public DateTime dateFinVote { get; set; }
        public int IdJeu { get; set; }
        public int IdPlateforme { get; set; }
        public Plateforme Plateforme { get; set; }
        public Jeu Jeu { get; set; }
    }
}
