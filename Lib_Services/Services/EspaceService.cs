using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Transactions;
using static System.Net.WebRequestMethods;

namespace Lib_Services.Services
{
    /// <summary>
    /// Service métier responsable des opérations CRUD sur l'entité <see cref="Espace"/>.
    /// </summary>
    public class EspaceService : IEspaceService
    {
        private readonly ApplicationDbContext _context;
        private IPosteJeuService? _posteJeuService;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="EspaceService"/>.
        /// </summary>
        /// <param name="context">Contexte de données utilisé pour les opérations persistées.</param>
        public EspaceService(ApplicationDbContext context)
        {
            _context = context;
            _posteJeuService = null;
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
                .AsNoTracking()
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
            // Find utilise le cache du contexte s'il existe, sinon interroge la base
            //return _context.Espaces.Find(idEspace);
            return _context.Espaces.AsNoTracking()
                .Include(e => e.Tournois)
                .Include(e => e.PostesJeu)
                .FirstOrDefault(e => e.IdEspace == idEspace);
        }

        /// <summary>
        /// Récupère un espace si son nom correspond à celui fourni en paramètre.
        /// </summary>
        /// <param name="nom">Nom de l'espace.</param>
        /// <returns>L'entité <see cref="Espace"/> si trouvée, sinon null.</returns>
        public Espace? ObtenirParNom(string nom)
        {
            return _context.Espaces.AsNoTracking().FirstOrDefault(e => e.Nom.Equals(nom));
        }

        /// <summary>
        /// Récupère un espace si les 3 premières lettres de son nom correspondent à celles fournies en paramètre.
        /// </summary>
        /// <param name="nom">Le nom de l'espace.</param>
        /// <returns>L'entité <see cref="Espace"/> si trouvée, sinon null.</returns>
        public Espace? ObtenirParNomPremieresLettres(string nom)
        {
            return _context.Espaces.AsNoTracking().FirstOrDefault(e => 
                e.Nom.Substring(0,3).ToUpper().Contains(nom.Substring(0,3).ToUpper()));
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
            ValiderEspace(espace);
            _context.Espaces.Add(espace!);
            _context.SaveChanges();
  
        }

        /// <summary>
        /// Met à jour un espace existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Espace"/>.</param>
        /// <param name="modifPosteJeu">Indique si la modification concerne les postes de jeu associés à l'espace.</param>
        /// <exception cref="EspaceException">Exception levée si la validation échoue ou si une erreur survient lors de la
        /// modification des postes de jeu associés.</exception>
        public void Modifier(Espace espace, bool modifPosteJeu = false)
        {
            IDbContextTransaction transaction = _context.Database.BeginTransaction();

            try
            {
                // Charger l'espace AVEC tracking + ses postes
                Espace? enBdd = _context.Espaces
                    .Include(e => e.PostesJeu)
                    .FirstOrDefault(e => e.IdEspace == espace.IdEspace);

                // Validation métier
                ValiderEspace(espace, true, modifPosteJeu);

                // Mise à jour des propriétés simples sans passer par le update qui
                // lui créer une nouvelle entité et créer un conflit de tracking
                enBdd!.Nom = espace.Nom;
                enBdd!.Description = espace.Description;
                enBdd!.Superficie = espace.Superficie;
                enBdd!.CapaciteMaxi = espace.CapaciteMaxi;

                // 4. Mise à jour des références des postes (SANS SaveChanges)
                if (modifPosteJeu && enBdd.PostesJeu != null)
                { 
                    if (enBdd.PostesJeu.Count > 0)
                    {
                        _posteJeuService ??= new PosteJeuService(_context);

                        try
                        {
                            _posteJeuService.FormatRefPosteJeuEspaceNouvNom(
                                enBdd.PostesJeu.ToList(),
                                enBdd.Nom
                            );
                        }
                        catch (PosteJeuException ex)
                        {
                            throw new EspaceException(
                                "Erreur lors de la modification des postes de jeu associés : \n" + ex.Message,
                                (int)EspaceException.EspaceErreur.ModificationEspacePosteJeuEspaceNom);
                        }
                    }
                    else
                        throw new EspaceException(
                           "Erreur lors de la modification des postes de jeu associés : \n",
                           (int)EspaceException.EspaceErreur.ModificationEspaceAucunPosteJeu);
                }            

                // Une seule sauvegarde pour toutes les modifs (transaction atomique)
                _context.SaveChanges();

                transaction.Commit();
                
            }
            catch (EspaceException)
            {
                transaction.Rollback();
                throw;
            }
            catch (DbUpdateException ex)
            {
                transaction.Rollback();
                throw new DbUpdateException("Erreur BDD : " + ex.Message);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erreur inattendue : " + ex.Message);
            }
        }

