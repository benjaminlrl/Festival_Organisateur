using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Lib_Entities.Entities.Jeu;

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

        /// <summary>
        /// Retourne la liste complète des tournois avec l'espace et le jeu associé chargé.
        /// </summary>
        /// <returns>Liste des tournois.</returns>
        /// <param name="filtre">Optionnel : filtre .</param>
        public List<Tournoi> Lister(string filtre = "")
        {
            // Include(t => t.Espace) pour éviter le chargement paresseux lors de l'affichage.
            if (string.IsNullOrWhiteSpace(filtre))
                return _context.Tournois
                    .Include(t => t.Espace)
                    .Include(t => t.Jeu)
                    .ToList();
            return _context.Tournois
                    .Where(t => t.Nom.Contains(filtre)
                        || t.NbParticipants.ToString().Contains(filtre)
                        || t.DureePrevue.ToString().Contains(filtre)
                        || t.DateHeure.ToString().Contains(filtre)
                        || t.Statut.Contains(filtre)
                        || t.Espace.Nom.Contains(filtre)
                        || t.Jeu.Titre.Contains(filtre))
                    .Include(t => t.Espace)
                    .Include(t => t.Jeu)
                    .ToList();
        }

        /// <summary>
        /// Crée un nouveau tournoi en base après validation métier minimale.
        /// Lance une <see cref="ArgumentException"/> si le nombre de participants est invalide.
        /// </summary>
        /// <param name="tournoi">Instance du tournoi à créer.</param>
        public void Creer(Tournoi tournoi)
        {
            // Validation métier élémentaire : le nombre de participants doit être strictement positif.
            if (tournoi.NbParticipants <= 0)
                throw new ArgumentException("Participants invalides");

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
            // Update attache l'entité et marque toutes les propriétés comme modifiées.
            _context.Tournois.Update(tournoi);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un tournoi identifié par son numéro si présent en base.
        /// </summary>
        /// <param name="numeroTournoi">Identifiant du tournoi à supprimer.</param>
        public void Supprimer(int numeroTournoi)
        {
            // Find utilise le cache du contexte si l'entité est déjà suivie.
            var tournoi = _context.Tournois.Find(numeroTournoi);
            if (tournoi != null)
            {
                _context.Tournois.Remove(tournoi);
                _context.SaveChanges();
            }
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
                           .FirstOrDefault(t => t.NumeroTournoi == numeroTournoi);
        }

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
        /// Permet de vérifier les propriétés associés a un jeu.
        /// </summary>
        /// <param name="jeu">Le jeu à valider</param>
        /// <returns></returns>
        public List<string> ValiderTournoi(Tournoi tournoi)
        {
            // liste des erreurs
            var erreurs = new List<string>();

            if (string.IsNullOrWhiteSpace(tournoi.Nom))
                erreurs.Add("Le nom est requis.");

            if (string.IsNullOrWhiteSpace(tournoi.TitreJeu))
                erreurs.Add("Un jeu est requis.");

            if (string.IsNullOrWhiteSpace(tournoi.NomEspace))
                erreurs.Add("Un espace est requis.");

            if (tournoi.NbParticipants < 0)
                erreurs.Add("Le nombre de participants ne doit pas être inférieur à zéro.");

            if (tournoi.Statut == null)
                erreurs.Add("Le tournoi dois avoir un statut défini.");

            // Deux tournois sont en cours en même temps si :
            // - Leurs date et heure de début sont égales
            // - La date et heure de début d'un tournoi est comprise entre le début et la fin d'un autre tournoi
            if (Lister("").Any(t => t.DateHeure == tournoi.DateHeure 
                            || (tournoi.DateHeure >= t.DateHeure 
                                && tournoi.DateHeure <= t.DateHeure.AddMinutes(t.DureePrevue))))
                erreurs.Add("Un autre tournoi est déjà en cours à cette période.");

            if (!ValiderHoraire(tournoi.DateHeure))
                erreurs.Add("Les horraires ne sont pas valides. \nSamedi : 10h - 20h\nDimanche : 10h - 18h");


            return erreurs;
        }
    }
}

