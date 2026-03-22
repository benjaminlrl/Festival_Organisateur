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
        /// <returns>Liste d'objets <see cref="Organisateur"/>.</returns>
        public List<Organisateur> Lister()
        {
            // Include(e => e.Espace) pour éviter le chargement paresseux lors de l'affichage.
            return _context.Organisateur
                           .Include(t => t.Role)
                           .ToList();
        }

        /// <summary>
        /// Récupère un organisateur par son login.
        /// </summary>
        /// <param name="Login">Login de l'organisateur cherché.</param>
        /// <returns>L'entité <see cref="Organisateur"/> si trouvée, sinon null.</returns>
        public Organisateur? Obtenir(string Login)
        {
            // Find utilise le cache du contexte s'il existe, sinon interroge la base.
            return _context.Organisateur.Find(Login);
        }

        /// <summary>
        /// Crée un nouvel organisateur en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="espace">Instance de <see cref="Organisateur"/> à créer.</param>
        public void Creer(Organisateur organisateur)
        {
            // Regarde si le login n'existe pas déjà
            if(Obtenir(organisateur.Login) != null)
                throw new InvalidOperationException("Ce login est déjà pris.");
            // Ajout de l'entité au contexte puis persistance immédiate.
            // Hashe du mot de passe via BCrypt.
            organisateur.motPasse = BCrypt.Net.BCrypt.HashPassword(organisateur.motPasse);
            _context.Organisateur.Add(organisateur);
            _context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un organisateur existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="espace">Instance modifiée de <see cref="Organisateur"/>.</param>
        public void Modifier(Organisateur organisateur)
        {
            _context.Organisateur.Update(organisateur);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime un organisateur identifié par son login s'il existe.
        /// </summary>
        /// <param name="Login">Login de l'organisateur à supprimer.</param>
        public void Supprimer(string Login)
        {
            // Recherche de l'entité (utilise le cache si possible).
            var organisateur = _context.Organisateur.Find(Login);
            if (organisateur != null)
                _context.Organisateur.Remove(organisateur);
                _context.SaveChanges();
        }

        /// <summary>
        /// Vérifie si les informations d'identification fournies correspondent à un organisateur existant.
        /// </summary>
        /// <param name="motDePasse">Le mot de passe hashé de l'organisateur.</param>
        /// <param name="identifiant">Le login de l'organisateur.</param>
        /// <returns>True si il est identique, false si non</returns>
        public bool EstIdentique(string motDePasse, string identifiant)
        {
            var organisateur = _context.Organisateur.Find(identifiant);
            if (organisateur == null)
                return false;
            return BCrypt.Net.BCrypt.Verify(motDePasse, organisateur.motPasse);
        }
        /// <summary>
        /// Retourne si l'organisateur a accès au UserController (unUC) demandée avec telle action
        /// Consulter - Modifier - Supprimer
        /// </summary>
        /// <returns>"true" (en string) si il a l'autorisation, sinon un msg d'erreur.</returns>
        public string estAutoriser(Organisateur unOrganisateur, Organisateur.LesUC unUC, string action)
        {
            Role role = unOrganisateur.Role;
            // Les administrateurs ont le droit à tout
            if (role.Libelle == "Administrateur")
            {
                return "true";
            }

            // Role Gestionnaire de stock
            if (role.Libelle == "Gestionnaire de Stock")
            {
                if (action == "Consulter")
                {
                    if (unUC == Organisateur.LesUC.UcTournois) //Rajouter interface Jeu,Espace,PosteJeu,Plateforme, Lot & LotComposant
                    {
                        return "true";
                    }
                }
                else if (action == "Modifier" || action == "Supprimer")
                {
                    if (unUC == Organisateur.LesUC.UcTournois) //Modifier en Lot & LotComposant
                    {
                        return "true";
                    }
                }
            }

            //Role Gestionnaire de l'Espace
            if (role.Libelle == "Gestionnaire de l'Espace")
            {
                if (action == "Consulter")
                {
                    if (unUC == Organisateur.LesUC.UcTournois) //Ajouter Plateforme,Jeu,Participer
                    {
                        return "true";
                    }
                }
                else if (action == "Modifier" || action == "Supprimer")
                {
                    if (unUC == Organisateur.LesUC.UcTournois) //Ajouter Espace,PosteJeu
                    {
                        return "true";
                    }
                }
            }

            //Role Gestionnaire des tournois
            if (role.Libelle == "Gestionnaire des tournois")
            {
                if (action == "Consulter")
                {
                    if (unUC == Organisateur.LesUC.UcTournois) //Ajouter Participer, SoumisVote, Espace,
                                                       //PosteJeu, Plateforme, Jeu, Lot, Voter
                    {
                        return "true";
                    }
                }
                else if (action == "Modifier" || action == "Supprimer")
                {
                    if (unUC == Organisateur.LesUC.UcTournois) //Ajouter Participer, SoumisVote
                    {
                        return "true";
                    }
                }
            }
            return "error|Vous n'avez pas les droits d'accès.";
        }
    }

}
