using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities
{
    /// <summary>
    /// Représente une plateforme de jeu.
    /// Contient le libellé (nintendo switch par exemple... )
    /// l'ensemble des postes de jeu associés,
    /// l'ensemble des Jeux associés.
    /// </summary>
    public class Plateforme
    {
        /// <summary>
        /// Numéro.
        /// </summary>
        public int IdPlateforme { get; set; }

        /// <summary>
        /// Libellé .
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Ensemble des postes de jeu associés à cette plateforme.
        /// </summary>
        public ICollection<PosteJeu> PostesJeu { get; set; } = new List<PosteJeu>();

        /// <summary>
        /// Ensemble des jeux associés à cette plateforme.
        /// </summary>
        public ICollection<Jeu> Jeux { get; set; } = new List<Jeu>();
    }
}