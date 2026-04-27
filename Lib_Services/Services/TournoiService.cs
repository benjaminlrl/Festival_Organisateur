using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Exceptions;
using Lib_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Lib_Services.Services
{
    /// <summary>
    /// Service métier responsable des opérations CRUD sur l'entité <see cref="Tournoi"/>.
    /// </summary>
    public class TournoiService : ITournoiService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="TournoiService"/>.
        /// <param name="context">DbContext injecté pour l'accès aux données.</param>
        /// </summary>
        public TournoiService(ApplicationDbContext context)
        {
            _context = context;
        }
        #region Lecture
        /// <summary>
        ///  Retourne la liste complète des tournois présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Nom, NbParticipants, DureePrevue, DateHeure, Statut, Espace, Jeu, NumeroTournoi) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Tournoi"/>.</returns>
        public List<Tournoi> Lister(string filtre = "", string propriete = "", string ordre = "")
        {
            IQueryable<Tournoi> query = _context.Tournois
                .Include(t => t.Espace)
                .Include(t => t.Inscriptions)
                .Include(t => t.Jeu);

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(t =>
                    t.Nom.Contains(filtre)
                    || t.NbParticipants.ToString().Contains(filtre)
                    || t.DureePrevue.ToString().Contains(filtre)
                    || t.DateHeure.ToString().Contains(filtre)
                    || t.Statut.Contains(filtre)
                    || t.Espace.Nom.Contains(filtre)
                    || t.Jeu.Titre.Contains(filtre));

            query = propriete switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "Nom" => ordre == "ASC" ? query.OrderBy(t => t.Nom) : query.OrderByDescending(t => t.Nom),
                "NbParticipants" => ordre == "ASC" ? query.OrderBy(t => t.NbParticipants) : query.OrderByDescending(t => t.NbParticipants),
                "DureePrevue" => ordre == "ASC" ? query.OrderBy(t => t.DureePrevue) : query.OrderByDescending(t => t.DureePrevue),
                "DateHeure" => ordre == "ASC" ? query.OrderBy(t => t.DateHeure) : query.OrderByDescending(t => t.DateHeure),
                "Statut" => ordre == "ASC" ? query.OrderBy(t => t.Statut) : query.OrderByDescending(t => t.Statut),
                "NomEspace" => ordre == "ASC" ? query.OrderBy(t => t.Espace.Nom) : query.OrderByDescending(t => t.Espace.Nom),
                "TitreJeu" => ordre == "ASC" ? query.OrderBy(t => t.Jeu.Titre) : query.OrderByDescending(t => t.Jeu.Titre),
                "NumeroTournoi" => ordre == "ASC" ? query.OrderBy(t => t.NumeroTournoi) : query.OrderByDescending(t => t.NumeroTournoi),
                _ => query.OrderByDescending(t => t.NumeroTournoi) // valeur par défaut
            };

            return query.ToList();
        }

        /// <summary>
        /// Retourne la liste des tournois dont le statut est "En cours" avec l'espace et le jeu associé chargé.
        /// </summary>
        /// <param name="idEspace">Id de l'espace</param>
        /// <returns>Les tournois en cours.</returns>
        public List<Tournoi> ListerTournoisEnCoursEspace(int idEspace)
        {
            return _context.Tournois
                .Include(t => t.Espace)
                .Include(t => t.Jeu)
                .Where(t => t.Statut == "En cours" && t.IdEspace == idEspace)
                .ToList();
        }

        /// <summary>
        /// Retourne la liste des tournois dont le statut est "Planifié" avec l'espace et le jeu associé chargé.
        /// </summary>
        /// <param name="idEspace">Id de l'espace</param>
        /// <returns>Les tournois planifiés.</returns>
        public List<Tournoi> ListerTournoisPlanifiesEspace(int idEspace)
        {
            return _context.Tournois
                .Include(t => t.Espace)
                .Include(t => t.Jeu)
                .Where(t => t.Statut == "Planifié" && t.IdEspace == idEspace)                
                .ToList();
        }

        /// <summary>
        /// Retourne la liste des tournois dont le statut est "Terminé" avec l'espace et le jeu associé chargé.
        /// </summary>
        /// <param name="idEspace">Id de l'espace</param>
        /// <returns></returns>
        public List<Tournoi> ListerTournoisTerminesEspace(int idEspace)
        {
            return _context.Tournois
                .Include(t => t.Espace)
                .Include(t => t.Jeu)
                .Where(t => t.Statut == "Terminé" && t.IdEspace == idEspace)                
                .ToList();
        }

        public List<Tournoi> ObtenirParNom(string nomEspace)
        {
            return _context.Tournois
                .Include(t => t.Espace)
                .Include(t => t.Jeu)
                .Where(t => t.Nom.Equals(nomEspace))
                .ToList();
        }

        /// <summary>
        /// Récupère un tournoi par son identifiant avec l'espace associé.
        /// Retourne null si aucun tournoi n'est trouvé.
        /// </summary>
        /// <param name="numeroTournoi">Identifiant du tournoi.</param>
        /// <returns>Instance <see cref="Tournoi"/> ou null.</returns>
        public Tournoi? Obtenir(int numeroTournoi)
        {
            // Utilisation de FirstOrDefault avec Include pour obtenir l'entité complète.
            return _context.Tournois
                           .Include(t => t.Espace)
                           .AsNoTracking()
                           .FirstOrDefault(t => t.NumeroTournoi == numeroTournoi);
        }
        #endregion  
        #region CUD
        /// <summary>
        /// Crée un nouveau tournoi en base après validation métier minimale.
        /// Lance une <see cref="ArgumentException"/> si le nombre de participants est invalide.
        /// </summary>
        /// <param name="tournoi">Instance du tournoi à créer.</param>
        public void Creer(Tournoi tournoi)
        {
            ValiderTournoi(tournoi, false);
            // Ajout et sauvegarde immédiate. 
            _context.Tournois.Add(tournoi);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un tournoi existant en base.
        /// </summary>
        /// <param name="tournoi">Instance modifiée du tournoi</param>
        public void Modifier(Tournoi tournoi)
        {
            try
            {
                ValiderTournoi(tournoi, true);
                _context.Tournois.Update(tournoi);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new TournoiException("Erreur lors de la modification du tournoi.\n" + ex.Message,
                    (int)TournoiException.TournoiErreur.ModificationTournoiDbUpdateException);
            }
            catch (Exception ex)
            {
                throw new TournoiException(ex.Message,
                    (int)TournoiException.TournoiErreur.ModificationTournoiException);
            }
        }

        /// <summary>
        /// Supprime un tournoi identifié par son numéro si présent en base.
        /// </summary>
        /// <param name="numeroTournoi">Identifiant du tournoi à supprimer.</param>
        public void Supprimer(int numeroTournoi)
        {
            // Find utilise le cache du contexte si l'entité est déjà suivie.
            Tournoi? tournoi = _context.Tournois.Find(numeroTournoi);

            try
            {
                ValiderSuppressionTournoi(tournoi);
                _context.Tournois.Remove(tournoi);
                _context.SaveChanges();
            }
            catch (DbException ex)
            {
                throw new TournoiException("Erreur lors de la suppression du tournoi : \n" + ex.Message,
                    (int)TournoiException.TournoiErreur.SuppressionTournoiDbException);
            }
            catch (Exception ex)
            {
                throw new TournoiException("Une erreur est survenue lors de la suppression du tournoi : \n" + ex.Message,
                    (int)TournoiException.TournoiErreur.SuppressionTournoiException);
            }
        }
        #endregion
        #region validations
        private bool ValiderHoraire(DateTime dateHeure)
        {
            var jour = dateHeure.DayOfWeek; // Lundi, Mardi...
            TimeSpan horaire = dateHeure.TimeOfDay;

            // Horaires variables selon le jour
            if (jour == DayOfWeek.Saturday)
            {
                if (horaire < TimeSpan.FromHours(10) || horaire > TimeSpan.FromHours(20))
                    return false;
            }
            else if (jour == DayOfWeek.Sunday)
            {
                if (horaire < TimeSpan.FromHours(10) || horaire > TimeSpan.FromHours(18))
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Permet de valider les données d'un tournoi avant création ou modification.
        /// </summary>
        /// <param name="tournoi">Tournoi à valider</param>
        /// <param name="estModification">Indique si c'est une modification ou une création</param>
        /// <exception cref="TournoiException">Exception si les données du tournoi sont invalides</exception>
        public void ValiderTournoi(Tournoi? tournoi, bool estModification = false)
        {
            if (tournoi == null)
                throw new TournoiException("Le tournoi est requis.",
                    (int)TournoiException.TournoiErreur.TournoiNull);

            if (string.IsNullOrWhiteSpace(tournoi.Nom))
                throw new TournoiException("Le nom est requis.",
                    (int)TournoiException.TournoiErreur.TournoiNomRequis);

            List<Tournoi> tournoiBdd = ObtenirParNom(tournoi.Nom);

            if (tournoiBdd.Count > 0 && 
                (!estModification || tournoiBdd.Any(t => t.NumeroTournoi != tournoi.NumeroTournoi)))
                throw new TournoiException("Un tournoi avec ce nom existe déjà.",
                    (int)TournoiException.TournoiErreur.TournoiNomExiste);

            if (tournoi.IdJeu <= 0)
                throw new TournoiException("Un jeu est requis.",
                    (int)TournoiException.TournoiErreur.TournoiJeuRequis);

            if (tournoi.IdEspace <= 0)
                throw new TournoiException("Un espace est requis.",
                    (int)TournoiException.TournoiErreur.TournoiEspaceRequis);

            if (tournoi.NbParticipants <= 0)
                throw new TournoiException("Le nombre de participants doit être supérieur à zéro.",
                    (int)TournoiException.TournoiErreur.TournoiNbParticipantsInvalide);

            if (tournoi.DureePrevue <= 0)
                throw new TournoiException("La durée prévue doit être supérieure à zéro.",
                    (int)TournoiException.TournoiErreur.TournoiDureeInvalide);

            if (string.IsNullOrWhiteSpace(tournoi.Statut))
                throw new TournoiException("Le tournoi doit avoir un statut défini.",
                    (int)TournoiException.TournoiErreur.TournoiStatutRequis);

            if (Lister("").Any(t => t.NumeroTournoi != tournoi.NumeroTournoi
                                && t.IdEspace == tournoi.IdEspace
                                && ((t.Statut == "En cours" && tournoi.Statut == "En cours")
                                    || (tournoi.DateHeure >= t.DateHeure
                                        && tournoi.DateHeure <= t.DateHeure.AddMinutes(t.DureePrevue)))))
                throw new TournoiException("Un autre tournoi est déjà en cours à cette période.",
                    (int)TournoiException.TournoiErreur.TournoiConflitHoraire);

            if (!ValiderHoraire(tournoi.DateHeure))
                throw new TournoiException("Les horaires ne sont pas valides.\nSamedi : 10h - 20h\nDimanche : 10h - 18h",
                    (int)TournoiException.TournoiErreur.TournoiHoraireInvalide);

            if (tournoi.DateHeure < DateTime.Now && !estModification)
                throw new TournoiException("La date et l'heure du tournoi doivent être dans le futur.",
                    (int)TournoiException.TournoiErreur.TournoiAjoutHorairePassee);

            if (tournoi.NbParticipants < tournoi.NbParticipantsInscrits)
                throw new TournoiException("Le nombre de participants maximum ne peut pas être inférieur au nombre de participants déjà inscrits.",
                    (int)TournoiException.TournoiErreur.TournoiNbParticipantsInscrits);

            if (estModification)
            {
                Tournoi? enBdd = Obtenir(tournoi.NumeroTournoi);

                if(enBdd == null)
                    throw new TournoiException("Tournoi inexistant en base de donnée.",
                        (int)TournoiException.TournoiErreur.ModificationTournoiInexistantDb);

                if(enBdd.IdEspace == tournoi.IdEspace
                    && enBdd.DateHeure == tournoi.DateHeure
                    && enBdd.DureePrevue == tournoi.DureePrevue
                    && enBdd.Statut == tournoi.Statut
                    && enBdd.IdJeu == tournoi.IdJeu
                    && enBdd.IdEspace == tournoi.IdEspace
                    && enBdd.NbParticipants ==  tournoi.NbParticipants)
                    throw new TournoiException("Aucune modification sur le tournoi détéctée",
                        (int)TournoiException.TournoiErreur.ModificationTournoiAucuneModification);

                if (enBdd.NumeroTournoi != tournoi.NumeroTournoi)
                    throw new TournoiException("Le numéro d'un tournoi ne peut pas être modifié.",
                        (int)TournoiException.TournoiErreur.ModificationTournoiNumero);

                if (enBdd.IdJeu != tournoi.IdJeu)
                    throw new TournoiException("Le jeu d'un tournoi ne peut pas être modifié.",
                        (int)TournoiException.TournoiErreur.ModificationTournoiJeu);

                if(enBdd.Statut == "Terminé" && tournoi.Statut != "Terminé")
                    throw new TournoiException("Le statut d'un tournoi terminé ne peut pas être modifié.",
                        (int)TournoiException.TournoiErreur.ModificationTournoiStatutTermineModifier);

                if (enBdd.Statut == "En cours" && tournoi.Statut != "En cours")
                    throw new TournoiException("Le statut d'un tournoi en cours ne peut pas être modifié.",
                        (int)TournoiException.TournoiErreur.ModificationTournoiStatutEncoursModifier);
                
            }

        }

        public void ValiderSuppressionTournoi(Tournoi? tournoi)
        {
            if (tournoi == null)
                throw new TournoiException("Le tournoi ne peut pas être null.",
                    (int)TournoiException.TournoiErreur.TournoiNull);

            if (tournoi.NbParticipantsInscrits > 0)            
                throw new TournoiException("Il n'est pas possible de supprimer un tournoi avec des participants inscrits.",
                    (int)TournoiException.TournoiErreur.SuppressionTournoiParticipantsExistant);        
        }


        #endregion
    }
}

