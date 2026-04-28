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
    /// Service métier responsable des opérations CRUD sur l'entité <see cref="Organisateur"/>.
    /// </summary>
    public class OrganisateurService : IOrganisateurService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="OrganisateurService"/>.
        /// </summary>
        /// <param name="context">Contexte de données utilisé pour les opérations persistées.</param>
        public OrganisateurService(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Lecture
        /// <summary>
        ///  Retourne la liste complète des organisateurs présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Login, Mail, NomRole) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Organisateur"/>.</returns>
        public List<Organisateur> Lister(string filtre = "", string propriete = "", string ordre = "")
        {
            IQueryable<Organisateur> query = _context.Organisateurs
                .Include(o => o.Role);
            if (!string.IsNullOrWhiteSpace(filtre))
                query = query.Where(o => o.Login.Contains(filtre)
                || o.Mail.Contains(filtre)
                || o.Role.Libelle.Contains(filtre));

            query = propriete switch
            {
                // tri par la colonne spécifiée, en fonction de l'ordre demandé
                "Login" => ordre == "ASC" ? query.OrderBy(o => o.Login) : query.OrderByDescending(o => o.Login),
                "Mail" => ordre == "ASC" ? query.OrderBy(o => o.Mail) : query.OrderByDescending(o => o.Mail),
                "NomRole" => ordre == "ASC" ? query.OrderBy(o => o.Role.Libelle) : query.OrderByDescending(o => o.Role.Libelle),
                _ => query.OrderByDescending(o => o.Login) // valeur par défaut
            };

            return query.ToList();
        }

        /// <summary>
        /// Récupère un organisateur par son login.
        /// </summary>
        /// <param name="Login">Login de l'organisateur cherché.</param>
        /// <returns>L'entité <see cref="Organisateur"/> si trouvée, sinon null.</returns>
        public Organisateur? Obtenir(string login)
        {
            return _context.Organisateurs
                           .Include(o => o.Role)
                           .FirstOrDefault(o => o.Login == login);
        }
        #endregion

        #region CUD

        /// <summary>
        /// Crée un nouvel organisateur en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Organisateur"/> à créer.</param>
        public void Creer(Organisateur organisateur)
        {
            ValiderOrganisateur(organisateur, false);
            // Hashe du mot de passe via BCrypt.
            organisateur.motPasse = BCrypt.Net.BCrypt.HashPassword(organisateur.motPasse);
            _context.Organisateurs.Add(organisateur);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un organisateur existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Organisateur"/>.</param>
        public void Modifier(Organisateur organisateur)
        {
            ValiderOrganisateur(organisateur, true);
            _context.Organisateurs.Update(organisateur);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un organisateur identifié par son login s'il existe.
        /// </summary>
        /// <param name="login">login de l'organisateur à supprimer.</param>
        public void Supprimer(string login)
        {
            // Recherche de l'entité (utilise le cache si possible).
            var organisateur = _context.Organisateurs.Find(login);
            if (organisateur != null)
            {
                _context.Organisateurs.Remove(organisateur);
                _context.SaveChanges();
            }
        }
        #endregion

        #region Validations
        /// <summary>
        /// Vérifie si les informations d'identification fournies correspondent à un organisateur existant.
        /// </summary>
        /// <param name="motDePasse">Le mot de passe hashé de l'organisateur.</param>
        /// <param name="identifiant">Le login de l'organisateur.</param>
        /// <returns>True si il est identique, false si non</returns>
        public bool EstIdentique(string motDePasse, string identifiant)
        {
            var organisateur = _context.Organisateurs.Find(identifiant);
            if (organisateur == null)
                return false;
            return BCrypt.Net.BCrypt.Verify(motDePasse, organisateur.motPasse);
        }
        /// <summary>
        /// Retourne si l'organisateur peut faire une action en rapport avec un userController
        /// Consulter - Modifier - Supprimer - Ajouter
        /// </summary>
        /// <returns>true si il a l'autorisation, sinon false.</returns>
        public bool EstAutoriser(Organisateur unOrganisateur, Organisateur.LesUC unUC, string action)
        {
            Role role = unOrganisateur.Role;
            // Les administrateurs ont le droit à tout
            if (role.Libelle == "Administrateur")
            {
                return true;
            }
            // System.Diagnostics.Debug.WriteLine($"ESTAUTORISER : {role.Libelle} {action} {unUC}");
            // Role Gestionnaire de stock
            // Consulter : Tournoi, Jeu, Espace, PosteJeu, Plateforme
            // CRUD: Lot, LotComposant
            if (role.Libelle == "Gestionnaire du stock")
            {
                if (action == "Consulter")
                {
                    if (unUC == Organisateur.LesUC.UcTournois   || unUC == Organisateur.LesUC.UcPostesDeJeu 
                        || unUC == Organisateur.LesUC.UcEspaces || unUC == Organisateur.LesUC.UcPlateformes
                        || unUC == Organisateur.LesUC.UcJeux)
                    {
                        return true;
                    }
                }
                else if (action == "Modifier" || action == "Supprimer" || action == "Ajouter")
                {
                    if (unUC == Organisateur.LesUC.UcLotComposants || unUC == Organisateur.LesUC.UcLots)
                    {
                        return true;
                    }
                }
            }

            // Role Gestionnaire de l'Espace
            // Consulter : Plateforme, Jeu, Participer
            // CRUD: Espace, PosteJeu, Tournoi
            if (role.Libelle == "Gestionnaire de l'espace")
            {
                if (action == "Consulter")
                {
                    if (unUC == Organisateur.LesUC.UcPlateformes || unUC == Organisateur.LesUC.UcJeux 
                        || unUC == Organisateur.LesUC.UcParticiper)
                    {
                        return true;
                    }
                }
                else if (action == "Modifier" || action == "Supprimer" || action == "Ajouter")
                {
                    if (unUC == Organisateur.LesUC.UcTournois || unUC == Organisateur.LesUC.UcEspaces 
                        || unUC == Organisateur.LesUC.UcPostesDeJeu)
                    {
                        return true;
                    }
                }
            }

            // Role Gestionnaire des tournois
            // Consulter : Espace, PosteJeu, Plateforme, Jeu, Lot
            // CRUD: Tournoi, Participer, JeuSoumisVote
            if (role.Libelle == "Gestionnaire des tournois")
            {
                if (action == "Consulter")
                {
                    if (unUC == Organisateur.LesUC.UcEspaces        || unUC == Organisateur.LesUC.UcPostesDeJeu 
                        || unUC == Organisateur.LesUC.UcPlateformes || unUC == Organisateur.LesUC.UcPostesDeJeu
                        || unUC == Organisateur.LesUC.UcJeux        || unUC == Organisateur.LesUC.UcLots 
                        || unUC == Organisateur.LesUC.UcJeuxSoumisVote) 
                    {
                        return true;
                    }
                }
                else if (action == "Modifier" || action == "Supprimer" || action == "Ajouter")
                {
                    if (unUC == Organisateur.LesUC.UcTournois || unUC == Organisateur.LesUC.UcParticiper 
                        || unUC == Organisateur.LesUC.UcJeuxSoumisVote) 
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Valide les propriétés d'une instance de <see cref="Organisateur"/> avant sa création ou sa modification.
        /// </summary>
        /// <param name="organisateur">Instance de <see cref="Organisateur"/> à valider.</param>
        /// <param name="estModification">Indique si la validation est pour une modification.</param>
        /// <exception cref="OrganisateurException">Exception levée si une validation échoue.</exception>
        public void ValiderOrganisateur(Organisateur organisateur, bool estModification = false)
        {
            if (organisateur.Login.Length > 12)
                throw new OrganisateurException("Le login ne peut pas dépasser 12 caractères.",
                    (int)OrganisateurException.OrganisateurErreur.LibelleTropLong);

            if (organisateur.Login.Length < 3)
                throw new OrganisateurException("Le login ne peut pas être inférieur à 3 caractères.",
                    (int)OrganisateurException.OrganisateurErreur.LibelleTropCourt);

            if (organisateur.motPasse.Contains(" "))
                throw new OrganisateurException("Le mot de passe ne peut pas contenir d'espaces.",
                    (int)OrganisateurException.OrganisateurErreur.MdpEspace);

            if (organisateur.motPasse.Length < 12)
                throw new OrganisateurException("Le mot de passe doit contenir au moins 12 caractères.",
                    (int)OrganisateurException.OrganisateurErreur.MdpTropCourt);

            if (organisateur.motPasse.Any(char.IsUpper) == false)
                throw new OrganisateurException("Le mot de passe doit contenir au moin 1 lettre majuscule.",
                    (int)OrganisateurException.OrganisateurErreur.MdpPasDeMajuscule);

            if (organisateur.motPasse.Any(char.IsDigit) == false)
                throw new OrganisateurException("Le mot de passe doit contenir au moin 1 chiffre.",
                    (int)OrganisateurException.OrganisateurErreur.MdpPasDeChiffre);

            if (organisateur.motPasse.Any(ch => !char.IsLetterOrDigit(ch)) == false)
                throw new OrganisateurException("Le mot de passe doit contenir au moin 1 caractère spécial.",
                    (int)OrganisateurException.OrganisateurErreur.MdpPasDeCaractereSpecial);

            if(!estModification && _context.Organisateurs.Any(o => o.Login == organisateur.Login))
                throw new OrganisateurException("Un organisateur avec ce login existe déjà.",
                    (int)OrganisateurException.OrganisateurErreur.LoginExistant);
        }
        #endregion
    }

}
