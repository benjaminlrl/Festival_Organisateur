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
                    new Lot { Libelle = "Lot de casque", RangAttribution = 2},
                    new Lot { Libelle = "Lot de tapis de souris", RangAttribution = 3},
                    new Lot { Libelle = "Lot de cartes cadeaux", RangAttribution = 1},
                    new Lot { Libelle = "Lot de clavier", RangAttribution = 2},
                    new Lot { Libelle = "Lot de manettes", RangAttribution = 3}
                });
            }

            if (!context.LotComposants.Any())
            {
                context.LotComposants.AddRange(new List<LotComposant>
                {
                    new LotComposant { Libelle = "PS4", Description = "Console de jeu de type Playstation", Valeur = 250 },
                    new LotComposant { Libelle = "PS5", Description = "Console de jeu de type Playstation", Valeur = 350 },
                    new LotComposant { Libelle = "Xbox One", Description = "Console de jeu de type Xbox", Valeur = 325 },
                    new LotComposant { Libelle = "Clavier Razer Ornata V2", Description = "Clavier gamer de marque Razer", Valeur = 80 },
                    new LotComposant { Libelle = "Clavier Klim", Description = "Clavier gamer de marque Klim", Valeur = 30 },
                    new LotComposant { Libelle = "Souris Razer Naga Trinity", Description = "Souris gamer de marque Razer", Valeur = 70 },
                    new LotComposant { Libelle = "Souris Logitech G Pro X", Description = "Souris gamer de marque Logitech", Valeur = 75 },
                    new LotComposant { Libelle = "Manettes PS4", Description = "Manette de marque Playstation", Valeur = 40 },
                    new LotComposant { Libelle = "Manettes Xbox", Description = "Manette de marque Xbox", Valeur = 50 },
                    new LotComposant { Libelle = "Casque Razer Kraken", Description = "Casque gamer de marque Razer", Valeur = 60 },
                    new LotComposant { Libelle = "Casque HyperX Cloud 2", Description = "Casque gamer de marque HyperX", Valeur = 54 },
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

                organisateurService.Creer(new Organisateur
                {
                    Login = "admin_stock",
                    motPasse = "SIO2026+",
                    Mail = "mailSio2026@gmail.com",
                    IdRole = context.Roles.FirstOrDefault(r => r.Libelle == "Gestionnaire du stock").IdRole
                });

                organisateurService.Creer(new Organisateur
                {
                    Login = "admin_espace",
                    motPasse = "SIO2026+",
                    Mail = "mailSio2026@gmail.com",
                    IdRole = context.Roles.FirstOrDefault(r => r.Libelle == "Gestionnaire de l'espace").IdRole
                });

                organisateurService.Creer(new Organisateur
                {
                    Login = "admin_tournois",
                    motPasse = "SIO2026+",
                    Mail = "mailSio2026@gmail.com",
                    IdRole = context.Roles.FirstOrDefault(r => r.Libelle == "Gestionnaire des tournois").IdRole
                });
            }

            if (!context.Jeux.Any())
            {
                var plateformes = context.Plateformes.ToList();
                Plateforme P(string lib) => plateformes.First(p => p.Libelle == lib);

                var jeux = new List<Jeu>
                {
                    // Nintendo
                    new Jeu { Titre = "Mario Kart 8 Deluxe",       Description = "Terminer les courses en première position en utilisant des objets pour ralentir les adversaires ou se protéger",                          Editeur = "Nintendo",          AnneeSortie = "2017", Pegi = 3,  DateSortie = new DateTime(2017, 04, 28),
                        Plateformes = new List<Plateforme> { P("Nintendo Switch"), P("Nintendo Switch 2"), P("Nintendo Wii U") } },

                    new Jeu { Titre = "The Legend of Zelda: BOTW",  Description = "Explorez un vaste monde ouvert pour libérer le royaume d'Hyrule des griffes de Calamity Ganon",                                          Editeur = "Nintendo",          AnneeSortie = "2017", Pegi = 12, DateSortie = new DateTime(2017, 03, 03),
                        Plateformes = new List<Plateforme> { P("Nintendo Switch"), P("Nintendo Switch 2"), P("Nintendo Wii U") } },

                    new Jeu { Titre = "The Legend of Zelda: TOTK",  Description = "Continuez l'aventure dans un Hyrule transformé, avec de nouvelles îles célestes et des pouvoirs inédits",                                Editeur = "Nintendo",          AnneeSortie = "2023", Pegi = 12, DateSortie = new DateTime(2023, 05, 12),
                        Plateformes = new List<Plateforme> { P("Nintendo Switch"), P("Nintendo Switch 2") } },

                    new Jeu { Titre = "Super Smash Bros. Ultimate", Description = "Affrontez des adversaires avec des personnages iconiques de nombreuses franchises dans des combats frénétiques",                          Editeur = "Nintendo",          AnneeSortie = "2018", Pegi = 12, DateSortie = new DateTime(2018, 12, 07),
                        Plateformes = new List<Plateforme> { P("Nintendo Switch"), P("Nintendo Switch 2") } },

                    new Jeu { Titre = "Splatoon 3",                 Description = "Participez à des batailles de peinture colorées en équipe de quatre joueurs dans des arènes variées",                                    Editeur = "Nintendo",          AnneeSortie = "2022", Pegi = 7,  DateSortie = new DateTime(2022, 09, 09),
                        Plateformes = new List<Plateforme> { P("Nintendo Switch"), P("Nintendo Switch 2") } },

                    new Jeu { Titre = "Pokémon Écarlate",           Description = "Devenez le meilleur dresseur dans une région ouverte en capturant et entraînant des centaines de Pokémon",                              Editeur = "Game Freak",        AnneeSortie = "2022", Pegi = 7,  DateSortie = new DateTime(2022, 11, 18),
                        Plateformes = new List<Plateforme> { P("Nintendo Switch"), P("Nintendo Switch 2") } },

                    new Jeu { Titre = "Animal Crossing: NH",        Description = "Construisez et personnalisez votre île déserte en rencontrant des habitants animaux attachants",                                          Editeur = "Nintendo",          AnneeSortie = "2020", Pegi = 3,  DateSortie = new DateTime(2020, 03, 20),
                        Plateformes = new List<Plateforme> { P("Nintendo Switch"), P("Nintendo Switch 2") } },

                    new Jeu { Titre = "Super Mario Odyssey",        Description = "Parcourez des royaumes colorés pour récupérer les Lunes de puissance et sauver la princesse Peach",                                      Editeur = "Nintendo",          AnneeSortie = "2017", Pegi = 7,  DateSortie = new DateTime(2017, 10, 27),
                        Plateformes = new List<Plateforme> { P("Nintendo Switch"), P("Nintendo Switch 2") } },

                    // PlayStation
                    new Jeu { Titre = "God of War Ragnarök",        Description = "Incarnez Kratos et son fils Atreus dans une épopée nordique vers le crépuscule des dieux",                                               Editeur = "Sony Santa Monica", AnneeSortie = "2022", Pegi = 18, DateSortie = new DateTime(2022, 11, 09),
                        Plateformes = new List<Plateforme> { P("PlayStation 4"), P("PlayStation 5"), P("PC (Windows)") } },

                    new Jeu { Titre = "Spider-Man 2",               Description = "Incarnez Peter Parker et Miles Morales pour défendre New York contre de nouveaux ennemis redoutables",                                    Editeur = "Insomniac Games",   AnneeSortie = "2023", Pegi = 16, DateSortie = new DateTime(2023, 10, 20),
                        Plateformes = new List<Plateforme> { P("PlayStation 5"), P("PC (Windows)") } },

                    new Jeu { Titre = "Horizon Forbidden West",     Description = "Explorez des terres inconnues et affrontez des machines colossales pour percer les mystères d'une catastrophe imminente",                Editeur = "Guerrilla Games",   AnneeSortie = "2022", Pegi = 16, DateSortie = new DateTime(2022, 02, 18),
                        Plateformes = new List<Plateforme> { P("PlayStation 4"), P("PlayStation 5"), P("PC (Windows)") } },

                    new Jeu { Titre = "The Last of Us Part I",      Description = "Survivez dans un monde post-apocalyptique ravagé par une infection fongique en escortant une jeune fille à travers les États-Unis",      Editeur = "Naughty Dog",       AnneeSortie = "2022", Pegi = 18, DateSortie = new DateTime(2022, 09, 02),
                        Plateformes = new List<Plateforme> { P("PlayStation 5"), P("PC (Windows)") } },

                    new Jeu { Titre = "Gran Turismo 7",             Description = "Vivez l'expérience de simulation automobile ultime avec des centaines de voitures et circuits authentiques",                              Editeur = "Polyphony Digital", AnneeSortie = "2022", Pegi = 3,  DateSortie = new DateTime(2022, 03, 04),
                        Plateformes = new List<Plateforme> { P("PlayStation 4"), P("PlayStation 5") } },

                    // Xbox / Microsoft
                    new Jeu { Titre = "Halo Infinite",              Description = "Incarnez le Master Chief pour repousser une nouvelle menace alien dans un monde semi-ouvert",                                             Editeur = "343 Industries",    AnneeSortie = "2021", Pegi = 16, DateSortie = new DateTime(2021, 12, 08),
                        Plateformes = new List<Plateforme> { P("Xbox One"), P("Xbox Series X/S"), P("PC (Windows)") } },

                    new Jeu { Titre = "Forza Horizon 5",            Description = "Explorez un immense monde ouvert mexicain au volant de centaines de voitures de rêve",                                                   Editeur = "Playground Games",  AnneeSortie = "2021", Pegi = 3,  DateSortie = new DateTime(2021, 11, 09),
                        Plateformes = new List<Plateforme> { P("Xbox One"), P("Xbox Series X/S"), P("PC (Windows)") } },

                    new Jeu { Titre = "Sea of Thieves",             Description = "Devenez un pirate légendaire en explorant les mers, chassant des trésors et affrontant d'autres équipages",                              Editeur = "Rare",              AnneeSortie = "2018", Pegi = 12, DateSortie = new DateTime(2018, 03, 20),
                        Plateformes = new List<Plateforme> { P("Xbox One"), P("Xbox Series X/S"), P("PC (Windows)") } },

                    // PC / Multi
                    new Jeu { Titre = "Minecraft",                  Description = "Construisez, explorez et survivez dans un monde infini généré aléatoirement en blocs",                                                   Editeur = "Mojang",            AnneeSortie = "2011", Pegi = 7,  DateSortie = new DateTime(2011, 11, 18),
                        Plateformes = new List<Plateforme> { P("PC (Windows)"), P("PC (macOS)"), P("PC (Linux)"), P("Nintendo Switch"), P("Nintendo Switch 2"), P("PlayStation 4"), P("PlayStation 5"), P("Xbox One"), P("Xbox Series X/S"), P("iOS"), P("Android") } },

                    new Jeu { Titre = "Cyberpunk 2077",             Description = "Incarnez V, un mercenaire dans la mégalopole Night City, dans un RPG d'action futuriste aux choix déterminants",                         Editeur = "CD Projekt Red",    AnneeSortie = "2020", Pegi = 18, DateSortie = new DateTime(2020, 12, 10),
                        Plateformes = new List<Plateforme> { P("PC (Windows)"), P("PlayStation 4"), P("PlayStation 5"), P("Xbox One"), P("Xbox Series X/S") } },

                    new Jeu { Titre = "Elden Ring",                 Description = "Explorez les Terres Intermédiaires dans un RPG d'action en monde ouvert d'une difficulté légendaire",                                    Editeur = "FromSoftware",      AnneeSortie = "2022", Pegi = 16, DateSortie = new DateTime(2022, 02, 25),
                        Plateformes = new List<Plateforme> { P("PC (Windows)"), P("PlayStation 4"), P("PlayStation 5"), P("Xbox One"), P("Xbox Series X/S") } },

                    new Jeu { Titre = "Baldur's Gate 3",            Description = "Vivez une aventure RPG au tour par tour colossale dans l'univers de Donjons & Dragons avec une liberté de choix totale",                 Editeur = "Larian Studios",    AnneeSortie = "2023", Pegi = 18, DateSortie = new DateTime(2023, 08, 03),
                        Plateformes = new List<Plateforme> { P("PC (Windows)"), P("PC (macOS)"), P("PlayStation 5"), P("Xbox Series X/S") } },

                    new Jeu { Titre = "Stardew Valley",             Description = "Gérez votre ferme, cultivez, élevez des animaux et tissez des liens avec les habitants d'un charmant village",                           Editeur = "ConcernedApe",      AnneeSortie = "2016", Pegi = 7,  DateSortie = new DateTime(2016, 02, 26),
                        Plateformes = new List<Plateforme> { P("PC (Windows)"), P("PC (macOS)"), P("PC (Linux)"), P("Nintendo Switch"), P("Nintendo Switch 2"), P("PlayStation 4"), P("PlayStation 5"), P("Xbox One"), P("iOS"), P("Android") } },

                    new Jeu { Titre = "Among Us",                   Description = "Démasquez les imposteurs à bord d'un vaisseau spatial en accomplissant des tâches et en votant pour éliminer les suspects",               Editeur = "InnerSloth",        AnneeSortie = "2018", Pegi = 7,  DateSortie = new DateTime(2018, 06, 15),
                        Plateformes = new List<Plateforme> { P("PC (Windows)"), P("Nintendo Switch"), P("Nintendo Switch 2"), P("PlayStation 4"), P("PlayStation 5"), P("Xbox One"), P("Xbox Series X/S"), P("iOS"), P("Android") } },

                    new Jeu { Titre = "Valorant",                   Description = "Affrontez des équipes adverses dans un FPS tactique 5v5 où chaque agent possède des capacités uniques",                                   Editeur = "Riot Games",        AnneeSortie = "2020", Pegi = 16, DateSortie = new DateTime(2020, 06, 02),
                        Plateformes = new List<Plateforme> { P("PC (Windows)"), P("PlayStation 5"), P("Xbox Series X/S") } },

                    new Jeu { Titre = "League of Legends",          Description = "Défendez votre base et détruisez celle de l'ennemi dans des parties de MOBA stratégiques à 5 contre 5",                                  Editeur = "Riot Games",        AnneeSortie = "2009", Pegi = 12, DateSortie = new DateTime(2009, 10, 27),
                        Plateformes = new List<Plateforme> { P("PC (Windows)"), P("PC (macOS)"), P("iOS"), P("Android") } },

                    new Jeu { Titre = "Counter-Strike 2",           Description = "Affrontez des terroristes ou défendez les otages dans le FPS tactique compétitif de référence",                                           Editeur = "Valve",             AnneeSortie = "2023", Pegi = 18, DateSortie = new DateTime(2023, 09, 27),
                        Plateformes = new List<Plateforme> { P("PC (Windows)"), P("PC (Linux)") } },

                    // Multi-plateforme récents
                    new Jeu { Titre = "Schedule 1",                 Description = "From small-time dope pusher to kingpin - manufacture and distribute a range of drugs throughout the grungy city of Hyland Point",         Editeur = "TVGS",              AnneeSortie = "2025", Pegi = 18, DateSortie = new DateTime(2025, 04, 24),
                        Plateformes = new List<Plateforme> { P("PC (Windows)") } },

                    new Jeu { Titre = "Hogwarts Legacy",            Description = "Vivez votre propre aventure de sorcier au XIXe siècle dans un Poudlard en monde ouvert regorgeant de secrets",                           Editeur = "Avalanche Software", AnneeSortie = "2023", Pegi = 12, DateSortie = new DateTime(2023, 02, 10),
                        Plateformes = new List<Plateforme> { P("PC (Windows)"), P("PlayStation 4"), P("PlayStation 5"), P("Xbox One"), P("Xbox Series X/S"), P("Nintendo Switch") } },

                    new Jeu { Titre = "EA Sports FC 25",            Description = "Vivez l'expérience football ultime avec des licences officielles, des modes carrière enrichis et l'Ultimate Team",                        Editeur = "EA Sports",         AnneeSortie = "2024", Pegi = 3,  DateSortie = new DateTime(2024, 09, 27),
                        Plateformes = new List<Plateforme> { P("PC (Windows)"), P("PlayStation 4"), P("PlayStation 5"), P("Xbox One"), P("Xbox Series X/S"), P("Nintendo Switch"), P("Nintendo Switch 2") } },

                    new Jeu { Titre = "Call of Duty: Black Ops 6",  Description = "Plongez dans une campagne solo haletante et des modes multijoueurs intenses dans le dernier opus de la franchise emblématique",           Editeur = "Treyarch",          AnneeSortie = "2024", Pegi = 18, DateSortie = new DateTime(2024, 10, 25),
                        Plateformes = new List<Plateforme> { P("PC (Windows)"), P("PlayStation 4"), P("PlayStation 5"), P("Xbox One"), P("Xbox Series X/S") } },

                    new Jeu { Titre = "Fortnite",                   Description = "Survivez et soyez le dernier joueur debout dans un Battle Royale en constante évolution avec des collaborations pop culture",              Editeur = "Epic Games",        AnneeSortie = "2017", Pegi = 12, DateSortie = new DateTime(2017, 07, 25),
                        Plateformes = new List<Plateforme> { P("PC (Windows)"), P("PlayStation 4"), P("PlayStation 5"), P("Xbox One"), P("Xbox Series X/S"), P("Nintendo Switch"), P("Nintendo Switch 2"), P("iOS"), P("Android") } },
                };

                context.Jeux.AddRange(jeux);
                context.SaveChanges();

            }

            if (!context.Tournois.Any())
            {
                // Récupération des IDs espaces et jeux créés
                var espaceNintendo = context.Espaces.First(e => e.Nom == "Nintendo");
                var espaceXbox = context.Espaces.First(e => e.Nom == "X Box");
                var espacePS = context.Espaces.First(e => e.Nom == "PlayStation");
                var espaceFPS = context.Espaces.First(e => e.Nom == "FPS Arena");
                var espaceMOBA = context.Espaces.First(e => e.Nom == "MOBA Zone");
                var espaceFighting = context.Espaces.First(e => e.Nom == "Fighting Games");
                var espaceSports = context.Espaces.First(e => e.Nom == "Sports Games");
                var espaceEsport = context.Espaces.First(e => e.Nom == "Esport Arena");

                var jeuMK = context.Jeux.First(j => j.Titre == "Mario Kart 8 Deluxe");
                var jeuFortnite = context.Jeux.First(j => j.Titre == "Fortnite");
                var jeuHalo = context.Jeux.First(j => j.Titre == "Halo Infinite");
                var jeuValorant = context.Jeux.First(j => j.Titre == "Valorant");
                var jeuLoL = context.Jeux.First(j => j.Titre == "League of Legends");
                var jeuCS2 = context.Jeux.First(j => j.Titre == "Counter-Strike 2");
                var jeuFC25 = context.Jeux.First(j => j.Titre == "EA Sports FC 25");
                var jeuElden = context.Jeux.First(j => j.Titre == "Elden Ring");
                var jeuSmash = context.Jeux.First(j => j.Titre == "Super Smash Bros. Ultimate");
                var jeuMinecraft = context.Jeux.First(j => j.Titre == "Minecraft");

                context.Tournois.AddRange(new List<Tournoi>
                {
                    // Samedi 10h-20h — espaces différents, pas de chevauchement
                    new Tournoi { Nom = "Tournoi Mario Kart",         DateHeure = new DateTime(2026,05,24,11,0,0), NbParticipants = 16, DureePrevue = 20, Statut = "Terminé",  IdEspace = espaceNintendo.IdEspace, IdJeu = jeuMK.IdJeu },
                    new Tournoi { Nom = "Tournoi Fortnite Saison 1", DateHeure = new DateTime(2026,05,24,12,0,0),NbParticipants = 16, DureePrevue = 50, Statut = "Terminé",  IdEspace = espaceXbox.IdEspace,    IdJeu = jeuFortnite.IdJeu },
                    new Tournoi { Nom = "Tournoi Halo Open",          DateHeure = new DateTime(2026,05,24,13,0,0),NbParticipants = 16,DureePrevue = 60,  Statut = "Terminé",  IdEspace = espaceFPS.IdEspace,     IdJeu = jeuHalo.IdJeu },
                    new Tournoi { Nom = "Tournoi FC 25 Ligue 1",      DateHeure = new DateTime(2026,05,24,14,0,0),NbParticipants = 8,  DureePrevue = 20, Statut = "Terminé",  IdEspace = espaceSports.IdEspace,  IdJeu = jeuFC25.IdJeu },
                    new Tournoi { Nom = "Tournoi Smash Bros Elite",  DateHeure = new DateTime(2026,05,24,15,0,0), NbParticipants = 16, DureePrevue = 30,  Statut = "Terminé",  IdEspace = espaceFighting.IdEspace,IdJeu = jeuSmash.IdJeu },

                    // Dimanche 10h-18h
                    new Tournoi { Nom = "Tournoi LoL Printemps",     DateHeure = new DateTime(2026,05,24,11,0,0), NbParticipants = 10, DureePrevue = 20, Statut = "Terminé",  IdEspace = espaceMOBA.IdEspace,    IdJeu = jeuLoL.IdJeu },
                    new Tournoi { Nom = "Tournoi CS2 Qualif",         DateHeure = new DateTime(2026,05,24,11,0,0),NbParticipants = 10, DureePrevue = 15, Statut = "Terminé",  IdEspace = espaceFPS.IdEspace,     IdJeu = jeuCS2.IdJeu },
                    new Tournoi { Nom = "Tournoi Valorant Invitatio", DateHeure = new DateTime(2026,05,24,11,0,0), NbParticipants = 10, DureePrevue = 25, Statut = "En cours", IdEspace = espaceEsport.IdEspace,  IdJeu = jeuValorant.IdJeu },
                    new Tournoi { Nom = "Tournoi Elden Ring No Hit", DateHeure = new DateTime(2026,05,24,11,0,0), NbParticipants = 8,  DureePrevue = 30,  Statut = "En cours", IdEspace = espacePS.IdEspace,      IdJeu = jeuElden.IdJeu },
                    new Tournoi { Nom = "Tournoi Minecraft Build",   DateHeure = new DateTime(2026,05,24,11,0,0), NbParticipants = 12, DureePrevue = 50,  Statut = "Planifié", IdEspace = espaceXbox.IdEspace,    IdJeu = jeuMinecraft.IdJeu },
                });

                context.SaveChanges();
            }

            // lancement du formulaire principal
            ApplicationConfiguration.Initialize();
            Application.Run(new FormAuthentification());
        }
    }
}