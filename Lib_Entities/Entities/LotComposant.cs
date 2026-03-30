using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Entities.Entities
{
    /// <summary>
    /// Représente un composant d'un lot .
    /// Chaque composant dispose d'un libelle,
    /// d'une description, d'une valeur,
    /// d'un id de lot auquel il est associé et d'un id de composant
    /// </summary>
    public class LotComposant
    {
        /// <summary>
        /// Libelle du composant
        /// </summary>
        public int Libelle { get; set; }

        /// <summary>
        /// Description du composant
        /// </summary>
        public int Description { get; set; }

        /// <summary>
        /// Valeur du composant
        /// </summary>
        public int Valeur { get; set; }

        /// <summary>
        /// Numéro du lot auquel il est associé
        /// </summary>
        public int NumeroLot { get; set; }

        /// <summary>
        /// Lot auquel il est associé
        /// </summary>
        public Lot Lot { get; set; }

        /// <summary>
        /// Numero du composant
        /// </summary>
        public int Numero { get; set; }
    }
}
