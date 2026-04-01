using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities
{
    /// <summary>
    /// Représente un vote,
    /// Un vote dispose d'un idUser, d'un idJeu, d'un idPlateforme et d'une date de vote.
    /// 
    /// </summary>
    public class Vote
    {
        public int IdUser { get; set; }
        public int IdJeu { get; set; }
        public int IdPlateforme { get; set; }
        public DateTime DateVote { get; set; }

        public Plateforme Plateforme { get; set; }
        public Jeu Jeu { get; set; }
    }
}
