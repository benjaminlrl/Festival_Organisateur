using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities
{
    /// <summary>
    /// Représente un Organisateur de l'application
    /// il dispose d'un login, d'un mot de passe
    /// d'un rôle (= l'id du rôle) ainsi que son mail
    /// </summary>
    public class Organisateur
    {
        /// <summary>
        /// Login de l'organisateur.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Mot de passe de l'organisateur.
        /// HASHé !!
        /// </summary>
        public string motPasse { get; set; }

        /// <summary>
        /// Mail de l'organisateur.
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Le rôle de l'organisateur.
        /// </summary>

        public Role Role { get; set; }

        /// <summary>
        /// Propriété récupérée utilisée pour l'affichage (DataGridView).
        /// Renvoie le nom de lu rôle de façon null-safe ;
        /// retourne chaîne vide si l'e rôle est null.
        /// </summary>
        public string NomRole => Role?.Libelle ?? string.Empty;

        /// <summary>
        /// Id du rôle de l'organisateur.
        /// </summary>
        public int IdRole { get; set; }
    }
}
