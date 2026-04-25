using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities
{
    /// <summary>
    /// Représente un poste de jeu d'un espace.
    /// Il dispose d'un numéro, d'une référence, mais aussi d'un état (fonctionnel ou pas).
    /// Il est associé à une plateforme (ex: PS5, Xbox, PC, etc.)
    /// et à un espace (ex: salle de jeu, zone de réalité virtuelle, etc.).
    /// </summary>
    public class PosteJeu
    {
        /// <summary>
        /// Numéro du poste.
        /// </summary>
        public int NumeroPoste { get; set; }

        /// <summary>
        /// Référence du poste.
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
        /// Propriété de navigation vers la <see cref="Plateforme"/> associée.
        /// </summary>
        public Plateforme Plateforme { get; set; }

        /// <summary>
        /// Lien vers l'id de l'espace contenant ce poste.
        /// </summary>
        public int IdEspace { get; set; }

        /// <summary>
        /// Propriété de navigation vers l'<see cref="Espace"/> contenant le poste.
        /// </summary>
        public Espace Espace { get; set; }

        /// <summary>
        /// Propriété calculée utilisée pour l'affichage (DataGridView).
        /// Renvoie le nom de l'espace de façon null-safe ;
        /// retourne une chaîne vide si l'espace est null.
        /// </summary>
        public string NomEspace => Espace?.Nom ?? string.Empty;

        /// <summary>
        /// Propriété calculée utilisée pour l'affichage (DataGridView).
        /// Renvoie le libellé de la plateforme de façon null-safe ;
        /// retourne une chaîne vide si la plateforme est null.
        /// </summary>
        public string NomPlateforme => Plateforme?.Libelle ?? string.Empty;

        /// <summary>
        /// Construit et assigne la référence du poste selon le format :
        /// PJ-{3 premiers caractères de l'espace}-{numéro sur 2 chiffres}
        /// </summary>
        public void SetReference(Espace espace, int numeroPoste)
        {
            Reference = $"PJ-{espace.Nom.Substring(0, 3).ToUpper()}-{numeroPoste:D3}";
        }
    }
}