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
    /// Service d'accès aux données pour l'entité <see cref="PosteJeu"/>.
    /// Fournit les opérations CRUD de base 
    /// </summary>
    public class PosteJeuService : IPosteJeuService
    {
        // Contexte Entity Framework 
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructeur .
        /// </summary>
        /// <param name="context">Instance de <see cref="ApplicationDbContext"/></param>
        public PosteJeuService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère l'ensemble des postes de jeu depuis la base de données.
        /// Si un filtre est fourni, ne retourne que 
        /// les postes de jeu dont la référence correspond au filtre.
        /// </summary>
        /// <param name="filtre">Optionnel : référence à filtrer.</param>
        /// <returns>Liste de <see cref="PosteJeu"/>.</returns>
        public List<PosteJeu> Lister(string filtre = "")
        {
            // ToList matérialise la requête et ramène les entités en mémoire.
            if (string.IsNullOrWhiteSpace(filtre)) 
                return _context.PostesJeu
                    .Include(p => p.Espace)
                    .Include(p => p.Plateforme)
                    .ToList();
            return _context.PostesJeu
                .Where(p => p.Reference.Contains(filtre))
                .Where(p => p.Espace.Nom.Contains(filtre))
                .Where(p => p.Plateforme.Libelle.Contains(filtre))
                .ToList();
        }

        /// <summary>
        /// Récupère un poste de jeu par son identifiant.
        /// </summary>
        /// <param name="idPosteJeu">Identifiant du poste de jeu recherché.</param>
        /// <returns>L'entité <see cref="PosteJeu"/> si trouvée ; sinon null.</returns>
        public PosteJeu? Obtenir(int idPosteJeu)
        {
            // Find retourne null si l'entité n'existe pas dans le contexte/la base.
            return _context.PostesJeu.Find(idPosteJeu);
        }

        /// <summary>
        /// Récupère un poste de jeu par sa référence.
        /// </summary>
        /// <param name="reference">Référence du poste de jeu recherché.</param>
        /// <returns>L'entité <see cref="PosteJeu"/> si trouvée ; sinon null.</returns>
        public PosteJeu? ReferenceExiste(string reference)
        {
            // Find retourne null si l'entité n'existe pas dans le contexte/la base.
            return _context.PostesJeu.FirstOrDefault(p => p.Reference == reference);
        }

        /// <summary>
        /// Ajoute un nouveau poste de jeu .
        /// </summary>
        /// <param name="posteJeu">Instance de <see cref="PosteJeu"/> à créer.</param>
        public void Creer(PosteJeu posteJeu)
        {
            // Ajout à l'ensemble suivi d'un commit via SaveChanges.
            _context.PostesJeu.Add(posteJeu);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un poste de jeu existant et persiste la modification.
        /// </summary>
        /// <param name="posteJeu">Instance de <see cref="PosteJeu"/> contenant les valeurs mises à jour.</param>
        public void Modifier(PosteJeu posteJeu)
        {
            // Marque l'entité comme modifiée puis enregistre les changements.
            _context.PostesJeu.Update(posteJeu);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un poste de jeu identifié par son identifiant si présent.
        /// </summary>
        /// <param name="idPosteJeu">Identifiant du poste de jeu à supprimer.</param>
        public void Supprimer(int idPosteJeu)
        {
            // Récupération en lecture puis suppression conditionnelle pour éviter les exceptions.
            var posteJeu = _context.PostesJeu.Find(idPosteJeu);
            if (posteJeu != null)
            {
                _context.PostesJeu.Remove(posteJeu);
                _context.SaveChanges();
            }
        }
    }

}
