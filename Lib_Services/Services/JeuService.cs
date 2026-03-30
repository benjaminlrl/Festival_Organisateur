using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Lib_Entities.Entities.Jeu;

namespace Lib_Services.Services
{
    public class JeuService : IJeuService
    {
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Constructeur avec injection du contexte de données.
        /// </summary>
        /// <param name="context">Contexte EF <see cref="ApplicationDbContext"/>.</param>
        public JeuService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retourne toutes les plateformes présentes dans la base de données.
        /// Si un filtre est fourni, retourne uniquement 
        /// les jeux dont le contenu correspond au filter
        /// </summary>
        /// <param name="filtre">Optionnel : titre à filtrer.</param>
        /// <returns>Liste de <see cref="Plateforme"/>.</returns>
        public List<Jeu> Lister(string filtre = "")
        {
            // Utilise le DbSet Plateformes pour matérialiser la collection en mémoire.
            if (string.IsNullOrWhiteSpace(filtre))
                return _context.Jeux
                     .Include(j => j.Plateformes)
                     .Include(j => j.Tournois)
                     .ToList();
            return
                _context.Jeux
                .Include(j => j.Plateformes)
                .Include(j => j.Tournois)
                .Where(j => j.Titre.Contains(filtre)
                || j.Description.Contains(filtre)
                || j.Editeur.Contains(filtre)
                || j.AnneeSortie.Contains(filtre)
                || j.DateSortie.ToString().Contains(filtre)
                || j.Pegi.ToString().Contains(filtre))
                .ToList();
        }

        /// <summary>
        /// Récupère un jeu par son identifiant.
        /// </summary>
        /// <param name="idPlateforme">Identifiant du jeu recherché.</param>
        /// <returns>Instance de <see cref="Jeu"/> si trouvée, sinon null.</returns>
        public Jeu? Obtenir(int idJeu)
        {
            // Find retourne null si l'entité n'existe pas.
            return _context.Jeux.Find(idJeu);
        }

        /// <summary>
        /// Crée un nouveau jeu et persiste la modification.
        /// </summary>
        /// <param name="jeu">Objet <see cref="Jeu"/> à ajouter.</param>
        public void Creer(Jeu jeu)
        {
            jeu.AnneeSortie = jeu.DateSortie.Year.ToString();// année de sortie calculée
            _context.Jeux.Add(jeu);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un jeu existant et persiste la modification.
        /// </summary>
        /// <param name="jeu">Objet <see cref="Jeu"/> contenant les valeurs mises à jour.</param>
        public void Modifier(Jeu jeu)
        {
            // Marque l'entité comme modifiée puis sauvegarde.
            jeu.AnneeSortie = jeu.DateSortie.Year.ToString(); // année de sortie calculée
            _context.Jeux.Update(jeu);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un jeu identifié par son identifiant si il existe.
        /// </summary>
        /// <param name="idPlateforme">Identifiant du jeu à supprimer.</param>
        public void Supprimer(int idJeu)
        {
            // Récupération de l'entité ; vérification de nullité avant suppression.
            var jeu = _context.Jeux.Find(idJeu);
            if (jeu != null)
            {
                _context.Jeux.Remove(jeu);
                // Suppression en cascade des Tournois associés au jeu. 
                // Puisqu'un Tournoi a obligatoirmeent un jeu.
                _context.Tournois.RemoveRange(_context.Tournois.Where(t => t.IdJeu == idJeu));
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Permet de vérifier les propriétés associés a un jeu.
        /// </summary>
        /// <param name="jeu">Le jeu à valider</param>
        /// <returns></returns>
        public List<string> ValiderJeu(Jeu jeu)
        {
            // liste des erreurs
            var erreurs = new List<string>();

            if (string.IsNullOrWhiteSpace(jeu.Titre))
                erreurs.Add("Le titre est requis.");

            if (string.IsNullOrWhiteSpace(jeu.Description))
                erreurs.Add("La description est requise.");

            if (string.IsNullOrWhiteSpace(jeu.Editeur))
                erreurs.Add("L'éditeur est requis.");

            if (string.IsNullOrWhiteSpace(jeu.DateSortie.ToString()))
                erreurs.Add("La date de sortie est requise.");

            if (jeu.Description.Length > 500)
                erreurs.Add("La description ne peut pas dépasser 500 caractères.");

            if (!Enum.IsDefined(typeof(PEGI), jeu.Pegi))
                erreurs.Add("Le PEGI sélectionné est invalide.");

            if (Lister(jeu.Titre).Any(j => j.Titre == jeu.Titre && j.IdJeu != jeu.IdJeu))
                erreurs.Add("Un autre jeu avec ce titre existe déjà.");
           
            return erreurs;
        }
    }
}