        /// <summary>
        /// Supprime un espace de la base de données.
        /// Vérifie d'abord que l'espace existe 
        /// et qu'il n'est pas associé à des tournois planifiés ou en cours, 
        /// ni à des postes de jeu (sauf si spécifié).
        /// </summary>
        /// <param name="idEspace">Identifiant de l'espace à supprimer.</param>
        /// <param name="suppPosteJeu">Indique si la suppression concerne également les postes de jeu associés à l'espace.</param>
        /// <exception cref="EspaceException">Exception levée si la validation échoue ou si une erreur survient lors de la suppression.</exception>
        public void Supprimer(int idEspace, bool suppPosteJeu = false)
        {
            IDbContextTransaction transaction = _context.Database.BeginTransaction();

            try
            {
                // Charger l'espace AVEC tracking + ses postes
                Espace? enBdd = Obtenir(idEspace);

                // Validation métier
                ValiderSuppressionEspace(enBdd, suppPosteJeu);


                // 4. Mise à jour des références des postes (SANS SaveChanges)
                if (suppPosteJeu && enBdd!.PostesJeu != null)
                {
                    if (enBdd.PostesJeu.Count > 0)
                    {
                        _posteJeuService ??= new PosteJeuService(_context);
                        
                        try
                        {
                            foreach (PosteJeu posteJeu in enBdd.PostesJeu)
                                _posteJeuService.Supprimer(posteJeu.NumeroPoste);
                        }
                        catch (PosteJeuException ex)
                        {
                            throw new EspaceException(
                                "Erreur lors de la suppression des postes de jeu associés : \n" + ex.Message,
                                (int)EspaceException.EspaceErreur.SuppressionEspacePosteJeuErreur);
                        }
                    }
                    else
                        throw new EspaceException(
                           "Erreur lors de la suppressions des postes de jeu associés : \n",
                           (int)EspaceException.EspaceErreur.SuppressionEspaceAucunPosteJeu);
                }
                _context.Remove(enBdd!);
                // Une seule sauvegarde pour toutes les modifs (transaction atomique)
                _context.SaveChanges();

                transaction.Commit();

            }
            catch (EspaceException)
            {
                transaction.Rollback();
                throw;
            }
            catch (DbUpdateException ex)
            {
                transaction.Rollback();
                throw new DbUpdateException("Erreur BDD : " + ex.Message);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erreur inattendue : " + ex.Message);
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
        /// <param name="modifPosteJeu">Indique si la validation concerne une modification des postes de jeu associés.</param>
        /// <exception cref="EspaceException">Exception levée si une validation échoue.</exception>
        public void ValiderEspace(Espace espace, bool estModification = false, bool modifPosteJeu = false)
        {
            if (espace == null)
                throw new EspaceException("L'espace ne peut pas être null.",
                    (int)EspaceException.EspaceErreur.EspaceNull);

            Espace? enBdd = Obtenir(espace.IdEspace);
            Espace? espaceNom = ObtenirParNom(espace.Nom);
            Espace? espaceNomLet = ObtenirParNomPremieresLettres(espace.Nom);

            if (modifPosteJeu && enBdd == null)
                throw new EspaceException("L'espace n'existe pas en base de données'.",
                    (int)EspaceException.EspaceErreur.EspaceInexistant);

            if (string.IsNullOrWhiteSpace(espace.Nom))
                throw new EspaceException("Le nom est requis.",
                    (int)EspaceException.EspaceErreur.EspaceNomRequis);

            if (espaceNom != null && espaceNom.IdEspace != espace.IdEspace)
                throw new EspaceException("Le nom est déjà attribué à un autre espace.",
                    (int)EspaceException.EspaceErreur.EspaceNomExiste);

            // Le formattage de la reference des postes de jeu s'appuie sur les trois premières lettres de l'espace.
            if (espaceNomLet != null
                && espaceNomLet.IdEspace != espace.IdEspace 
                && espaceNomLet.Nom.Substring(0,3) == espace.Nom.Substring(0, 3))
                throw new EspaceException("Le formattage de la reference des postes de jeu s'appuie sur les trois premières lettres de l'espace.\n" +
                    "Un autre espace a déjà ces trois lettre.",
                    (int)EspaceException.EspaceErreur.EspaceNomExistePostesJeu);

            if (string.IsNullOrWhiteSpace(espace.Description))
                throw new EspaceException("La description est requise.",
                    (int)EspaceException.EspaceErreur.EspaceDescriptionRequise);

            if (espace.Superficie < 9)
                throw new EspaceException("La superficie ne peut pas être inférieure à 9.",
                    (int)EspaceException.EspaceErreur.EspaceSuperficieInsuffisante);

            if (espace.Superficie > 60)
                throw new EspaceException("La superficie ne peut pas être supérieure à 60.",
                    (int)EspaceException.EspaceErreur.EspaceSuperficieTropGrande);

            if (espace.CapaciteMaxi < 0)
                throw new EspaceException("La capacité maximale doit être positive.",
                    (int)EspaceException.EspaceErreur.EspaceCapaciteNegative);

            if (espace.CapaciteMaxi > 50)
                throw new EspaceException("La capacité maximale ne peut pas être supérieure à 50.",
                    (int)EspaceException.EspaceErreur.EspaceCapaciteTropGrande);

            if (estModification)
            {
                if (enBdd.IdEspace != espace.IdEspace)
                    throw new EspaceException("Il n'est pas possible de modifier l'id de l'espace.",
                        (int)EspaceException.EspaceErreur.ModificationEspaceId);

                if (enBdd.Nom ==  espace.Nom
                    && enBdd.Description == espace.Description
                    && enBdd.Superficie == espace.Superficie
                    && enBdd.CapaciteMaxi == espace.CapaciteMaxi)
                    throw new EspaceException("Aucune modification détectée.",
                        (int)EspaceException.EspaceErreur.ModificationEspaceAucune);

                // Le formattage de la reference des postes de jeu s'appuie sur les trois premières lettres de l'espace.
                // On vérifie donc si la séquence de Lettre existe ou pas
                if (enBdd.Nom != espace.Nom
                    && !modifPosteJeu)
                    throw new EspaceException("Le formattage de la reference des postes de jeu s'appuie sur les trois premières lettres de l'espace.\n",
                        (int)EspaceException.EspaceErreur.ModificationEspaceNomLettresExistePostesJeu);
            }                      
        }

        /// <summary>
        /// Valide les propriétés d'une instance de <see cref="Espace"/> peut être supprimer ou non.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Espace"/> à valider.</param>
        /// <param name="suppPosteJeu">Indique si la validation concerne une suppression des postes de jeu associés.</param>
        /// <exception cref="EspaceException">Exception levée si une validation échoue.</exception>
        public void ValiderSuppressionEspace(Espace? espace, bool suppPosteJeu = false)
        {
            if (espace == null)
                throw new EspaceException("L'espace ne peut pas être null.",
                    (int)EspaceException.EspaceErreur.EspaceNull);

            if (Obtenir(espace.IdEspace) == null)
                throw new EspaceException("L'espace n'existe pas en base de données'.",
                    (int)EspaceException.EspaceErreur.EspaceInexistant);

            if (espace.Tournois != null && espace.Tournois.Any(t => t.Statut == "Planifié" || t.Statut == "En cours"))
                throw new EspaceException("Il n'est pas possible de supprimer un espace associé à un tournoi planifié ou en cours.",
                    (int)EspaceException.EspaceErreur.SuppressionEspaceTournoiExistant);

            if (!suppPosteJeu && espace.PostesJeu.Count > 0)
                throw new EspaceException("Il n'est pas possible de supprimer un espace associé à des postes de jeu.",
                    (int)EspaceException.EspaceErreur.SuppressionEspacePosteJeuExistant);

        }
        #endregion
    }

}
