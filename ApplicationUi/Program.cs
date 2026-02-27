using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApplicationUi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialise la base si elle n'existe pas
            using var context = new ApplicationDbContext();

            // Applique toutes les migrations en attente
            context.Database.Migrate();

            if (!context.Espace.Any())
            {
                context.Espace.Add(new Espace 
                { Nom = "Nintendo", Description = "Espace dédié aux jeux de switch",
                    Superficie = 30, CapaciteMaxi = 30 });
                context.Espace.Add(new Espace
                { Nom = "X Box", Description = "Espace dédié aux jeux sur support Xbox One et Xbox",
                    Superficie = 50, CapaciteMaxi = 40 });

                context.SaveChanges();
            }
            

            // Création des services
            var tournoiService = new TournoiService(context);
            var espaceService = new EspaceService(context);

            // Créé les rôles si pas déjà fait
            if (!context.Role.Any())
            {
                var roleService = new RoleService(context);
                roleService.Creer(new Role
                {
                    Libelle = "Administrateur"
                });
                roleService.Creer(new Role
                {
                    Libelle = "Gestionnaire du stock"
                });
                roleService.Creer(new Role
                {
                    Libelle = "Gestionnaire de l'espace"
                });
                roleService.Creer(new Role
                {
                    Libelle = "Gestionnaire des tournois"
                });
            }

            // Créé un utilisateur si y'a rien dedans
            if (!context.Organisateur.Any())
            {
                var roleService = new RoleService(context);
                var organisateurService = new OrganisateurService(context);
                organisateurService.Creer(new Organisateur
                {
                    Login = "admin",
                    motPasse = "SIO2026+",
                    Mail = "mailSio2026@gmail.com",
                    Role = roleService.Obtenir("Administrateur")!
                });
            }

            // lancement du formulaire principal
            ApplicationConfiguration.Initialize();
            Application.Run(new FormAuthentification());
        }
    }
}