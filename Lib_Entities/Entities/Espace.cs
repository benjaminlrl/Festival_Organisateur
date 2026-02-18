using System.Collections.Generic;

namespace Lib_Entities.Entities
{
    /// <summary>
    /// Représente l'espace associé à un type de console.
    /// Nintendo, Xbox etc....
    /// </summary>
    public class Espace
    {
        /// <summary>
        /// Identifiant unique de l'espace (clé primaire).
        /// </summary>
        public int IdEspace { get; set; }

        /// <summary>
        /// Nom .
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Description  (caractéristiques, étage, accès...).
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Surface totale de l'espace en unités mètres carrées .
        /// </summary>
        public double Superficie { get; set; }

        /// <summary>
        /// Capacité maximale d'accueil (nombre maximal de personnes).
        /// </summary>
        public int CapaciteMaxi { get; set; }

        /// <summary>
        /// Ensemble des tournois liés à cet espace .
        /// </summary>
        public ICollection<Tournoi> Tournois { get; set; }

        /// <summary>
        /// Ensemble des postes présents dans cet espace .
        /// </summary>
        public ICollection<PosteJeu> PostesJeu { get; set; }
    }

}
