using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Services
{
    /// <summary>
    /// Service métier responsable des opérations CRUD sur l'entité <see cref="Participer"/>.
    /// </summary>
    public class ParticiperService : IParticiperService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITournoiService _tournoiService;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="ParticiperService"/>.
        /// </summary>
        /// <param name="context">Contexte de données utilisé pour les opérations persistées.</param>
        public ParticiperService(ApplicationDbContext context)
        {
            _context = context;
            _tournoiService = new TournoiService(_context);
        }

        /// <summary>
        /// Retourne la liste complète des Participer présents en base.
        /// Exécute immédiatement la requête via <c>ToList()</c>.
        /// </summary>
        /// <param name="filtre">Optionnel : libellé à filtrer.</param>
        /// <returns>Liste d'objets <see cref="Participer"/>.</returns>
        public List<Participer> Lister(string filtre = "")
        {
            // Include(t => t.Role) pour éviter le chargement paresseux lors de l'affichage.
            return
                _context.Participer
                .Include(p => p.Tournoi)
                .Where(p => p.NumeroTournoi.ToString().Contains(filtre)
                    || p.NumeroTournoi.ToString().Contains(filtre)
                    || p.Rang.ToString().Contains(filtre)
                    || (p.Commentaire ?? "").Contains(filtre)
                    || p.DateHeureInscription.ToString().Contains(filtre))
                .ToList();
        }

        /// <summary>
        /// Récupère un Participant par son id et son numéro de tournoi.
        /// </summary>
        /// <param name="Login">Login de l'Participer cherché.</param>
        /// <returns>L'entité <see cref="Participer"/> si trouvée, sinon null.</returns>
        public Participer? Obtenir(int idUser, int numeroTournoi)
        {
            return _context.Participer
                           .Include(p => p.Tournoi)
                           .FirstOrDefault(p => p.IdUser == idUser && p.NumeroTournoi == numeroTournoi);
        }

        /// <summary>
        /// Crée un nouvel Participer en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Participer"/> à créer.</param>
        public void Creer(Participer Participer)
        {
            // Ajout de l'entité au contexte puis persistance immédiate.
            _context.Participer.Add(Participer);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un Participant existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Participer"/>.</param>
        public void Modifier(Participer Participer)
        {
            _context.Participer.Update(Participer);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un Participant identifié par son id et son tournoi associé s'il existe.
        /// </summary>
        /// <param name="idUser">Id unique de l'utilisateur à supprimer.</param>
        /// <param name="numeroTournoi">Numero du tournoi associé à la participation à supprimer.</param>
        public void Supprimer(int idUser, int numeroTournoi)
        {
            // Recherche de l'entité (utilise le cache si possible).
            var Participer = _context.Participer.Find(idUser, numeroTournoi);
            if (Participer != null)
            {
                _context.Participer.Remove(Participer);
                _context.SaveChanges();
            }
        }

        #region statistiques
        /// <summary>
        /// Permet de récupérer le podium Par tournoi
        /// </summary>
        /// <param name="numeroTournoi"></param>
        /// <returns></returns>
        public List<Participer> ObtenirTop10ParTournoi(int numeroTournoi)
        {
            return _context.Participer
                .Include(p => p.Tournoi)
                .Where(p => p.NumeroTournoi == numeroTournoi)
                .OrderByDescending(p => p.ScoreFinal)
                .ThenBy(p => p.Rang)
                .Take(10)
                .ToList();
        }

        /// <summary>
        /// Calcule la moyenne des évaluations attribuées aux participations d'un tournoi spécifié. 
        /// </summary>
        /// <param name="numeroTournoi">Le numéro unique identifiant le tournoi pour lequel la moyenne des évaluations doit être calculée.</param>
        /// <returns>La moyenne des évaluations pour le tournoi spécifié. Retourne 0,0 si aucune évaluation n'est disponible.</returns>
        public double? ObtenirMoyenneEvaluationParTournoi(int numeroTournoi)
        {
            var evaluations = _context.Participer
                .Where(p => p.NumeroTournoi == numeroTournoi && p.Evaluation > 0 && p.Evaluation <= 10)
                .Select(p => p.Evaluation);
            return evaluations.Any() ? evaluations.Average() : null;
        }

        /// <summary>
        /// Permet d'obtenir le nombre de participants inscrits à un tournoi donné.
        /// </summary>
        /// <param name="numeroTournoi">Numero unique du tournoi associé à la participation</param>
        /// <returns>Le nombre de participants inscrit au tournoi</returns>
        public int ObtenirNombreParticipantsParTournoi(int numeroTournoi)
        {
            return _context.Participer.Count(p => p.NumeroTournoi == numeroTournoi);
        }

        #endregion

        /// <summary>
        /// Permet de vérifier les propriétés associés a une plateforme.
        /// </summary>
        /// <param name="participer">La participation à valider</param>
        /// <returns>La liste contenant toutes les erreurs</returns>
        public List<string> ValiderParticiper(Participer participer, bool estModification)
        {
            // liste des erreurs
            var erreurs = new List<string>();

            if (Obtenir(participer.IdUser,participer.NumeroTournoi) != null && !estModification)
                erreurs.Add("L'utilisateur ne peux pas participer deux fois au même tournoi");

            if (participer.ScoreFinal < 0)
                erreurs.Add("Le score final ne peut pas être négatif");


            if (participer.Rang < 0)
                erreurs.Add("Le rang doit être un entier positif.");

            if (participer.Evaluation < 0 || participer.Evaluation > 10)
                erreurs.Add("L'évaluation doit être comprise entre 0 et 10");

            // Le nombre de participants doit être inférieur à la limite du tournoi
            Tournoi tournoi = _tournoiService.Obtenir(participer.NumeroTournoi);

            if (tournoi == null)
            {
                erreurs.Add("Le nombre de participants a atteint la limite du tournoi");

            }
            else
            {
                if (ObtenirNombreParticipantsParTournoi(participer.NumeroTournoi) >= tournoi.NbParticipants)
                            erreurs.Add("Le nombre de participants a atteint la limite du tournoi");
            }
          

            return erreurs;
        }
    }

}
