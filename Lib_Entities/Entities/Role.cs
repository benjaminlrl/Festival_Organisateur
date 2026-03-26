using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities
{
    /// <summary>
    /// Représente un rôle concernant les utilisateurs
    /// il dispose d'un libelle ainsi que d'un id
    /// </summary>
    public class Role
    {
        /// <summary>
        /// id du Rôle.
        /// </summary>
        public int IdRole { get; set; }

        /// <summary>
        /// Libelle du rôle.
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Ensemble des Organisateurs possédant le rôle.
        /// </summary>
        public ICollection<Organisateur> Organisateurs { get; set; } = new List<Organisateur>();

    }
}
