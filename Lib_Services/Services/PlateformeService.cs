using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
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

        /// <summary>
        /// Retourne toutes les plateformes présentes dans la base de données.
        /// </summary>
        /// <returns>Liste de <see cref="Plateforme"/>.</returns>
        public List<Plateforme> Lister()
        {
            // Utilise le DbSet Plateformes pour matérialiser la collection en mémoire.
            return _context.Plateformes.ToList();
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
                _context.SaveChanges();
            }
        }

    }
}
