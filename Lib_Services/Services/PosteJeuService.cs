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
        private readonly IPlateformeService _plateformeService;
        private readonly IEspaceService _espaceService;

        /// <summary>
        /// Constructeur .
        /// </summary>
        /// <param name="context">Instance de <see cref="ApplicationDbContext"/></param>
        public PosteJeuService(ApplicationDbContext context)
        {
            _context = context;
            _espaceService = new EspaceService(context);
            _plateformeService = new PlateformeService(context);
        }
        #region Lecture

        /// <summary>
        ///  Retourne la liste complète des postes de jeu présents en base, 
        ///  avec possibilité de filtrer par nom ou description.
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Reference, NumeroPoste, NomPlateforme, NomEspace, Fonctionnel) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="PosteJeu"/>.</returns>
        public List<PosteJeu> Lister(string filtre = "", string propriete = "Reference", string ordre = "ASC")
        {
            IQueryable<PosteJeu> query = _context.PostesJeu
                    .Include(p => p.Espace)
                    .Include(p => p.Plateforme);

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(p =>
                    p.Reference.Contains(filtre)
                    || p.Espace.Nom.Contains(filtre)
                    || p.Plateforme.Libelle.Contains(filtre));

            query = propriete switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "Reference" => ordre == "ASC" ? query.OrderBy(p => p.Reference) : query.OrderByDescending(p => p.Reference),
                "NumeroPoste" => ordre == "ASC" ? query.OrderBy(p => p.NumeroPoste) : query.OrderByDescending(p => p.NumeroPoste),
                "NomPlateforme" => ordre == "ASC" ? query.OrderBy(p => p.Plateforme.Libelle) : query.OrderByDescending(p => p.Plateforme.Libelle),
                "NomEspace" => ordre == "ASC" ? query.OrderBy(p => p.Espace.Nom) : query.OrderByDescending(p => p.Espace.Nom),
                "Fonctionnel" => ordre == "ASC" ? query.OrderBy(p => p.Fonctionnel) : query.OrderByDescending(p => p.Fonctionnel),
                _ => query.OrderBy(p => p.Reference) // valeur par défaut
            };

            return query.ToList();
        }

        /// <summary>
        ///  Retourne la liste complète des postes de jeu NON FONCTIONNELS présents en base, 
        ///  avec possibilité de filtrer par nom ou description.
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Reference, NumeroPoste, NomPlateforme, NomEspace, Fonctionnel) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="PosteJeu"/>.</returns>
        public List<PosteJeu> ListerPostesJeuNonFonctionnels(string filtre = "", string propriete = "Nom", string ordre = "ASC")
        {
            IQueryable<PosteJeu> query = _context.PostesJeu
                    .Include(p => p.Espace)
                    .Include(p => p.Plateforme);

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(p =>
                    p.Fonctionnel == false 
                    && (p.Reference.Contains(filtre)
                        || p.Espace.Nom.Contains(filtre)
                        || p.Plateforme.Libelle.Contains(filtre)));

            query = propriete switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "Reference" => ordre == "ASC" ? query.OrderBy(p => p.Reference) : query.OrderByDescending(p => p.Reference),
                "NumeroPoste" => ordre == "ASC" ? query.OrderBy(p => p.NumeroPoste) : query.OrderByDescending(p => p.NumeroPoste),
                "NomPlateforme" => ordre == "ASC" ? query.OrderBy(p => p.Plateforme.Libelle) : query.OrderByDescending(p => p.Plateforme.Libelle),
                "NomEspace" => ordre == "ASC" ? query.OrderBy(p => p.Espace.Nom) : query.OrderByDescending(p => p.Espace.Nom),
                "Fonctionnel" => ordre == "ASC" ? query.OrderBy(p => p.Fonctionnel) : query.OrderByDescending(p => p.Fonctionnel),
                _ => query.OrderBy(p => p.Reference) // valeur par défaut
            };

            return query.ToList();
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
        #endregion
        #region CUD
        /// <summary>
        /// Ajoute un nouveau poste de jeu .
        /// </summary>
        /// <param name="posteJeu">Instance de <see cref="PosteJeu"/> à créer.</param>
        public void Creer(PosteJeu posteJeu)
        {
            int numeroPoste = ObtenirNbPostesJeuEspacePlateforme(posteJeu.IdEspace, posteJeu.IdPlateforme) + 1;
            Espace? espace = _espaceService.Obtenir(posteJeu.IdEspace);

            if (espace == null)
                return;
            
            posteJeu.SetReference(espace, numeroPoste);
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
        #endregion
        #region Validations
        // TODO: AJouter un formalisme gérer dans le setter de l'entité PosteJeu pour normaliser le nommage des références des Postes de Jeu en fonction de l'espace, la plateforme et le numéro du poste.

        /// <summary>
        /// Valide les données d'un poste de jeu avant création ou modification.
        /// </summary>
        /// <param name="posteJeu">Le poste de jeu concerné</param>
        /// <returns>La liste des erreurs de type <see cref="string"/></returns>
        public List<string> ValiderPosteJeu(PosteJeu posteJeu)
        {
            var erreurs = new List<string>();
            if (string.IsNullOrWhiteSpace(posteJeu.Reference))
                erreurs.Add("La référence du poste de jeu est obligatoire.");

            if (posteJeu.IdEspace <= 0)
                erreurs.Add("L'espace associé est obligatoire.");

            if (posteJeu.IdPlateforme <= 0)
                erreurs.Add("La plateforme associée est obligatoire.");

            if(posteJeu.Fonctionnel != true && posteJeu.Fonctionnel != false)
                erreurs.Add("Le champ Fonctionnel doit être un booléen.");

            if(ReferenceExiste(posteJeu.Reference) != null && ReferenceExiste(posteJeu.Reference)?.NumeroPoste != posteJeu.NumeroPoste)
                erreurs.Add("Un poste de jeu avec cette référence existe déjà.");
            return erreurs;
        }
        #endregion
        #region Statistiques

        /// <summary>
        /// Permet d'obtenir le nombre de postes de jeu fonctionnel enregistrés en base de données
        /// </summary>
        /// <param name="filtre">Optionnel, filtre sur les propriétés du poste de Jeu</param>
        /// <returns></returns>
        public int NombrePostesJeuFonctionnels(string filtre = "")
        {
            IQueryable<PosteJeu> query = _context.PostesJeu
                    .Include(p => p.Espace)
                    .Include(p => p.Plateforme)
                    .Where(p =>
                           p.Fonctionnel == true);

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(p =>
                            p.Reference.Contains(filtre)
                            || p.Espace.Nom.Contains(filtre)
                            || p.Plateforme.Libelle.Contains(filtre));

            return query.Count();
        }

        /// <summary>
        /// Permet d'obtenir le nombre total de postes de jeu enregistrés en base de données
        /// </summary>
        /// <param name="filtre">Optionnel, filtre sur les propriétés du poste de Jeu</param>
        /// <returns></returns>
        public int NombrePostesJeu(string filtre = "")
        {
            IQueryable<PosteJeu> query = _context.PostesJeu
                    .Include(p => p.Espace)
                    .Include(p => p.Plateforme);

            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(p => 
                        p.Reference.Contains(filtre)
                        || p.Espace.Nom.Contains(filtre)
                        || p.Plateforme.Libelle.Contains(filtre));

            return query.Count();
        }

        #endregion
        #region Méthodes
        public int ObtenirNbPostesJeuEspacePlateforme(int idEspace, int idPlateforme)
        {
            return _context.PostesJeu
                .Where(p => p.IdEspace == idEspace && p.IdPlateforme == idPlateforme)
                .Count();
        }
        #endregion
    }

}
