using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
        private readonly IEspaceService _serviceEspace;

        /// <summary>
        /// Constructeur .
        /// </summary>
        /// <param name="context">Instance de <see cref="ApplicationDbContext"/></param>
        public PosteJeuService(ApplicationDbContext context)
        {
            _context = context;
            _serviceEspace = new EspaceService(context);
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
        public List<PosteJeu> Lister(string filtre = "", string propriete = "", string ordre = "")
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
                _ => query.OrderByDescending(p => p.NumeroPoste) // valeur par défaut
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
            // AsNoTracking pour éviter le suivi de l'entité dans le contexte,
            // permet de vérifier la valeur actuelle en base sans risque de conflits avec des entités déjà suivies.
            return _context.PostesJeu.AsNoTracking().FirstOrDefault(p => p.NumeroPoste.Equals(idPosteJeu));
        }

        /// <summary>
        /// permet de récupérer les postes de jeu associés à un espace donné,
        /// </summary>
        /// <param name="espace">L'espace dont on souhaite récupérer les postes de jeu</param>
        /// <returns>Liste des postes de jeu associés à l'espace</returns>
        public List<PosteJeu> ListerPostesJeuDunEspace(Espace espace)
        {
            return _context.PostesJeu
                .Include(p => p.Espace)
                .Include(p => p.Plateforme)
                .Where(p => p.IdEspace == espace.IdEspace)
                .ToList();
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
            Espace? espace = _serviceEspace.Obtenir(posteJeu.IdEspace) ?? throw new Exception("Espace inconnu");

            // récupère le poste de jeu avec le numéro de poste le plus haut
            // Récupéré le numéro associé a sa référence,
            // +1
            PosteJeu? dernierPoste = ObtenirDernierPosteJeuDunEspace(posteJeu.IdEspace);

            int numeroPoste = dernierPoste != null
                ? int.Parse(dernierPoste.Reference.Substring(dernierPoste.Reference.Length - 3, 3)) +1
                : 1;

            posteJeu.SetReference(espace, numeroPoste);

            while (ReferenceExiste(posteJeu.Reference) != null)
            {
                numeroPoste++;
                posteJeu.SetReference(espace, numeroPoste);
            }

            ValiderPosteJeu(posteJeu, false);
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
            ValiderPosteJeu(posteJeu, true);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="posteJeu"></param>
        /// <param name="estModification">Indique si la validation est effectuée dans le cadre d'une modification.</param>
        /// <exception cref="PosteJeuException"></exception>
        public void ValiderPosteJeu(PosteJeu posteJeu, bool estModification = false)
        {
            if (string.IsNullOrWhiteSpace(posteJeu.Reference))
                throw new PosteJeuException("La référence du poste de jeu est obligatoire.",
                    (int)PosteJeuException.PosteJeuErreur.ReferenceRequise);

            if (posteJeu.IdEspace <= 0)
                throw new PosteJeuException("L'espace associé est obligatoire.",
                    (int)PosteJeuException.PosteJeuErreur.EspaceRequis);

            if (posteJeu.IdPlateforme <= 0)
                throw new PosteJeuException("La plateforme associée est obligatoire.",
                    (int)PosteJeuException.PosteJeuErreur.PlateformeRequise);

            if (ReferenceExiste(posteJeu.Reference) != null
            && ReferenceExiste(posteJeu.Reference)?.NumeroPoste != posteJeu.NumeroPoste)
                throw new PosteJeuException("Un poste de jeu avec cette référence existe déjà.",
                    (int)PosteJeuException.PosteJeuErreur.ReferenceExistante);
            
            // Modifications
            if (estModification)
            {
                PosteJeu? enBdd = Obtenir(posteJeu.NumeroPoste);
                if(enBdd == null)
                    throw new PosteJeuException("Le poste de jeu à modifier n'existe pas en base.",
                        (int)PosteJeuException.PosteJeuErreur.ModificationPosteInexistante);

                if (posteJeu.IdEspace == enBdd.IdEspace
                    && posteJeu.IdPlateforme == enBdd.IdPlateforme
                    && posteJeu.Fonctionnel == enBdd.Fonctionnel
                    && posteJeu.Reference == enBdd.Reference)
                    throw new PosteJeuException("Aucune modification détectée pour ce poste de jeu.",
                        (int)PosteJeuException.PosteJeuErreur.AucuneModification);

                if (posteJeu.IdEspace != enBdd.IdEspace)
                    throw new PosteJeuException("Un poste de jeu ne peut pas avoir un espace différent.",
                    (int)PosteJeuException.PosteJeuErreur.ModificationPosteEspaceDifferent);

                if (posteJeu.IdPlateforme != enBdd.IdPlateforme)
                    throw new PosteJeuException("Un poste de jeu ne peut pas avoir une plateforme différent.",
                    (int)PosteJeuException.PosteJeuErreur.ModificationPostePlateformeDifferente);

            }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idEspace"></param>
        /// <returns></returns>
        public int NombrePostesJeuEspace(int idEspace)
        {
            return _context.PostesJeu
                .Where(p => p.IdEspace == idEspace)
                .Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idEspace"></param>
        /// <param name="idPlateforme"></param>
        /// <returns></returns>
        public int NombrePostesJeuEspacePlateforme(int idEspace, int idPlateforme)
        {
            return _context.PostesJeu
                .Where(p => p.IdEspace == idEspace && p.IdPlateforme == idPlateforme)
                .Count();
        }

        /// <summary>
        /// Récupère le poste de jeu d'un espace avec le plus haut numéro de poste
        /// </summary>
        /// <param name="idEspace">Id de l'espace du poste de jeu</param>
        /// <returns>L'objet poste d ejeu</returns>
        public PosteJeu? ObtenirDernierPosteJeuDunEspace(int idEspace)
        {
            return _context.PostesJeu
                .Where(p => p.IdEspace == idEspace)
                .OrderByDescending(p => p.NumeroPoste)
                .FirstOrDefault();
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Dans le cas ou le nom d'un espace est modifié, 
        /// cette méthode permet de mettre à jour 
        /// la référence de tous les postes de jeu associés à cet espace
        /// </summary>
        /// <param name="postesJeu"></param>
        /// <param name="nouveauNomEspace"></param>
        /// <exception cref="Exception"></exception>
        public void FormatRefPosteJeuEspaceNouvNom(List<PosteJeu> postesJeu, string nouveauNomEspace)
        {
            Espace? nouvEspace = _serviceEspace.ObtenirParNom(nouveauNomEspace);

            if (nouvEspace == null)
                throw new Exception("Espace inconnu");

            foreach (PosteJeu posteJeu in postesJeu)
            {
                // Récupère le numéro de poste à partir de la référence actuelle du poste de jeu
                int numeroPoste = int.Parse(posteJeu.Reference.Substring(posteJeu.Reference.Length - 3, 3));

                posteJeu.SetReference(nouvEspace, numeroPoste);
                Modifier(posteJeu);
            }
        }

        #endregion
    }

}
