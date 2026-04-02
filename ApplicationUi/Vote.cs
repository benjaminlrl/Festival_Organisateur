using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities.Votes
{
    /// <summary>
    /// Représente un vote,
    /// Un vote est uniquement identifié par sa date de vote, 
    /// qui correspond à la date et l'heure auxquelles le vote a été effectué.
    /// 
    /// </summary>
    internal class Vote
    {
        public DateTime dateVote { get; set; }
    }
}
