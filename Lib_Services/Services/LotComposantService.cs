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
    /// Service métier responsable des opérations CRUD sur l'entité <see cref="LotComposant"/>.
    /// </summary>
    public class LotComposantService : ILotComposantService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="LotComposantService"/>.
        /// </summary>
        /// <param name="context">Contexte de données utilisé pour les opérations persistées.</param>
        public LotComposantService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retourne la liste complète des lots composants présents en base.
        /// Exécute immédiatement la requête via <c>ToList()</c>.
        /// </summary>
        /// <param name="filtre">Optionnel : libellé à filtrer.</param>
        /// <returns>Liste d'objets <see cref="LotComposant"/>.</returns>
        public List<LotComposant> Lister(string filtre = "")
        {
            if (string.IsNullOrWhiteSpace(filtre))
                return _context.LotComposants
                     .ToList();
            return
                _context.LotComposants
                .Where(r => r.Libelle.Contains(filtre))
                .ToList();
        }

        /// <summary>
        /// Récupère un lotcomposant par son numero.
        /// </summary>
        /// <param name="numero">numero du lotcomposant cherché.</param>
        /// <returns>L'entité <see cref="LotComposant"/> si trouvée, sinon null.</returns>
        public LotComposant? Obtenir(int numero)
        {
            return _context.LotComposants
                           .FirstOrDefault(o => o.Numero == numero);
        }

        /// <summary>
        /// Crée un nouvel lotcomposant en base
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="lotComposant">Instance de <see cref="LotComposant"/> à créer.</param>
        public void Creer(LotComposant lotComposant)
        {
            // Ajout de l'entité au contexte puis persistance immédiate.
            _context.LotComposants.Add(lotComposant);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un lotcomposant existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="LotComposant"/>.</param>
        public void Modifier(LotComposant lotComposant)
        {
            _context.LotComposants.Update(lotComposant);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un lotcomposant identifié par son login s'il existe.
        /// </summary>
        /// <param name="numero">numero du lotcomposant à supprimer.</param>
        public void Supprimer(int numero)
        {
            // Recherche de l'entité (utilise le cache si possible).
            var lotComposant = _context.LotComposants.Find(numero);
            if (lotComposant != null)
            {
                _context.LotComposants.Remove(lotComposant);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Permet de voir si un lot composant est conformes aux règles de sécurité suivantes
        /// </summary>
        /// <param name="lotComposant">Instance de <see cref="LotComposant"/> à créer.</param>
        /// <returns>la liste des msgs d'erreurs.</returns>
        public List<string> LotComposantValide(LotComposant lotComposant)
        {
            // liste des erreurs
            var erreurs = new List<string>();

            if (string.IsNullOrWhiteSpace(lotComposant.Libelle))
            {
                erreurs.Add("Le libelle ne peut pas être vide.");
            }
            if(lotComposant.Libelle.Length > 50)
            {
                erreurs.Add("Le libelle ne peut pas faire plus de 20 charactères.");
            }
            if (lotComposant.Valeur < 0)
            {
                erreurs.Add("La valeur doit être positive.");
            }
            if (lotComposant.Description.Length > 150)
            {
                erreurs.Add("La description ne peut pas faire plus de 150 charactères.");
            }
            return erreurs;
        }
    }
}
