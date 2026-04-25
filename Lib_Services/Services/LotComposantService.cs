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
        /// <returns>Liste d'objets <see cref="LotComposant"/>.</returns>
        public List<LotComposant> Lister(string filtre = "", string propriete = "", string ordre = "")
        {
            IQueryable<LotComposant> query = _context.LotComposants
                .Include(lc => lc.Lot);

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(lc => lc.Libelle.Contains(filtre)
                || lc.Description.Contains(filtre)
                || lc.Valeur.ToString().Contains(filtre)
                || lc.Numero.ToString().Contains(filtre)
                || lc.Lot.Libelle.Contains(filtre));

            query = propriete switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "Libelle" => ordre == "ASC" ? query.OrderBy(lc => lc.Libelle) : query.OrderByDescending(lc => lc.Libelle),
                "Description" => ordre == "ASC" ? query.OrderBy(lc => lc.Description) : query.OrderByDescending(lc => lc.Description),
                "Valeur" => ordre == "ASC" ? query.OrderBy(lc => lc.Valeur) : query.OrderByDescending(lc => lc.Valeur),
                "Numero" => ordre == "ASC" ? query.OrderBy(lc => lc.Numero) : query.OrderByDescending(lc => lc.Numero),
                "Lot" => ordre == "ASC" ? query.OrderBy(lc => lc.Lot.Libelle) : query.OrderByDescending(lc => lc.Lot.Libelle),
                _ => query.OrderBy(lc => lc.Libelle) // valeur par défaut
            };

            return query.ToList();
        }

        /// <summary>
        /// Retourne la liste complète des lots composants contenant le numero du lot passé en paramètre
        /// Exécute immédiatement la requête via <c>ToList()</c>.
        /// </summary>
        /// <param name="numero">numero du lot qu'on cherche</param>
        /// <returns>Liste d'objets <see cref="LotComposant"/>.</returns>
        public List<LotComposant> ListerParNumeroDunLot(int numero)
        {
            return _context.LotComposants
                .Where(lc => lc.Lot.Numero.Equals(numero))
                .Include(lc => lc.Lot)
                .ToList();
        }
        /// <summary>
        ///  Retourne la liste complète des lots présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Libelle, Description, Valeur, Numero)
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="numero">Numero du lot associé au composant</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Lot"/>.</returns>
        public List<LotComposant> ListerParNumeroDunLot(int numero, string propriete = "", string ordre = "")
        {
            IQueryable<LotComposant> query = _context.LotComposants
                        .Where(lc => lc.Lot.Numero.Equals(numero))
                        .Include(lc => lc.Lot);

            query = propriete switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "Libelle" => ordre == "ASC" ? query.OrderBy(lc => lc.Libelle) : query.OrderByDescending(lc => lc.Libelle),
                "Description" => ordre == "ASC" ? query.OrderBy(lc => lc.Description) : query.OrderByDescending(lc => lc.Description),
                "Valeur" => ordre == "ASC" ? query.OrderBy(lc => lc.Valeur) : query.OrderByDescending(lc => lc.Valeur),
                _ => query.OrderByDescending(lc => lc.Numero) // valeur par défaut
            };

            return query.ToList();
        }

        /// <summary>
        /// Récupère un lotcomposant par son numero.
        /// </summary>
        /// <param name="numero">numero du lotcomposant cherché.</param>
        /// <returns>L'entité <see cref="LotComposant"/> si trouvée, sinon null.</returns>
        public LotComposant? Obtenir(int numero)
        {
            return _context.LotComposants
                           .FirstOrDefault(lc => lc.Numero == numero);
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
        public List<string> ValiderLotComposant(LotComposant lotComposant)
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
