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
            return _context.Jeux
                .Include(j => j.Plateformes)
                .Include(j => j.Tournois)
                .AsNoTracking()
                .FirstOrDefault(j => j.IdJeu.Equals(idJeu));
        }

        /// <summary>
        /// Récupère un jeu par son titre.
        /// </summary>
        /// <param name="titreJeu">Titre du jeu recherché.</param>
        /// <returns>Instance de <see cref="Jeu"/> si trouvée, sinon null.</returns>
        public Jeu? ObtenirParTitre(string titreJeu)
        {
            // Find retourne null si l'entité n'existe pas.
            return _context.Jeux
                .Include(j => j.Plateformes)
                .Include(j => j.Tournois)
                .AsNoTracking()
                .FirstOrDefault(j => j.Titre.Equals(titreJeu));
        }
        #endregion

        #region CUD
        /// <summary>
        /// Crée un nouveau jeu et persiste la modification.
        /// </summary>
        /// <param name="jeu">Objet <see cref="Jeu"/> à ajouter.</param>
        public void Creer(Jeu? jeu)
        {
            try
            {
                if (jeu != null)
                    jeu!.AnneeSortie = jeu.DateSortie.Year.ToString();// année de sortie calculée
                ValiderJeu(jeu);                
                _context.Jeux.Add(jeu!);
                _context.SaveChanges();
            }
            catch (JeuException ex)
            {
                throw new JeuException("Erreur lors de l'ajout du jeu : \n" + ex.Message,
                    (int)JeuException.JeuErreur.AjoutJeuException);
            }
            catch (DbUpdateException ex)
            {
                throw new JeuException("Erreur BDD lors de l'ajout du jeu : \n" + ex.Message,
                    (int)JeuException.JeuErreur.AjoutJeuDbUpdateException);
            }
        }

        /// <summary>
        /// Met à jour un jeu existant et persiste la modification.
        /// </summary>
        /// <param name="jeu">Objet <see cref="Jeu"/> contenant les valeurs mises à jour.</param>
        public void Modifier(Jeu? jeu)
        {
            try
            {
                jeu?.AnneeSortie = jeu.DateSortie.Year.ToString(); // année de sortie calculée

                ValiderJeu(jeu, true);
                _context.Jeux.Update(jeu!);
                _context.SaveChanges();
            }
            catch (JeuException ex)
            {
                throw new JeuException("Erreur lors de la modification du jeu : \n" + ex.Message,
                    (int)JeuException.JeuErreur.ModificationJeuException);
            }
            catch (DbUpdateException ex)
            {
                throw new JeuException("Erreur BDD lors de la modification du jeu : \n" + ex.Message,
                    (int)JeuException.JeuErreur.ModificationJeuDbUpdateException);
            }
        }

        /// <summary>
        /// Supprime un jeu identifié par son identifiant si il existe.
        /// </summary>
        /// <param name="idPlateforme">Identifiant du jeu à supprimer.</param>
        public void Supprimer(int idJeu)
        {
            // Récupération de l'entité ; vérification de nullité avant suppression.
            Jeu? jeu = _context.Jeux.Find(idJeu);
            try
            {
                ValiderSuppressionJeu(jeu);
                // cas simple sans postes de jeu
                _context.Jeux.Remove(jeu!);
                _context.SaveChanges();
            }
            catch (JeuException ex)
            {
                throw new JeuException("Erreur lors de la suppression de l'espace : \n" + ex.Message,
                    (int)JeuException.JeuErreur.SuppressionJeuException);
            }
            catch (DbUpdateException ex)
            {
                throw new JeuException("Erreur BDD lors de la suppression de l'espace : \n" + ex.Message,
                    (int)JeuException.JeuErreur.SuppressionJeuDbUpdateException);
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
        public void ValiderJeu(Jeu? jeu, bool estModification = false)
        {
            if (jeu == null)
                throw new JeuException("Le jeu ne peut pas être null.",
                    (int)JeuException.JeuErreur.JeuNull);

            if (string.IsNullOrWhiteSpace(jeu.Titre))
                throw new JeuException("Le titre est requis.",
                    (int)JeuException.JeuErreur.JeuTitreRequis);

            Jeu? jeuTitre = ObtenirParTitre(jeu.Titre);

            if(jeuTitre != null
                && jeuTitre.IdJeu != jeu.IdJeu)
                throw new JeuException("Un autre jeu utilise déjà ce titre.",
                   (int)JeuException.JeuErreur.JeuTitreExistant);

            if (string.IsNullOrWhiteSpace(jeu.Description))
                throw new JeuException("La description est requise.",
                    (int)JeuException.JeuErreur.JeuDescriptionRequise);

            if (jeu.Description.Length > 500)
                throw new JeuException("La description ne peut pas dépasser 500 caractères.",
                    (int)JeuException.JeuErreur.JeuDescriptionTropLongue);

            if (string.IsNullOrWhiteSpace(jeu.Editeur))
                throw new JeuException("L'éditeur est requis.",
                    (int)JeuException.JeuErreur.JeuEditeurRequis);

            if (jeu.DateSortie == default)
                throw new JeuException("La date de sortie est requise.",
                    (int)JeuException.JeuErreur.JeuDateSortieRequise);

            if (!Enum.IsDefined(typeof(ConstanteService.PEGI), jeu.Pegi))
                throw new JeuException("Le PEGI sélectionné est invalide.",
                    (int)JeuException.JeuErreur.JeuPegiInvalide);

            if (estModification)
            {
                Jeu? enBdd = Obtenir(jeu.IdJeu);

                if (enBdd == null)
                    throw new JeuException("Le jeu à modifier n'existe pas.",
                        (int)JeuException.JeuErreur.ModificationJeuInexistant);

                if (enBdd .IdJeu != jeu.IdJeu)
                    throw new JeuException("L'identifiant du jeu ne peut pas être modifié.",
                        (int)JeuException.JeuErreur.ModificationJeuId);
                // HashSet permet de vérifier que les plateformes sont mêmes puisque deux listes ne sont jamais égales
                // par référence même si elles ont le même contenu
                // SetEquals ignore l'ordre et les doublons,
                // ce qui est souvent suffisant pour des collections de navigation EF.
                if (enBdd.Pegi == jeu.Pegi
                    && enBdd.Titre == jeu.Titre
                    && enBdd.DateSortie == jeu.DateSortie
                    && enBdd.Description == jeu.Description
                    && enBdd.AnneeSortie == jeu.AnneeSortie
                    && enBdd.Editeur == jeu.Editeur                    
                    && new HashSet<int>(enBdd.Plateformes?.Select(p => p.IdPlateforme) ?? [])
                        .SetEquals(jeu.Plateformes?.Select(p => p.IdPlateforme) ?? []))
                    throw new JeuException("Aucune modification détectée",
                        (int)JeuException.JeuErreur.ModificationJeuAucune);
            }
        }

        /// <summary>
        /// Valide les propriétés d'une instance de <see cref="Jeu"/> peut être supprimer ou non.
        /// </summary>
        /// <param name="jeu">Instance de <see cref="Jeu"/> à valider.</param>
        /// <exception cref="JeuException">Exception levée si une validation échoue.</exception>
        public void ValiderSuppressionJeu(Jeu? jeu)
        {
            if (jeu == null)
                throw new JeuException("L'espace ne peut pas être null.",
                    (int)JeuException.JeuErreur.JeuNull);

            if (Obtenir(jeu.IdJeu) == null)
                throw new JeuException("Le jeu n'existe pas en base de données'.",
                    (int)JeuException.JeuErreur.JeuInexistant);

            if (jeu.Tournois != null && jeu.Tournois.Any(t => t.Statut == "Planifié" || t.Statut == "En cours"))
                throw new JeuException("Il n'est pas possible de supprimer un jeu associé à un tournoi planifié ou en cours.",
                    (int)JeuException.JeuErreur.SuppressionJeuTournoiExistant);
        }
        #endregion
    }
}
