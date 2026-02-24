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

            if (!context.Espaces.Any())
            {
                context.Espaces.Add(new Espace 
                { Nom = "Nintendo", Description = "Espace dédié aux jeux de switch",
                    Superficie = 30, CapaciteMaxi = 30 });
                context.Espaces.Add(new Espace
                { Nom = "X Box", Description = "Espace dédié aux jeux sur support Xbox One et Xbox",
                    Superficie = 50, CapaciteMaxi = 40 });

                context.SaveChanges();
            }


            if (!context.Plateformes.Any())
            {
                context.Plateformes.Add(new Plateforme
                {
                    Libelle = "Nintendo 3DS"
                });
                context.Plateformes.Add(new Plateforme
                {
                    Libelle = "Playstation 5"
                });
                context.Plateformes.Add(new Plateforme
                {
                    Libelle = "XBOX 360"
                });
                context.SaveChanges();
            }

            if (!context.PostesJeu.Any())
            {
                context.PostesJeu.Add(new PosteJeu
                {
                    Reference = "PJ165268",
                    Fonctionnel = true,
                    IdEspace = context.Espaces.FirstOrDefault(e => e.Nom == "Nintendo").IdEspace,
                    IdPlateforme = context.Plateformes.FirstOrDefault(p => p.Libelle == "Nintendo 3DS").IdPlateforme
                });

                context.PostesJeu.Add(new PosteJeu
                {
                    Reference = "PJ645152",
                    Fonctionnel = false,
                    IdEspace = context.Espaces.FirstOrDefault(e => e.Nom == "X Box").IdEspace,
                    IdPlateforme = context.Plateformes.FirstOrDefault(p => p.Libelle == "XBOX 360").IdPlateforme
                });

                context.SaveChanges();
            }


            // Création des services
            var tournoiService = new TournoiService(context);
            var espaceService = new EspaceService(context);

            // lancement du formulaire principal
            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
    }
}