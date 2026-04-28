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
    public class JoueurService : IJoueurService
    {
        private readonly ApplicationDbContext _context;
        private readonly IParticiperService _serviceParticiper;
        private readonly IVoterService _serviceVote;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="JoueurService"/>.
        /// </summary>
        /// <param name="context">Contexte de données utilisé pour les opérations persistées.</param>
        public JoueurService(ApplicationDbContext context)
        {
            _context = context;
            _serviceParticiper = new ParticiperService(_context);
            _serviceVote = new VoterService(_context);
        }
        #region Lecture

        /// <summary>
        ///  Retourne la liste complète des joueurs présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (IdUser) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Joueur"/>.</returns>
        public List<Joueur> Lister(string filtre = "", string propriete = "", string ordre = "")
        {
            IQueryable<Joueur> query = _context.Joueurs
                .Include(j => j.Participations)
                .Include(j => j.Votes);

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(j => j.IdUser.ToString().Contains(filtre));

            query = propriete switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "IdUser" => ordre == "ASC" ? query.OrderBy(j => j.IdUser) : query.OrderByDescending(j => j.IdUser),
                _ => query.OrderByDescending(j => j.IdUser) // valeur par défaut
            };

            return query.ToList();
        }

        /// <summary>
        /// Récupère un Participant par son id et son numéro de tournoi.
        /// </summary>
        /// <param name="Login">Login de l'Participer cherché.</param>
        /// <returns>L'entité <see cref="Joueur"/> si trouvée, sinon null.</returns>
        public Joueur? Obtenir(int idUser)
        {
            return _context.Joueurs
                           .Include(j => j.Participations)
                           .Include(j => j.Votes)
                           .AsNoTracking()
                           .FirstOrDefault(j => j.IdUser == idUser);
        }

        #endregion

        #region CUD
        /// <summary>
        /// Crée un nouvel Participer en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Participer"/> à créer.</param>
        public void Creer(Joueur joueur)
        {
            ValiderJoueur(joueur, false);
            // Ajout de l'entité au contexte puis persistance immédiate.
            _context.Joueurs.Add(joueur);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un Participant identifié par son id et son tournoi associé s'il existe.
        /// </summary>
        /// <param name="idUser">Id unique de l'utilisateur à supprimer.</param>
        /// <param name="numeroTournoi">Numero du tournoi associé à la participation à supprimer.</param>
        public void Supprimer(int idUser)
        {
            // Recherche de l'entité (utilise le cache si possible).
            Joueur? joueur = _context.Joueurs.Find(idUser);
            if (joueur != null)
            {
                _context.Joueurs.Remove(joueur);
                _context.SaveChanges();
            }
        }
        #endregion

        #region Statistiques
        
        #endregion

        #region Validations

        /// <summary>
        /// Valide les données d'un joueur avant création ou modification.
        /// </summary>
        /// <param name="joueur">Objet <see cref="Joueur"/> à valider.</param>
        /// <param name="estModification">Indique si la validation est effectuée dans le cadre d'une modification.</param>
        /// <exception cref="JoueurException">Exception levée en cas de validation échouée.</exception>
        public void ValiderJoueur(Joueur joueur, bool estModification = false)
        {

        }
        #endregion
    }

}
