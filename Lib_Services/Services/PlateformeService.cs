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
    /// Service d'accès aux données pour l'entité <see cref="Plateforme"/>.
    /// Fournit des opérations basiques de type CRUD 
    /// </summary>
    public class PlateformeService : IPlateformeService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructeur avec injection du contexte de données.
        /// </summary>
        /// <param name="context">Contexte EF <see cref="ApplicationDbContext"/>.</param>
        public PlateformeService(ApplicationDbContext context)
        {
            _context = context;
        }
        #region Lecture
        /// <summary>
        /// Retourne toutes les plateformes présentes dans la base de données.
        /// Si un filtre est fourni, retourne uniquement 
        /// les plateformes dont le libellé correspond au filtre.
        /// </summary>
        /// <param name="filtre">Optionnel : libellé à filtrer.</param>
        /// <returns>Liste de <see cref="Plateforme"/>.</returns>
        public List<Plateforme> Lister(string filtre = "")
        {
            // Utilise le DbSet Plateformes pour matérialiser la collection en mémoire.
            if (string.IsNullOrWhiteSpace(filtre))
                return _context.Plateformes
                     .Include(p => p.PostesJeu)
                     .Include(p => p.Jeux)
                     .ToList();
            return
                _context.Plateformes
                .Include(p => p.PostesJeu)
                .Include(p => p.Jeux)
                .Where(p => p.Libelle.Contains(filtre))
                .ToList();
        }

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
        /// <returns>Liste d'objets <see cref="Plateforme"/>.</returns>
        public List<Plateforme> Lister(string filtre = "", string propriete = "", string ordre = "")
        {
            IQueryable<Plateforme> query = _context.Plateformes
                .Include(p => p.PostesJeu)
                .Include(p => p.Jeux);

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(p => p.Libelle.Contains(filtre));

            query = propriete switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "Libelle" => ordre == "ASC" ? query.OrderBy(p => p.Libelle) : query.OrderByDescending(p => p.Libelle),
                "IdPlateforme" => ordre == "ASC" ? query.OrderBy(p => p.IdPlateforme) : query.OrderByDescending(p => p.IdPlateforme),
                _ => query.OrderByDescending(p => p.IdPlateforme) // valeur par défaut
            };

            return query.ToList();
        }

        /// <summary>
        /// Récupère une plateforme par son identifiant.
        /// </summary>
        /// <param name="idPlateforme">Identifiant de la plateforme recherchée.</param>
        /// <returns>Instance de <see cref="Plateforme"/> si trouvée, sinon null.</returns>
        public Plateforme? Obtenir(int idPlateforme)
        {
            // Find retourne null si l'entité n'existe pas.
            return _context.Plateformes.Find(idPlateforme);
        }
        #endregion
        #region CUD
        /// <summary>
        /// Crée une nouvelle plateforme et persiste la modification.
        /// </summary>
        /// <param name="plateforme">Objet <see cref="Plateforme"/> à ajouter.</param>
        public void Creer(Plateforme plateforme)
        {
            _context.Plateformes.Add(plateforme);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour une plateforme existante et persiste la modification.
        /// </summary>
        /// <param name="plateforme">Objet <see cref="Plateforme"/> contenant les valeurs mises à jour.</param>
        public void Modifier(Plateforme plateforme)
        {
            // Marque l'entité comme modifiée puis sauvegarde.
            _context.Plateformes.Update(plateforme);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime une plateforme identifiée par son identifiant si elle existe.
        /// </summary>
        /// <param name="idPlateforme">Identifiant de la plateforme à supprimer.</param>
        public void Supprimer(int idPlateforme)
        {
            // Récupération de l'entité ; vérification de nullité avant suppression.
            var plateforme = _context.Plateformes.Find(idPlateforme);
            if (plateforme != null)
            {
                _context.Plateformes.Remove(plateforme);
                // Suppression en cascade des postes de jeu associés à la plateforme. 
                // Puisqu'un poste de jeu a obligatoirmeent une plateforme.
                _context.PostesJeu.RemoveRange(_context.PostesJeu.Where(p => p.IdPlateforme == idPlateforme));
                _context.SaveChanges();
            }
        }
        #endregion
        #region Validations
        /// <summary>
        /// Permet de vérifier les propriétés associés a une plateforme.
        /// </summary>
        /// <param name="plateforme">La plateforme à valider</param>
        /// <param name="estModification">Indique si la validation est effectuée dans le cadre d'une modification</param>
        /// <returns>La liste contenant toutes les erreurs</returns>
        public List<string> ValiderPlateforme(Plateforme plateforme, bool estModification)
        {
            // liste des erreurs
            var erreurs = new List<string>();

            if (string.IsNullOrWhiteSpace(plateforme.Libelle))
                erreurs.Add("Le libellé est requis.");

            if (plateforme.IdPlateforme <= 0)
                erreurs.Add("Une plateforme est requise.");

            if (Lister(plateforme.Libelle).Any(p => p.Libelle == plateforme.Libelle && p.IdPlateforme != plateforme.IdPlateforme))
                erreurs.Add("Une autre plateforme avec ce libellé existe déjà.");

            return erreurs;
        }
        #endregion
    }
}
