using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities
{
    /// <summary>
    /// Représente un composant d'un lot .
    /// Chaque composant dispose d'un libelle,
    /// d'une description, d'une valeur,
    /// d'un id de lot auquel il est associé et d'un id de composant (nullable)
    /// </summary>
    public class LotComposant
    {
        /// <summary>
        /// Libelle du composant
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Description du composant
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Valeur (en euros) du composant
        /// </summary>
        public int Valeur { get; set; }

        /// <summary>
        /// Numero du composant
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Numéro du lot auquel il est associé (nullable)
        /// </summary>
        public int? NumeroLot { get; set; }

        /// <summary>
        /// Lot auquel il est associé (nullable)
        /// </summary>
        public Lot? Lot { get; set; }

        /// <summary>
        /// Propriété récupérée utilisée pour l'affichage (DataGridView).
        /// Renvoie le nom de Lot de façon null-safe ;
        /// retourne chaîne vide si le Lot est null.
        /// </summary>
        public string NomLot => Lot?.Libelle ?? string.Empty;
    }
}
