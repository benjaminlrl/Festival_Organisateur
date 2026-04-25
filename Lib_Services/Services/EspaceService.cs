using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Lib_Services.Services
{
    /// <summary>
    /// Service métier responsable des opérations CRUD sur l'entité <see cref="Espace"/>.
    /// </summary>
    public class EspaceService : IEspaceService
    {
        private readonly ApplicationDbContext _context;
       
        /// <summary>
        /// Initialise une nouvelle instance de <see cref="EspaceService"/>.
        /// </summary>
        /// <param name="context">Contexte de données utilisé pour les opérations persistées.</param>
        public EspaceService(ApplicationDbContext context)
        {
            _context = context;
        }
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
        /// <param name="colonne">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Espace"/>.</returns>
        public List<Espace> Lister(string filtre = "", string colonne = "", string ordre = "")
        {
            IQueryable<Espace> query = _context.Espaces
                .Include(e => e.Tournois)
                .Include(e => e.PostesJeu);

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(e =>
                    e.Nom.Contains(filtre) ||
                    e.Description.Contains(filtre));

            query = colonne switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "Nom" => ordre == "ASC" ? query.OrderBy(e => e.Nom) : query.OrderByDescending(e => e.Nom),
                "Description" => ordre == "ASC" ? query.OrderBy(e => e.Description) : query.OrderByDescending(e => e.Description),
                "Superficie" => ordre == "ASC" ? query.OrderBy(e => e.Superficie) : query.OrderByDescending(e => e.Superficie),
                "CapaciteMaxi" => ordre == "ASC" ? query.OrderBy(e => e.CapaciteMaxi) : query.OrderByDescending(e => e.CapaciteMaxi),
                "IdEspace" => ordre == "ASC" ? query.OrderBy(e => e.IdEspace) : query.OrderByDescending(e => e.IdEspace),
                _ => query.OrderByDescending(e => e.IdEspace) // valeur par défaut
            };

            return query.ToList();
        }

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
        public List<Espace> ListerEspacesDisponibles(string filtre = "", string colonne = "Nom", string ordre = "ASC")
        {
            return Lister(filtre, colonne, ordre)
                .Where(e =>
                    e.Tournois == null 
                    || !e.Tournois.Any(t => 
                        t.Statut == "Planifié" 
                        || t.Statut == "EnCours"))
                .ToList();
        }

        /// <summary>
        /// Retourne la liste complète des espaces disponibles présents en base.
        /// Un espace est considéré comme disponible si un tournois planifié ou en cours y est associé.
        /// 
        /// Permet également de trier les résultats par une colonne spécifiée 
        ///  (Nom, Description, Superficie, CapaciteMaxi) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre"></param>
        /// <returns>Liste d'objets <see cref="Espace"/> indisponibles<returns>
        public List<Espace> ListerEspacesIndisponibles(string filtre = "", string colonne = "Nom", string ordre = "ASC")
        {
            return Lister(filtre, colonne, ordre)
                .Where(e =>
                    e.Tournois == null
                    || e.Tournois.Any(t =>
                        t.Statut == "Planifié"
                        || t.Statut == "EnCours"))
                .ToList();
        }

        /// <summary>
        /// Récupère un espace par son identifiant.
        /// </summary>
        /// <param name="idEspace">Identifiant de l'espace cherché.</param>
        /// <returns>L'entité <see cref="Espace"/> si trouvée, sinon null.</returns>
        public Espace? Obtenir(int idEspace)
        {
            // Find utilise le cache du contexte s'il existe, sinon interroge la base.
            return _context.Espaces.Find(idEspace);
        }

        public List<Espace> ObtenirParNom(string nom)
        {
            return _context.Espaces.Where(e => e.Nom.Equals(nom)).ToList();
        }
        #endregion
        #region CUD
        /// <summary>
        /// Crée un nouvel espace en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Espace"/> à créer.</param>
        public void Creer(Espace espace)
        {
            ValiderEspace(espace, false);    
            // Ajout de l'entité au contexte puis persistance immédiate.
            _context.Espaces.Add(espace);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un espace existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Espace"/>.</param>
        public void Modifier(Espace espace)
        {
            ValiderEspace(espace, true);    
            _context.Espaces.Update(espace);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un espace identifié par son identifiant s'il existe.
        /// </summary>
        /// <param name="idEspace">Identifiant de l'espace à supprimer.</param>
        public void Supprimer(int idEspace)
        {
            // Recherche de l'entité (utilise le cache si possible).
            var espace = _context.Espaces.Find(idEspace);
            if (espace != null)
            {
                _context.Espaces.Remove(espace);
                _context.SaveChanges();
            }
        }
        #endregion
        #region statistiques
        /// <summary>
        /// Retourne le nombre d'espaces disponibales en fonction du filtre.
        /// Un espace est considéré comme disponible si aucun tournoi planifié ou en cours n'est associé à cet espace.
        /// </summary>
        /// <param name="filtre">Filtre optionnel pour rechercher des espaces spécifiques.</param>
        /// <returns><see cref="int"/>Nombre d'espaces disponibles.</returns>
        public int CompterEspacesDisponibles(string filtre = "")
        {
            return Lister(filtre)
                .Count(e => 
                e.Tournois == null 
                || !e.Tournois.Any(t => 
                    t.Statut.Equals("Planifié")
                    || t.Statut.Equals("EnCours")));
        }

        /// <summary>
        /// Retourne le nombres d'espaces total en fonction du filtre.
        /// </summary>
        /// <param name="filtre">Filtre optionnel pour rechercher des espaces spécifiques.</param>
        /// <returns><see cref="int"/>Nombre total d'espaces.</returns>
        public int CompterEspacesTotal(string filtre = "")
        {
            return Lister(filtre).Count;
        }
        #endregion
        #region Validations

        /// <summary>
        /// Valide les propriétés d'une instance de <see cref="Espace"/> avant sa création ou sa modification.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Espace"/> à valider.</param>
        /// <param name="estModification">Indique si la validation est pour une modification.</param>
        /// <exception cref="EspaceException">Exception levée si une validation échoue.</exception>
        public void ValiderEspace(Espace espace, bool estModification = false)
        {
            if (string.IsNullOrWhiteSpace(espace.Nom))
                throw new EspaceException("Le nom est requis.",
                    (int)EspaceException.EspaceErreur.NomRequis);

            if(!estModification && ObtenirParNom(espace.Nom).Count > 0)
                throw new EspaceException("Le nom existe déjà.",
                    (int)EspaceException.EspaceErreur.NomExiste);

            if (string.IsNullOrWhiteSpace(espace.Description))
                throw new EspaceException("La description est requise.",
                    (int)EspaceException.EspaceErreur.DescriptionRequise);

            if (espace.Superficie < 9)
                throw new EspaceException("La superficie ne peut pas être inférieure à 9.",
                    (int)EspaceException.EspaceErreur.SuperficieInsuffisante);

            if (espace.Superficie > 60)
                throw new EspaceException("La superficie ne peut pas être supérieure à 60.",
                    (int)EspaceException.EspaceErreur.SuperficieTropGrande);

            if (espace.CapaciteMaxi < 0)
                throw new EspaceException("La capacité maximale doit être positive.",
                    (int)EspaceException.EspaceErreur.CapaciteNegative);

            if (espace.CapaciteMaxi > 50)
                throw new EspaceException("La capacité maximale ne peut pas être supérieure à 50.",
                    (int)EspaceException.EspaceErreur.CapaciteTropGrande);
        }
        #endregion
    }

}
