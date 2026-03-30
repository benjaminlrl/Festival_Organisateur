using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities
{
    public class Jeu
    {
        public enum PEGI
        {
            Pegi3 = 3,
            Pegi7 = 7,
            Pegi12 = 12,
            Pegi16 = 16,
            Pegi18 = 18
        }
        /// <summary>
        /// Numéro.
        /// </summary>
        public int IdJeu { get; set; }

        /// <summary>
        /// Titre .
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// Editeur .
        /// </summary>
        public string Editeur { get; set; }

        /// <summary>
        /// Description .
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Pegi, date minimum légale .
        /// </summary>
        public int Pegi { get; set; }

        /// <summary>
        /// Date de sortie
        /// </summary>
        public DateTime DateSortie { get; set; }

        /// <summary>
        /// Année de sortie
        /// </summary>
        public string AnneeSortie { get; set; }

        /// <summary>
        /// Ensemble des plateformes associés à ce jeu.
        /// </summary>
        public ICollection<Plateforme> Plateformes { get; set; } = new List<Plateforme>();

        /// <summary>
        /// Ensemble des Tournois associés à ce jeu.
        /// </summary>
        public ICollection<Tournoi> Tournois { get; set; } = new List<Tournoi>();

    }
}
