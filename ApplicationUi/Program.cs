using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
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

            // Création des services
            var tournoiService = new TournoiService(context);
            var espaceService = new EspaceService(context);
            var organisateurService = new OrganisateurService(context);
            var roleService = new RoleService(context);
            var lotComposantService = new LotComposantService(context);
            var lotService = new LotService(context);
            var jeuService = new JeuService(context);

            if (!context.Lots.Any())
            {
                context.Lots.AddRange(new List<Lot>
                {
                    new Lot { Libelle = "Lot de jeux vidéo", RangAttribution = 1},
                    new Lot { Libelle = "Lot de consoles de jeu", RangAttribution = 2},
                    new Lot { Libelle = "Lot de tapis de souris", RangAttribution = 3},
                    new Lot { Libelle = "Lot de cartes cadeaux", RangAttribution = 1},
                    new Lot { Libelle = "Lot de clavier", RangAttribution = 2},
                    new Lot { Libelle = "Lot de manettes", RangAttribution = 3}
                });
            }

            if (!context.Espaces.Any())
            {
                context.Espaces.AddRange(new List<Espace>
                {
                    new Espace { Nom = "Nintendo", Description = "Espace dédié aux jeux de switch", Superficie = 30, CapaciteMaxi = 30 },
                    new Espace { Nom = "X Box", Description = "Espace dédié aux jeux sur support Xbox One et Xbox", Superficie = 50, CapaciteMaxi = 40 },

                    new Espace { Nom = "PlayStation", Description = "Espace dédié aux jeux PS4 et PS5", Superficie = 45, CapaciteMaxi = 35 },
                    new Espace { Nom = "PC Gaming", Description = "Zone gaming sur ordinateurs performants", Superficie = 16, CapaciteMaxi = 25 },
                    new Espace { Nom = "Rétrogaming", Description = "Espace consoles anciennes et classiques", Superficie = 25, CapaciteMaxi = 20 },
                    new Espace { Nom = "VR Zone", Description = "Expériences en réalité virtuelle", Superficie = 40, CapaciteMaxi = 15 },
                    new Espace { Nom = "Arcade", Description = "Bornes d’arcade classiques", Superficie = 35, CapaciteMaxi = 20 },
                    new Espace { Nom = "Mobile Gaming", Description = "Jeux sur tablettes et smartphones", Superficie = 20, CapaciteMaxi = 15 },
                    new Espace { Nom = "Indie Games", Description = "Découverte de jeux indépendants", Superficie = 25, CapaciteMaxi = 20 },
                    new Espace { Nom = "Simulation", Description = "Simulateurs (course, vol, etc.)", Superficie = 50, CapaciteMaxi = 20 },
                    new Espace { Nom = "FPS Arena", Description = "Jeux de tir compétitifs", Superficie = 45, CapaciteMaxi = 30 },
                    new Espace { Nom = "MOBA Zone", Description = "Jeux de stratégie en équipe", Superficie = 40, CapaciteMaxi = 25 },
                    new Espace { Nom = "Fighting Games", Description = "Jeux de combat", Superficie = 30, CapaciteMaxi = 20 },
                    new Espace { Nom = "Sports Games", Description = "Jeux de sport (FIFA, NBA...)", Superficie = 35, CapaciteMaxi = 25 },
                    new Espace { Nom = "Party Games", Description = "Jeux fun en groupe", Superficie = 30, CapaciteMaxi = 30 },
                    new Espace { Nom = "Streaming Zone", Description = "Diffusion et création de contenu", Superficie = 25, CapaciteMaxi = 10 },
                    new Espace { Nom = "Esport Arena", Description = "Compétitions et tournois", Superficie = 25, CapaciteMaxi = 25 },
                    new Espace { Nom = "Coaching", Description = "Zone d’entraînement et coaching", Superficie = 20, CapaciteMaxi = 10 },
                    new Espace { Nom = "Casual Gaming", Description = "Jeux détente et accessibles", Superficie = 30, CapaciteMaxi = 20 },
                    new Espace { Nom = "LAN Party", Description = "Espace réseau local multijoueur", Superficie = 32, CapaciteMaxi = 50 },
                    new Espace { Nom = "Board Games", Description = "Jeux de société modernes", Superficie = 40, CapaciteMaxi = 30 },
                    new Espace { Nom = "Kids Zone", Description = "Espace enfants avec jeux adaptés", Superficie = 35, CapaciteMaxi = 20 }
                });
            }


            if (!context.Plateformes.Any())
            {
                context.Plateformes.AddRange(new List<Plateforme>
                {
                    new Plateforme { Libelle = "Nintendo 3DS" },
                    new Plateforme { Libelle = "Nintendo Switch" },
                    new Plateforme { Libelle = "Nintendo Switch 2" },
                    new Plateforme { Libelle = "Nintendo Wii U" },
                    new Plateforme { Libelle = "PlayStation 3" },
                    new Plateforme { Libelle = "PlayStation 4" },
                    new Plateforme { Libelle = "PlayStation 5" },
                    new Plateforme { Libelle = "PlayStation Portable (PSP)" },
                    new Plateforme { Libelle = "PlayStation Vita" },
                    new Plateforme { Libelle = "Xbox 360" },
                    new Plateforme { Libelle = "Xbox One" },
                    new Plateforme { Libelle = "Xbox Series X/S" },
                    new Plateforme { Libelle = "PC (Windows)" },
                    new Plateforme { Libelle = "PC (macOS)" },
                    new Plateforme { Libelle = "PC (Linux)" },
                    new Plateforme { Libelle = "iOS" },
                    new Plateforme { Libelle = "Android" },
                    new Plateforme { Libelle = "Stadia" },
                    new Plateforme { Libelle = "Steam Deck" },
                });
                context.SaveChanges();
            }

            if (!context.PostesJeu.Any())
            {
                var espaces = context.Espaces.ToList();
                var plateformes = context.Plateformes.ToList();

                Espace E(string nom) => espaces.First(e => e.Nom == nom);
                Plateforme P(string lib) => plateformes.First(p => p.Libelle == lib);

                context.PostesJeu.AddRange(new List<PosteJeu>
                {
                    // Nintendo
                    new PosteJeu { Reference = "PJ-NIN-001", Fonctionnel = true,  IdEspace = E("Nintendo").IdEspace, IdPlateforme = P("Nintendo Switch").IdPlateforme },
                    new PosteJeu { Reference = "PJ-NIN-002", Fonctionnel = true,  IdEspace = E("Nintendo").IdEspace, IdPlateforme = P("Nintendo Switch").IdPlateforme },
                    new PosteJeu { Reference = "PJ-NIN-003", Fonctionnel = true,  IdEspace = E("Nintendo").IdEspace, IdPlateforme = P("Nintendo Switch 2").IdPlateforme },
                    new PosteJeu { Reference = "PJ-NIN-004", Fonctionnel = false, IdEspace = E("Nintendo").IdEspace, IdPlateforme = P("Nintendo 3DS").IdPlateforme },
                    new PosteJeu { Reference = "PJ-NIN-005", Fonctionnel = true,  IdEspace = E("Nintendo").IdEspace, IdPlateforme = P("Nintendo Wii U").IdPlateforme },

                    // Xbox
                    new PosteJeu { Reference = "PJ-XBX-001", Fonctionnel = true,  IdEspace = E("X Box").IdEspace, IdPlateforme = P("Xbox Series X/S").IdPlateforme },
                    new PosteJeu { Reference = "PJ-XBX-002", Fonctionnel = true,  IdEspace = E("X Box").IdEspace, IdPlateforme = P("Xbox Series X/S").IdPlateforme },
                    new PosteJeu { Reference = "PJ-XBX-003", Fonctionnel = true,  IdEspace = E("X Box").IdEspace, IdPlateforme = P("Xbox One").IdPlateforme },
                    new PosteJeu { Reference = "PJ-XBX-004", Fonctionnel = false, IdEspace = E("X Box").IdEspace, IdPlateforme = P("Xbox One").IdPlateforme },
                    new PosteJeu { Reference = "PJ-XBX-005", Fonctionnel = true,  IdEspace = E("X Box").IdEspace, IdPlateforme = P("Xbox 360").IdPlateforme },

                    // PlayStation
                    new PosteJeu { Reference = "PJ-PSN-001", Fonctionnel = true,  IdEspace = E("PlayStation").IdEspace, IdPlateforme = P("PlayStation 5").IdPlateforme },
                    new PosteJeu { Reference = "PJ-PSN-002", Fonctionnel = true,  IdEspace = E("PlayStation").IdEspace, IdPlateforme = P("PlayStation 5").IdPlateforme },
                    new PosteJeu { Reference = "PJ-PSN-003", Fonctionnel = true,  IdEspace = E("PlayStation").IdEspace, IdPlateforme = P("PlayStation 4").IdPlateforme },
                    new PosteJeu { Reference = "PJ-PSN-004", Fonctionnel = false, IdEspace = E("PlayStation").IdEspace, IdPlateforme = P("PlayStation 4").IdPlateforme },
                    new PosteJeu { Reference = "PJ-PSN-005", Fonctionnel = true,  IdEspace = E("PlayStation").IdEspace, IdPlateforme = P("PlayStation 3").IdPlateforme },

                    // PC Gaming
                    new PosteJeu { Reference = "PJ-PCG-001", Fonctionnel = true,  IdEspace = E("PC Gaming").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-PCG-002", Fonctionnel = true,  IdEspace = E("PC Gaming").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-PCG-003", Fonctionnel = true,  IdEspace = E("PC Gaming").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-PCG-004", Fonctionnel = false, IdEspace = E("PC Gaming").IdEspace, IdPlateforme = P("PC (Linux)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-PCG-005", Fonctionnel = true,  IdEspace = E("PC Gaming").IdEspace, IdPlateforme = P("Steam Deck").IdPlateforme },

                    // Rétrogaming
                    new PosteJeu { Reference = "PJ-RTR-001", Fonctionnel = true,  IdEspace = E("Rétrogaming").IdEspace, IdPlateforme = P("PlayStation 3").IdPlateforme },
                    new PosteJeu { Reference = "PJ-RTR-002", Fonctionnel = true,  IdEspace = E("Rétrogaming").IdEspace, IdPlateforme = P("Xbox 360").IdPlateforme },
                    new PosteJeu { Reference = "PJ-RTR-003", Fonctionnel = false, IdEspace = E("Rétrogaming").IdEspace, IdPlateforme = P("Nintendo 3DS").IdPlateforme },
                    new PosteJeu { Reference = "PJ-RTR-004", Fonctionnel = true,  IdEspace = E("Rétrogaming").IdEspace, IdPlateforme = P("PlayStation Portable (PSP)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-RTR-005", Fonctionnel = true,  IdEspace = E("Rétrogaming").IdEspace, IdPlateforme = P("PlayStation Vita").IdPlateforme },

                    // VR Zone
                    new PosteJeu { Reference = "PJ-VRZ-001", Fonctionnel = true,  IdEspace = E("VR Zone").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-VRZ-002", Fonctionnel = true,  IdEspace = E("VR Zone").IdEspace, IdPlateforme = P("PlayStation 5").IdPlateforme },
                    new PosteJeu { Reference = "PJ-VRZ-003", Fonctionnel = false, IdEspace = E("VR Zone").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },

                    // Esport Arena
                    new PosteJeu { Reference = "PJ-ESA-001", Fonctionnel = true,  IdEspace = E("Esport Arena").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-ESA-002", Fonctionnel = true,  IdEspace = E("Esport Arena").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-ESA-003", Fonctionnel = true,  IdEspace = E("Esport Arena").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-ESA-004", Fonctionnel = true,  IdEspace = E("Esport Arena").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-ESA-005", Fonctionnel = false, IdEspace = E("Esport Arena").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },

                    // LAN Party
                    new PosteJeu { Reference = "PJ-LAN-001", Fonctionnel = true,  IdEspace = E("LAN Party").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-LAN-002", Fonctionnel = true,  IdEspace = E("LAN Party").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-LAN-003", Fonctionnel = true,  IdEspace = E("LAN Party").IdEspace, IdPlateforme = P("PC (Linux)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-LAN-004", Fonctionnel = false, IdEspace = E("LAN Party").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },

                    // Mobile Gaming
                    new PosteJeu { Reference = "PJ-MOB-001", Fonctionnel = true,  IdEspace = E("Mobile Gaming").IdEspace, IdPlateforme = P("iOS").IdPlateforme },
                    new PosteJeu { Reference = "PJ-MOB-002", Fonctionnel = true,  IdEspace = E("Mobile Gaming").IdEspace, IdPlateforme = P("Android").IdPlateforme },
                    new PosteJeu { Reference = "PJ-MOB-003", Fonctionnel = false, IdEspace = E("Mobile Gaming").IdEspace, IdPlateforme = P("Android").IdPlateforme },

                    // Simulation
                    new PosteJeu { Reference = "PJ-SIM-001", Fonctionnel = true,  IdEspace = E("Simulation").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-SIM-002", Fonctionnel = true,  IdEspace = E("Simulation").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme },
                    new PosteJeu { Reference = "PJ-SIM-003", Fonctionnel = false, IdEspace = E("Simulation").IdEspace, IdPlateforme = P("Xbox Series X/S").IdPlateforme },

                    // Fighting Games
                    new PosteJeu { Reference = "PJ-FGT-001", Fonctionnel = true,  IdEspace = E("Fighting Games").IdEspace, IdPlateforme = P("PlayStation 5").IdPlateforme },
                    new PosteJeu { Reference = "PJ-FGT-002", Fonctionnel = true,  IdEspace = E("Fighting Games").IdEspace, IdPlateforme = P("Xbox Series X/S").IdPlateforme },
                    new PosteJeu { Reference = "PJ-FGT-003", Fonctionnel = true,  IdEspace = E("Fighting Games").IdEspace, IdPlateforme = P("Nintendo Switch").IdPlateforme },

                    // Sports Games
                    new PosteJeu { Reference = "PJ-SPT-001", Fonctionnel = true,  IdEspace = E("Sports Games").IdEspace, IdPlateforme = P("PlayStation 5").IdPlateforme },
                    new PosteJeu { Reference = "PJ-SPT-002", Fonctionnel = true,  IdEspace = E("Sports Games").IdEspace, IdPlateforme = P("Xbox Series X/S").IdPlateforme },
                    new PosteJeu { Reference = "PJ-SPT-003", Fonctionnel = false, IdEspace = E("Sports Games").IdEspace, IdPlateforme = P("PlayStation 4").IdPlateforme },

                    // Party Games
                    new PosteJeu { Reference = "PJ-PTY-001", Fonctionnel = true,  IdEspace = E("Party Games").IdEspace, IdPlateforme = P("Nintendo Switch").IdPlateforme },
                    new PosteJeu { Reference = "PJ-PTY-002", Fonctionnel = true,  IdEspace = E("Party Games").IdEspace, IdPlateforme = P("Nintendo Switch 2").IdPlateforme },
                    new PosteJeu { Reference = "PJ-PTY-003", Fonctionnel = true,  IdEspace = E("Party Games").IdEspace, IdPlateforme = P("PlayStation 5").IdPlateforme },
                });

                context.SaveChanges();
            }

            // Créé les rôles si pas déjà fait
            if (!context.Roles.Any())
            {
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

            // Créé un utilisateur admin si pas déjà fait
            if (!context.Organisateurs.Any())
            {
                organisateurService.Creer(new Organisateur
                {
                    Login = "admin",
                    motPasse = "SIO2026+",
                    Mail = "mailSio2026@gmail.com",
                    IdRole = context.Roles.FirstOrDefault(r => r.Libelle == "Administrateur").IdRole
                });
            }

            if (!context.Jeux.Any())
            {
                var jeux = new List<(string Titre, string Description, string Editeur, string Annee, int Pegi, DateTime Date)>
                {
                    // Nintendo
                    ("Mario Kart 8 Deluxe",       "Terminer les courses en première position en utilisant des objets pour ralentir les adversaires ou se protéger",                                        "Nintendo",         "2017", 3,  new DateTime(2017, 04, 28)),
                    ("The Legend of Zelda: BOTW",  "Explorez un vaste monde ouvert pour libérer le royaume d'Hyrule des griffes de Calamity Ganon",                                                      "Nintendo",         "2017", 12, new DateTime(2017, 03, 03)),
                    ("The Legend of Zelda: TOTK",  "Continuez l'aventure dans un Hyrule transformé, avec de nouvelles îles célestes et des pouvoirs inédits",                                            "Nintendo",         "2023", 12, new DateTime(2023, 05, 12)),
                    ("Super Smash Bros. Ultimate", "Affrontez des adversaires avec des personnages iconiques de nombreuses franchises dans des combats frénétiques",                                      "Nintendo",         "2018", 12, new DateTime(2018, 12, 07)),
                    ("Splatoon 3",                 "Participez à des batailles de peinture colorées en équipe de quatre joueurs dans des arènes variées",                                                 "Nintendo",         "2022", 7,  new DateTime(2022, 09, 09)),
                    ("Pokémon Écarlate",           "Devenez le meilleur dresseur dans une région ouverte en capturant et entraînant des centaines de Pokémon",                                           "Game Freak",       "2022", 7,  new DateTime(2022, 11, 18)),
                    ("Animal Crossing: NH",        "Construisez et personnalisez votre île déserte en rencontrant des habitants animaux attachants",                                                      "Nintendo",         "2020", 3,  new DateTime(2020, 03, 20)),
                    ("Super Mario Odyssey",        "Parcourez des royaumes colorés pour récupérer les Lunes de puissance et sauver la princesse Peach",                                                  "Nintendo",         "2017", 7,  new DateTime(2017, 10, 27)),

                    // PlayStation
                    ("God of War Ragnarök",        "Incarnez Kratos et son fils Atreus dans une épopée nordique vers le crépuscule des dieux",                                                           "Sony Santa Monica", "2022", 18, new DateTime(2022, 11, 09)),
                    ("Spider-Man 2",               "Incarnez Peter Parker et Miles Morales pour défendre New York contre de nouveaux ennemis redoutables",                                               "Insomniac Games",  "2023", 16, new DateTime(2023, 10, 20)),
                    ("Horizon Forbidden West",     "Explorez des terres inconnues et affrontez des machines colossales pour percer les mystères d'une catastrophe imminente",                            "Guerrilla Games",  "2022", 16, new DateTime(2022, 02, 18)),
                    ("The Last of Us Part I",      "Survivez dans un monde post-apocalyptique ravagé par une infection fongique en escortant une jeune fille à travers les États-Unis",                  "Naughty Dog",      "2022", 18, new DateTime(2022, 09, 02)),
                    ("Gran Turismo 7",             "Vivez l'expérience de simulation automobile ultime avec des centaines de voitures et circuits authentiques",                                          "Polyphony Digital", "2022", 3, new DateTime(2022, 03, 04)),

                    // Xbox / Microsoft
                    ("Halo Infinite",              "Incarnez le Master Chief pour repousser une nouvelle menace alien dans un monde semi-ouvert",                                                        "343 Industries",   "2021", 16, new DateTime(2021, 12, 08)),
                    ("Forza Horizon 5",            "Explorez un immense monde ouvert mexicain au volant de centaines de voitures de rêve",                                                               "Playground Games", "2021", 3,  new DateTime(2021, 11, 09)),
                    ("Sea of Thieves",             "Devenez un pirate légendaire en explorant les mers, chassant des trésors et affrontant d'autres équipages",                                          "Rare",             "2018", 12, new DateTime(2018, 03, 20)),

                    // PC / Multi
                    ("Minecraft",                  "Construisez, explorez et survivez dans un monde infini généré aléatoirement en blocs",                                                               "Mojang",           "2011", 7,  new DateTime(2011, 11, 18)),
                    ("Cyberpunk 2077",             "Incarnez V, un mercenaire dans la mégalopole Night City, dans un RPG d'action futuriste aux choix déterminants",                                     "CD Projekt Red",   "2020", 18, new DateTime(2020, 12, 10)),
                    ("Elden Ring",                 "Explorez les Terres Intermédiaires dans un RPG d'action en monde ouvert d'une difficulté légendaire",                                                "FromSoftware",     "2022", 16, new DateTime(2022, 02, 25)),
                    ("Baldur's Gate 3",            "Vivez une aventure RPG au tour par tour colossale dans l'univers de Donjons & Dragons avec une liberté de choix totale",                             "Larian Studios",   "2023", 18, new DateTime(2023, 08, 03)),
                    ("Stardew Valley",             "Gérez votre ferme, cultivez, élevez des animaux et tissez des liens avec les habitants d'un charmant village",                                       "ConcernedApe",     "2016", 7,  new DateTime(2016, 02, 26)),
                    ("Among Us",                   "Démasquez les imposteurs à bord d'un vaisseau spatial en accomplissant des tâches et en votant pour éliminer les suspects",                          "InnerSloth",       "2018", 7,  new DateTime(2018, 06, 15)),
                    ("Valorant",                   "Affrontez des équipes adverses dans un FPS tactique 5v5 où chaque agent possède des capacités uniques",                                              "Riot Games",       "2020", 16, new DateTime(2020, 06, 02)),
                    ("League of Legends",          "Défendez votre base et détruisez celle de l'ennemi dans des parties de MOBA stratégiques à 5 contre 5",                                             "Riot Games",       "2009", 12, new DateTime(2009, 10, 27)),
                    ("Counter-Strike 2",           "Affrontez des terroristes ou défendez les otages dans le FPS tactique compétitif de référence",                                                      "Valve",            "2023", 18, new DateTime(2023, 09, 27)),

                    // Multi-plateforme récents
                    ("Schedule 1",                 "From small-time dope pusher to kingpin - manufacture and distribute a range of drugs throughout the grungy city of Hyland Point",                   "TVGS",             "2025", 18, new DateTime(2025, 04, 24)),
                    ("Hogwarts Legacy",            "Vivez votre propre aventure de sorcier au XIXe siècle dans un Poudlard en monde ouvert regorgeant de secrets",                                       "Avalanche Software","2023", 12, new DateTime(2023, 02, 10)),
                    ("EA Sports FC 25",            "Vivez l'expérience football ultime avec des licences officielles, des modes carrière enrichis et l'Ultimate Team",                                   "EA Sports",        "2024", 3,  new DateTime(2024, 09, 27)),
                    ("Call of Duty: Black Ops 6",  "Plongez dans une campagne solo haletante et des modes multijoueurs intenses dans le dernier opus de la franchise emblématique",                      "Treyarch",         "2024", 18, new DateTime(2024, 10, 25)),
                    ("Fortnite",                   "Survivez et soyez le dernier joueur debout dans un Battle Royale en constante évolution avec des collaborations pop culture",                        "Epic Games",       "2017", 12, new DateTime(2017, 07, 25)),
                };

                foreach (var j in jeux)
                {
                    jeuService.Creer(new Jeu
                    {
                        Titre = j.Titre,
                        Description = j.Description,
                        Editeur = j.Editeur,
                        AnneeSortie = j.Annee,
                        Pegi = j.Pegi,
                        DateSortie = j.Date
                    });
                }
            }

            // lancement du formulaire principal
            ApplicationConfiguration.Initialize();
            Application.Run(new FormAuthentification());
        }
    }
}