using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities
{
    /// <summary>
    /// Représente un poste de jeu d'un espace
    /// il dispose d'un numéro, d'une référence, mais aussi d'un état ( fonctionnel ou pas) .
    /// il est associé à une plateforme (ex: PS5, Xbox, PC, etc.) 
    /// et à un espace (ex: salle de jeu, zone de réalité virtuelle, etc.).
    /// </summary>
    public class PosteJeu
    {
        /// <summary>
        /// Numéro .
        /// </summary>
        public int NumeroPoste { get; set; }

        /// <summary>
        /// Référence .
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// Indique si le poste est actuellement fonctionnel.
        /// </summary>
        public bool Fonctionnel { get; set; }

        /// <summary>
        /// Lien vers l'id de la plateforme contenant ce poste. 
        /// </summary>
        public int IdPlateforme { get; set; }

        /// <summary>
        /// Propriété de navigation vers la `Plateforme` associée.
        /// </summary>
        public Plateforme Plateforme { get; set; }

        /// <summary>
        /// Lien vers l'id de l'Espace contenant ce poste.
        /// </summary>
        public int IdEspace { get; set; }

        /// <summary>
        /// Propriété de navigation vers l'`Espace` contenant le poste.
        /// </summary>
        public Espace Espace { get; set; }
    }

}
