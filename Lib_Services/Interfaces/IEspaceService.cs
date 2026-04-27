using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IEspaceService
    {
        #region Lecture
        /// <summary>
        ///  Retourne la liste complète des espaces présents en base, 
        ///  avec possibilité de filtrer par nom ou description.
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Nom, Description, Superficie, CapaciteMaxi) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <returns>Liste d'objets <see cref="Espace"/>.</returns>
        List<Espace> Lister(string filtre = "", string colonne = "", string ordre = "");

        /// <summary>
        /// Retourne la liste complète des espaces disponibles présents en base.
        /// Un espace est considéré comme disponible si aucun tournois planifié ou en cours y est associé.
        /// 
        /// Permet également de trier les résultats par une colonne spécifiée 
        ///  (Nom, Description, Superficie, CapaciteMaxi) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre"></param>
        /// <returns>Liste d'objets <see cref="Espace"/> disponibles</returns>
        List<Espace> ListerEspacesDisponibles(string filtre = "", string colonne = "", string ordre = "");

        /// <summary>
        /// Retourne la liste complète des espaces disponibles présents en base.
        /// Un espace est considéré comme disponible si un tournois planifié ou en cours y est associé.
        /// 
        /// Permet également de trier les résultats par une colonne spécifiée 
        ///  (Nom, Description, Superficie, CapaciteMaxi) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Contenu dans toutes le sproprietes de l'entite</param>
        /// <param name="propriete">Propriete sur la quelle on veut trier l'ordre</param>
        /// <param name="ordre">Ordre ASC ou DESC</param>
        /// <returns>Liste d'objets <see cref="Espace"/>indisponibles</returns>
        List<Espace> ListerEspacesIndisponibles(string filtre = "", string propriete = "", string ordre = "");
       
        /// <summary>
        /// Récupère un espace par son identifiant.
        /// </summary>
        /// <param name="idEspace">Identifiant de l'espace cherché.</param>
        /// <returns>L'entité <see cref="Espace"/> si trouvée, sinon null.</returns>
        Espace? Obtenir(int idEspace);

        /// <summary>
        /// Récupère un espace par son nom.
        /// </summary>
        /// <param name="nomEspace">Nom de l'espace cherché.</param>
        /// <returns>L'entité <see cref="Espace"/> si trouvée, sinon null.</returns>
        Espace? ObtenirParNom(string nomEspace);

        /// <summary>
        /// Récupère un espace si les 3 premières lettres de son nom correspondent à celles fournies en paramètre.
        /// </summary>
        /// <param name="nom">Les 3 premières lettres du nom de l'espace.</param>
        /// <returns>L'entité <see cref="Espace"/> si trouvée, sinon null.</returns>
        public Espace? ObtenirParNomPremieresLettres(string nom);
        #endregion

        #region CUD
        /// <summary>
        /// Crée un nouvel espace en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Espace"/> à créer.</param>
        void Creer(Espace espace);

        /// <summary>
        /// Met à jour un espace existant.
        /// 
        /// Si le nom de l'espace est modifié et que <paramref name="modifPosteJeu"/> est à true,
        /// les postes de jeu associés à cet espace seront également mis à jour pour refléter le nouveau nom de l'espace.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Espace"/>.</param>
        /// <param name="modifPosteJeu">Indique si la modification concerne les postes de jeu associés à l'espace.</param>
        /// <exception cref="EspaceException">Exception levée si la validation échoue ou si une erreur survient lors de la
        /// modification des postes de jeu associés.</exception>
        void Modifier(Espace espace, bool modifPosteJeu = false);

        /// <summary>
        /// Supprime un espace identifié par son identifiant s'il existe.
        /// </summary>
        /// <param name="idEspace">Identifiant de l'espace à supprimer.</param>
        /// <param name="suppPosteJeu">Indique si la suppression concerne également les postes de jeu associés à l'espace.</param>
        void Supprimer(int idEspace, bool suppPosteJeu = false);
        #endregion

        #region Validations 
        /// <summary>
        /// Permet de vérifier les propriétés associés a un espace.
        /// </summary>
        /// <param name="espace">L'esapce à valider</param>
        /// <param name="estModification">Indique si la validation concerne une modification existante.</param>
        /// <param name="modifPosteJeu">Indique si la validation concerne une modification des postes de jeu associés.</param>
        /// <returns>Liste de <see cref="string"/> correspondants aux erreurs, ou vide</returns>
        void ValiderEspace(Espace espace, bool estModification = false, bool modifPosteJeu = false);

        /// <summary>
        /// Permet de vérifier les propriétés associés a un espace.
        /// </summary>
        /// <param name="espace">L'esapce à valider</param>
        /// <param name="suppPosteJeu">Indique si la validation mdofie égalementy les postes de jeu associés.</param>
        /// <returns>Liste de <see cref="string"/> correspondants aux erreurs, ou vide</returns>
        void ValiderSuppressionEspace(Espace espace, bool suppPosteJeu = false);
        #endregion

        #region Statistiques

        /// <summary>
        /// Retourne le nombre d'espaces disponibales en fonction du filtre.
        /// Un espace est considéré comme disponible si aucun tournoi planifié ou en cours n'est associé à cet espace.
        /// </summary>
        /// <param name="filtre">Filtre optionnel pour rechercher des espaces spécifiques.</param>
        /// <returns><see cref="int"/>Nombre d'espaces disponibles.</returns>
        int CompterEspacesDisponibles(string filtre);

        /// <summary>
        /// Retourne le nombres d'espaces total en fonction du filtre.
        /// </summary>
        /// <param name="filtre">Filtre optionnel pour rechercher des espaces spécifiques.</param>
        /// <returns><see cref="int"/>Nombre total d'espaces.</returns>
        public int CompterEspacesTotal(string filtre);
        #endregion        
    }
}
