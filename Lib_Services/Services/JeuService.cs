using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
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
        /// <param name="property">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Jeu"/>.</returns>
        public List<Jeu> Lister(string filtre = "", string property = "", string ordre = "")
        {
            IQueryable<Jeu> query = _context.Jeux
                .Include(j => j.Plateformes)
                .Include(j => j.Tournois);

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(j => j.Titre.Contains(filtre)
                || j.Description.Contains(filtre)
                || j.Editeur.Contains(filtre)
                || j.AnneeSortie.Contains(filtre)
                || j.DateSortie.ToString().Contains(filtre)
                || j.Pegi.ToString().Contains(filtre));

            query = property switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "Titre" => ordre == "ASC" ? query.OrderBy(j => j.Titre) : query.OrderByDescending(j => j.Titre),
                "Description" => ordre == "ASC" ? query.OrderBy(j => j.Description) : query.OrderByDescending(j => j.Description),
                "Editeur" => ordre == "ASC" ? query.OrderBy(j => j.Editeur) : query.OrderByDescending(j => j.Editeur),
                "AnneeSortie" => ordre == "ASC" ? query.OrderBy(j => j.AnneeSortie) : query.OrderByDescending(j => j.AnneeSortie),
                "DateSortie" => ordre == "ASC" ? query.OrderBy(j => j.DateSortie) : query.OrderByDescending(j => j.DateSortie),
                "Pegi" => ordre == "ASC" ? query.OrderBy(j => j.Pegi) : query.OrderByDescending(j => j.Pegi),
                _ => query.OrderByDescending(j => j.IdJeu) // valeur par défaut
            };

            return query.ToList();
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
        #endregion
        #region CUD
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
        #endregion
        #region Validations
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
        #endregion
    }
}
