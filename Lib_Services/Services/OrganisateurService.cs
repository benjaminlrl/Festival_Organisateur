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

        /// <summary>
        /// Retourne la liste complète des organisateur présents en base.
        /// Exécute immédiatement la requête via <c>ToList()</c>.
        /// </summary>
        /// <param name="filtre">Optionnel : libellé à filtrer.</param>
        /// <returns>Liste d'objets <see cref="Organisateur"/>.</returns>
        public List<Organisateur> Lister(string filtre = "")
        {
            // Include(t => t.Role) pour éviter le chargement paresseux lors de l'affichage.
            if (string.IsNullOrWhiteSpace(filtre))
                return _context.Organisateurs
                     .Include(r => r.Role)
                     .ToList();
            return
                _context.Organisateurs
                .Include(r => r.Role)
                .Where(r => r.Login.Contains(filtre))
                .ToList();
        }

        /// <summary>
        /// Récupère un organisateur par son login.
        /// </summary>
        /// <param name="Login">Login de l'organisateur cherché.</param>
        /// <returns>L'entité <see cref="Organisateur"/> si trouvée, sinon null.</returns>
        public Organisateur? Obtenir(string Login)
        {
            return _context.Organisateurs
                           .Include(o => o.Role)
                           .FirstOrDefault(o => o.Login == Login);
        }

        /// <summary>
        /// Crée un nouvel organisateur en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Organisateur"/> à créer.</param>
        public void Creer(Organisateur organisateur)
        {
            // Ajout de l'entité au contexte puis persistance immédiate.
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
            _context.Organisateurs.Update(organisateur);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un organisateur identifié par son login s'il existe.
        /// </summary>
        /// <param name="Login">Login de l'organisateur à supprimer.</param>
        public void Supprimer(string Login)
        {
            // Recherche de l'entité (utilise le cache si possible).
            var organisateur = _context.Organisateurs.Find(Login);
            if (organisateur != null)
            {
                _context.Organisateurs.Remove(organisateur);
                _context.SaveChanges();
            }
        }

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
        public bool estAutoriser(Organisateur unOrganisateur, Organisateur.LesUC unUC, string action)
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
            // CRUD: Tournoi, Participer, SoumisVote
            if (role.Libelle == "Gestionnaire des tournois")
            {
                if (action == "Consulter")
                {
                    if (unUC == Organisateur.LesUC.UcEspaces        || unUC == Organisateur.LesUC.UcPostesDeJeu 
                        || unUC == Organisateur.LesUC.UcPlateformes || unUC == Organisateur.LesUC.UcPostesDeJeu
                        || unUC == Organisateur.LesUC.UcJeux        || unUC == Organisateur.LesUC.UcLots 
                        || unUC == Organisateur.LesUC.UcVoter) 
                    {
                        return true;
                    }
                }
                else if (action == "Modifier" || action == "Supprimer" || action == "Ajouter")
                {
                    if (unUC == Organisateur.LesUC.UcTournois || unUC == Organisateur.LesUC.UcParticiper 
                        || unUC == Organisateur.LesUC.UcVoter) 
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Permet de voir si un mot de passe est conformes aux règles de sécurité suivantes 
        /// </summary>
        /// <param name="motDePasse"></param>
        /// <returns>la liste des msgs d'erreurs.</returns>
        public List<string> MdpValide(string motDePasse)
        {
            // liste des erreurs
            var erreurs = new List<string>();

            if(string.IsNullOrWhiteSpace(motDePasse))
            {
                erreurs.Add("Le mot de passe ne peut pas être vide.");
            }
            if (motDePasse.Contains(" "))
            {
                erreurs.Add("Le mot de passe ne peut pas contenir d'espace.");
            }
            if (motDePasse.Length < 12)
            {
                erreurs.Add("Le mot de passe doit contenir plus de 12 caractères.");
            }
            if (motDePasse.Any(char.IsUpper) == false)
            {
                erreurs.Add("Le mot de passe doit contenir au moins 1 majuscule.");
            }
            if (motDePasse.Any(char.IsDigit) == false)
            {
                erreurs.Add("Le mot de passe doit contenir au moins 1 chiffre.");
            }
            if (motDePasse.Any(ch => !char.IsLetterOrDigit(ch)) == false)
            {
                erreurs.Add("Le mot de passe doit contenir au moins 1 caractère spéciale.");
            }
            return erreurs;
        }

        /// <summary>
        /// Permet de voir si un identifiant est conformes aux règles de sécurité suivantes
        /// </summary>
        /// <param name="identifiant"></param>
        /// <returns>la liste des msgs d'erreurs.</returns>
        public List<string> IdentifiantValide(string identifiant)
        {
            // liste des erreurs
            var erreurs = new List<string>();

            if (string.IsNullOrWhiteSpace(identifiant))
            {
                erreurs.Add("Le login ne peut pas être vide.");
            }
            if (identifiant.Length < 3 || identifiant.Length > 12)
            {
                erreurs.Add("Le login doit contenir entre 3 et 12 caractères.");
            }
            return erreurs;
        }
    }

}
