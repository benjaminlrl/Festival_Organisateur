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
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Jeu"/>.</returns>
        public List<Jeu> Lister(string filtre = "", string propriete = "", string ordre = "")
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

            query = propriete switch
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
            ValiderJeu(jeu, false);
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
            ValiderJeu(jeu, true);
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
        /// Valide les propriétés d'une instance de <see cref="Jeu"/> avant sa création ou sa modification.
        /// </summary>
        /// <param name="jeu">Instance de <see cref="Jeu"/> à valider.</param>
        /// <param name="estModification">Indique si la validation est pour une modification.</param>
        /// <exception cref="JeuException">Exception levée si une validation échoue.</exception>
        public void ValiderJeu(Jeu jeu, bool estModification = false)
        {
            if (string.IsNullOrWhiteSpace(jeu.Titre))
                throw new JeuException("Le titre est requis.",
                    (int)JeuException.JeuErreur.TitreRequis);

            if (string.IsNullOrWhiteSpace(jeu.Description))
                throw new JeuException("La description est requise.",
                    (int)JeuException.JeuErreur.DescriptionRequise);

            if (jeu.Description.Length > 500)
                throw new JeuException("La description ne peut pas dépasser 500 caractères.",
                    (int)JeuException.JeuErreur.DescriptionTropLongue);

            if (string.IsNullOrWhiteSpace(jeu.Editeur))
                throw new JeuException("L'éditeur est requis.",
                    (int)JeuException.JeuErreur.EditeurRequis);

            if (jeu.DateSortie == default)
                throw new JeuException("La date de sortie est requise.",
                    (int)JeuException.JeuErreur.DateSortieRequise);

            if (!Enum.IsDefined(typeof(ConstanteService.PEGI), jeu.Pegi))
                throw new JeuException("Le PEGI sélectionné est invalide.",
                    (int)JeuException.JeuErreur.PegiInvalide);

            if (Lister(jeu.Titre).Any(j => j.Titre == jeu.Titre && j.IdJeu != jeu.IdJeu))
                throw new JeuException("Un autre jeu avec ce titre existe déjà.",
                    (int)JeuException.JeuErreur.TitreExistant);
        }
        #endregion
    }
}
