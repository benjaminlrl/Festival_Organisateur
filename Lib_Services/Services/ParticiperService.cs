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
        private readonly ITournoiService _serviceTournoi;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="ParticiperService"/>.
        /// </summary>
        /// <param name="context">Contexte de données utilisé pour les opérations persistées.</param>
        public ParticiperService(ApplicationDbContext context)
        {
            _context = context;
            _serviceTournoi = new TournoiService(_context);
        }
        #region Lecture

        /// <summary>
        ///  Retourne la liste complète des jeux présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Nom, Description, Superficie, CapaciteMaxi) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Participer"/>.</returns>
        public List<Participer> Lister(string filtre = "", string propriete = "", string ordre = "")
        {
            IQueryable<Participer> query = _context.Participer
                .Include(p => p.Tournoi);

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(p => p.NumeroTournoi.ToString().Contains(filtre)
                || p.NumeroTournoi.ToString().Contains(filtre)
                || p.Rang.ToString().Contains(filtre)
                || (p.Commentaire ?? "").Contains(filtre)
                || p.DateHeureInscription.ToString().Contains(filtre));

            query = propriete switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "NumeroTournoi" => ordre == "ASC" ? query.OrderBy(p => p.NumeroTournoi) : query.OrderByDescending(p => p.NumeroTournoi),
                "Rang" => ordre == "ASC" ? query.OrderBy(p => p.Rang) : query.OrderByDescending(p => p.Rang),
                "Commentaire" => ordre == "ASC" ? query.OrderBy(p => p.Commentaire) : query.OrderByDescending(p => p.Commentaire),
                "DateHeureInscription" => ordre == "ASC" ? query.OrderBy(p => p.DateHeureInscription) : query.OrderByDescending(p => p.DateHeureInscription),
                _ => query.OrderByDescending(p => p.DateHeureInscription) // valeur par défaut
            };

            return query.ToList();
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

        #endregion
        #region CUD
        /// <summary>
        /// Crée un nouvel Participer en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Participer"/> à créer.</param>
        public void Creer(Participer participer)
        {
            ValiderParticipation(participer, false);
            // Ajout de l'entité au contexte puis persistance immédiate.
            _context.Participer.Add(participer);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un Participant existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Participer"/>.</param>
        public void Modifier(Participer participer)
        {
            ValiderParticipation(participer, false);
            _context.Participer.Update(participer);
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
            Participer? participer = _context.Participer.Find(idUser, numeroTournoi);
            if (participer != null)
            {
                _context.Participer.Remove(participer);
                _context.SaveChanges();
            }
        }
        #endregion
        #region Statistiques
        /// <summary>
        /// Permet de récupérer le podium Par tournoi
        /// </summary>
        /// <param name="numeroTournoi">Id du tournoi</param>
        /// <returns>Le classement des 10 meilleurs participants pour le tournoi spécifié.</returns>
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
        #region Validations
        /// <summary>
        /// Valide les données d'une participation avant création ou modification.
        /// </summary>
        /// <param name="participer">Objet <see cref="Participer"/> à valider.</param>
        /// <param name="estModification">Indique si la validation est effectuée dans le cadre d'une modification.</param>
        /// <exception cref="ParticiperException">Exception levée en cas de validation échouée.</exception>
        public void ValiderParticipation(Participer participer, bool estModification = false)
        {
            if (Obtenir(participer.IdUser, participer.NumeroTournoi) != null && !estModification)
                throw new ParticiperException("L'utilisateur participe déjà à ce tournoi.",
                    (int)ParticiperException.ParticiperErreur.DejaParticipant);

            if (participer.ScoreFinal < 0)
                throw new ParticiperException("Le score final ne peut pas être négatif.",
                    (int)ParticiperException.ParticiperErreur.ScoreNegatif);

            if (participer.Rang < 0)
                throw new ParticiperException("Le rang ne peut pas être inférieur à 0.",
                    (int)ParticiperException.ParticiperErreur.RangNegatif);

            if (participer.Evaluation < 0 || participer.Evaluation > 10)
                throw new ParticiperException("L'évaluation doit être comprise entre 0 et 10.",
                    (int)ParticiperException.ParticiperErreur.EvaluationInvalide);

            if (!string.IsNullOrEmpty(participer.Commentaire) && participer.Commentaire.Length > 500)
                throw new ParticiperException("Le commentaire ne peut pas dépasser 500 caractères.",
                    (int)ParticiperException.ParticiperErreur.CommentaireTropLong);

            Tournoi? tournoi = _serviceTournoi.Obtenir(participer.NumeroTournoi);

            if (tournoi == null)
                throw new ParticiperException("Le tournoi associé à la participation doit exister.",
                    (int)ParticiperException.ParticiperErreur.TournoiInexistant);

            if (ObtenirNombreParticipantsParTournoi(participer.NumeroTournoi) >= tournoi.NbParticipants)
                throw new ParticiperException("Le nombre de participants a atteint la limite du tournoi.",
                    (int)ParticiperException.ParticiperErreur.TournoiComplet);

            if (tournoi.Statut == "Terminé")
                throw new ParticiperException("Le tournoi est terminé, il n'est plus possible de s'y inscrire.",
                    (int)ParticiperException.ParticiperErreur.TournoiTermine);

            if (tournoi.Statut == "En cours")
                throw new ParticiperException("Le tournoi est en cours, il n'est plus possible de s'y inscrire.",
                    (int)ParticiperException.ParticiperErreur.TournoiEnCours);
        }
        #endregion
    }

}
