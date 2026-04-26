using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            try
            {
                using var context = new ApplicationDbContext();

                // Applique toutes les migrations en attente
                context.Database.Migrate();

                // Création des services
                var tournoisService = new TournoiService(context);
                var espaceService = new EspaceService(context);
                var organisateurService = new OrganisateurService(context);
                var roleService = new RoleService(context);
                var lotComposantService = new LotComposantService(context);
                var lotService = new LotService(context);
                var jeuService = new JeuService(context);
                var participerService = new ParticiperService(context);
                var plateformeService = new PlateformeService(context);
                var posteJeuService = new PosteJeuService(context);
                var soumisVoteService = new SoumisVoteService(context);
                var voterService = new VoterService(context);

                // -------------------------------------------------------
                // 1. JOUEURS  (pas de FK sortante)
                // -------------------------------------------------------
                if (!context.Joueurs.Any())
                {
                    context.Joueurs.AddRange(new List<Joueur>
                    {
                        // utilisés dans Participer
                        new Joueur { IdUser = 845 },
                        new Joueur { IdUser = 453 },
                        new Joueur { IdUser = 120 },
                        new Joueur { IdUser = 457 },
                        new Joueur { IdUser = 812 },
                        new Joueur { IdUser = 920 },
                        new Joueur { IdUser = 150 },
                        new Joueur { IdUser = 760 },
                        new Joueur { IdUser = 125 },
                        new Joueur { IdUser = 858 },
                        new Joueur { IdUser = 495 },
                        new Joueur { IdUser = 921 },
                        new Joueur { IdUser = 152 },
                        new Joueur { IdUser = 857 },
                        new Joueur { IdUser = 470 },
                        new Joueur { IdUser = 910 },
                        new Joueur { IdUser = 149 },
                        // utilisés dans Voter uniquement
                        new Joueur { IdUser = 946 },
                        new Joueur { IdUser = 785 },
                        new Joueur { IdUser = 864 },
                        new Joueur { IdUser = 666 },
                        new Joueur { IdUser = 163 },
                        new Joueur { IdUser = 942 },
                        new Joueur { IdUser = 841 },
                        new Joueur { IdUser = 180 },
                        new Joueur { IdUser = 917 },
                        new Joueur { IdUser = 74  },
                        new Joueur { IdUser = 510 },
                    });
                    context.SaveChanges();
                }

                // -------------------------------------------------------
                // 2. LOTS  (pas de FK sortante)
                // -------------------------------------------------------
                if (!context.Lots.Any())
                {
                    context.Lots.AddRange(new List<Lot>
                    {
                        new Lot { Libelle = "Lot de jeux vidéo",    RangAttribution = 1 },
                        new Lot { Libelle = "Lot de casque",        RangAttribution = 2 },
                        new Lot { Libelle = "Lot de tapis de souris", RangAttribution = 3 },
                        new Lot { Libelle = "Lot de cartes cadeaux", RangAttribution = 1 },
                        new Lot { Libelle = "Lot de clavier",       RangAttribution = 2 },
                        new Lot { Libelle = "Lot de manettes",      RangAttribution = 3 },
                    });
                    context.SaveChanges();
                }

                // -------------------------------------------------------
                // 3. LOT COMPOSANTS  (pas de FK sortante)
                // -------------------------------------------------------
                if (!context.LotComposants.Any())
                {
                    context.LotComposants.AddRange(new List<LotComposant>
                    {
                        new LotComposant { Libelle = "PS4",                      Description = "Console de jeu de type Playstation",   Valeur = 250 },
                        new LotComposant { Libelle = "PS5",                      Description = "Console de jeu de type Playstation",   Valeur = 350 },
                        new LotComposant { Libelle = "Xbox One",                 Description = "Console de jeu de type Xbox",          Valeur = 325 },
                        new LotComposant { Libelle = "Clavier Razer Ornata V2",  Description = "Clavier gamer de marque Razer",        Valeur = 80  },
                        new LotComposant { Libelle = "Clavier Klim",             Description = "Clavier gamer de marque Klim",         Valeur = 30  },
                        new LotComposant { Libelle = "Souris Razer Naga Trinity",Description = "Souris gamer de marque Razer",         Valeur = 70  },
                        new LotComposant { Libelle = "Souris Logitech G Pro X",  Description = "Souris gamer de marque Logitech",      Valeur = 75  },
                        new LotComposant { Libelle = "Manette PS4",              Description = "Manette de marque Playstation",        Valeur = 40  },
                        new LotComposant { Libelle = "Manette Xbox",             Description = "Manette de marque Xbox",               Valeur = 50  },
                        new LotComposant { Libelle = "Casque Razer Kraken",      Description = "Casque gamer de marque Razer",         Valeur = 60  },
                        new LotComposant { Libelle = "Casque HyperX Cloud 2",    Description = "Casque gamer de marque HyperX",        Valeur = 54  },
                    });
                    context.SaveChanges();
                }

                // -------------------------------------------------------
                // 4. ESPACES  (pas de FK sortante)
                // -------------------------------------------------------
                if (!context.Espaces.Any())
                {
                    context.Espaces.AddRange(new List<Espace>
                    {
                        new Espace { Nom = "Nintendo",       Description = "Espace dédié aux jeux de switch",                          Superficie = 30, CapaciteMaxi = 30 },
                        new Espace { Nom = "X Box",          Description = "Espace dédié aux jeux sur support Xbox One et Xbox",       Superficie = 50, CapaciteMaxi = 40 },
                        new Espace { Nom = "PlayStation",    Description = "Espace dédié aux jeux PS4 et PS5",                         Superficie = 45, CapaciteMaxi = 35 },
                        new Espace { Nom = "PC Gaming",      Description = "Zone gaming sur ordinateurs performants",                  Superficie = 16, CapaciteMaxi = 25 },
                        new Espace { Nom = "Rétrogaming",    Description = "Espace consoles anciennes et classiques",                  Superficie = 25, CapaciteMaxi = 20 },
                        new Espace { Nom = "VR Zone",        Description = "Expériences en réalité virtuelle",                         Superficie = 40, CapaciteMaxi = 15 },
                        new Espace { Nom = "Arcade",         Description = "Bornes d'arcade classiques",                               Superficie = 35, CapaciteMaxi = 20 },
                        new Espace { Nom = "Mobile Gaming",  Description = "Jeux sur tablettes et smartphones",                        Superficie = 20, CapaciteMaxi = 15 },
                        new Espace { Nom = "Indie Games",    Description = "Découverte de jeux indépendants",                          Superficie = 25, CapaciteMaxi = 20 },
                        new Espace { Nom = "Simulation",     Description = "Simulateurs (course, vol, etc.)",                          Superficie = 50, CapaciteMaxi = 20 },
                        new Espace { Nom = "FPS Arena",      Description = "Jeux de tir compétitifs",                                  Superficie = 45, CapaciteMaxi = 30 },
                        new Espace { Nom = "MOBA Zone",      Description = "Jeux de stratégie en équipe",                             Superficie = 40, CapaciteMaxi = 25 },
                        new Espace { Nom = "Fighting Games", Description = "Jeux de combat",                                          Superficie = 30, CapaciteMaxi = 20 },
                        new Espace { Nom = "Sports Games",   Description = "Jeux de sport (FIFA, NBA...)",                            Superficie = 35, CapaciteMaxi = 25 },
                        new Espace { Nom = "Party Games",    Description = "Jeux fun en groupe",                                      Superficie = 30, CapaciteMaxi = 30 },
                        new Espace { Nom = "Streaming Zone", Description = "Diffusion et création de contenu",                        Superficie = 25, CapaciteMaxi = 10 },
                        new Espace { Nom = "Esport Arena",   Description = "Compétitions et tournois",                                Superficie = 25, CapaciteMaxi = 25 },
                        new Espace { Nom = "Coaching",       Description = "Zone d'entraînement et coaching",                         Superficie = 20, CapaciteMaxi = 10 },
                        new Espace { Nom = "Casual Gaming",  Description = "Jeux détente et accessibles",                             Superficie = 30, CapaciteMaxi = 20 },
                        new Espace { Nom = "LAN Party",      Description = "Espace réseau local multijoueur",                         Superficie = 32, CapaciteMaxi = 50 },
                        new Espace { Nom = "Board Games",    Description = "Jeux de société modernes",                                Superficie = 40, CapaciteMaxi = 30 },
                        new Espace { Nom = "Kids Zone",      Description = "Espace enfants avec jeux adaptés",                        Superficie = 35, CapaciteMaxi = 20 },
                    });
                    context.SaveChanges();
                }

                // -------------------------------------------------------
                // 5. PLATEFORMES  (pas de FK sortante)
                // -------------------------------------------------------
                if (!context.Plateformes.Any())
                {
                    context.Plateformes.AddRange(new List<Plateforme>
                    {
                        new Plateforme { Libelle = "Nintendo 3DS"           },
                        new Plateforme { Libelle = "Nintendo Switch"        },
                        new Plateforme { Libelle = "Nintendo Switch 2"      },
                        new Plateforme { Libelle = "Nintendo Wii U"         },
                        new Plateforme { Libelle = "PlayStation 3"          },
                        new Plateforme { Libelle = "PlayStation 4"          },
                        new Plateforme { Libelle = "PlayStation 5"          },
                        new Plateforme { Libelle = "PlayStation Portable (PSP)" },
                        new Plateforme { Libelle = "PlayStation Vita"       },
                        new Plateforme { Libelle = "Xbox 360"               },
                        new Plateforme { Libelle = "Xbox One"               },
                        new Plateforme { Libelle = "Xbox Series X/S"        },
                        new Plateforme { Libelle = "PC (Windows)"           },
                        new Plateforme { Libelle = "PC (macOS)"             },
                        new Plateforme { Libelle = "PC (Linux)"             },
                        new Plateforme { Libelle = "iOS"                    },
                        new Plateforme { Libelle = "Android"                },
                        new Plateforme { Libelle = "Stadia"                 },
                        new Plateforme { Libelle = "Steam Deck"             },
                    });
                    context.SaveChanges();
                }

                // -------------------------------------------------------
                // 6. POSTES JEU  (FK → Espace, FK → Plateforme)
                // -------------------------------------------------------
                if (!context.PostesJeu.Any())
                {
                    var espaces = context.Espaces.ToList();
                    var plateformes = context.Plateformes.ToList();

                    Espace E(string nom) => espaces.First(e => e.Nom == nom);
                    Plateforme P(string lib) => plateformes.First(p => p.Libelle == lib);

                    context.PostesJeu.AddRange(new List<PosteJeu>
                    {
                        // Nintendo
                        new PosteJeu { Reference = "PJ-NIN-001", Fonctionnel = true,  IdEspace = E("Nintendo").IdEspace,    IdPlateforme = P("Nintendo Switch").IdPlateforme   },
                        new PosteJeu { Reference = "PJ-NIN-002", Fonctionnel = true,  IdEspace = E("Nintendo").IdEspace,    IdPlateforme = P("Nintendo Switch").IdPlateforme   },
                        new PosteJeu { Reference = "PJ-NIN-003", Fonctionnel = true,  IdEspace = E("Nintendo").IdEspace,    IdPlateforme = P("Nintendo Switch 2").IdPlateforme },
                        new PosteJeu { Reference = "PJ-NIN-004", Fonctionnel = false, IdEspace = E("Nintendo").IdEspace,    IdPlateforme = P("Nintendo 3DS").IdPlateforme      },
                        new PosteJeu { Reference = "PJ-NIN-005", Fonctionnel = true,  IdEspace = E("Nintendo").IdEspace,    IdPlateforme = P("Nintendo Wii U").IdPlateforme    },
                        // Xbox
                        new PosteJeu { Reference = "PJ-XBX-001", Fonctionnel = true,  IdEspace = E("X Box").IdEspace,       IdPlateforme = P("Xbox Series X/S").IdPlateforme   },
                        new PosteJeu { Reference = "PJ-XBX-002", Fonctionnel = true,  IdEspace = E("X Box").IdEspace,       IdPlateforme = P("Xbox Series X/S").IdPlateforme   },
                        new PosteJeu { Reference = "PJ-XBX-003", Fonctionnel = true,  IdEspace = E("X Box").IdEspace,       IdPlateforme = P("Xbox One").IdPlateforme          },
                        new PosteJeu { Reference = "PJ-XBX-004", Fonctionnel = false, IdEspace = E("X Box").IdEspace,       IdPlateforme = P("Xbox One").IdPlateforme          },
                        new PosteJeu { Reference = "PJ-XBX-005", Fonctionnel = true,  IdEspace = E("X Box").IdEspace,       IdPlateforme = P("Xbox 360").IdPlateforme          },
                        // PlayStation
                        new PosteJeu { Reference = "PJ-PSN-001", Fonctionnel = true,  IdEspace = E("PlayStation").IdEspace, IdPlateforme = P("PlayStation 5").IdPlateforme     },
                        new PosteJeu { Reference = "PJ-PSN-002", Fonctionnel = true,  IdEspace = E("PlayStation").IdEspace, IdPlateforme = P("PlayStation 5").IdPlateforme     },
                        new PosteJeu { Reference = "PJ-PSN-003", Fonctionnel = true,  IdEspace = E("PlayStation").IdEspace, IdPlateforme = P("PlayStation 4").IdPlateforme     },
                        new PosteJeu { Reference = "PJ-PSN-004", Fonctionnel = false, IdEspace = E("PlayStation").IdEspace, IdPlateforme = P("PlayStation 4").IdPlateforme     },
                        new PosteJeu { Reference = "PJ-PSN-005", Fonctionnel = true,  IdEspace = E("PlayStation").IdEspace, IdPlateforme = P("PlayStation 3").IdPlateforme     },
                        // PC Gaming
                        new PosteJeu { Reference = "PJ-PCG-001", Fonctionnel = true,  IdEspace = E("PC Gaming").IdEspace,   IdPlateforme = P("PC (Windows)").IdPlateforme      },
                        new PosteJeu { Reference = "PJ-PCG-002", Fonctionnel = true,  IdEspace = E("PC Gaming").IdEspace,   IdPlateforme = P("PC (Windows)").IdPlateforme      },
                        new PosteJeu { Reference = "PJ-PCG-003", Fonctionnel = true,  IdEspace = E("PC Gaming").IdEspace,   IdPlateforme = P("PC (Windows)").IdPlateforme      },
                        new PosteJeu { Reference = "PJ-PCG-004", Fonctionnel = false, IdEspace = E("PC Gaming").IdEspace,   IdPlateforme = P("PC (Linux)").IdPlateforme        },
                        new PosteJeu { Reference = "PJ-PCG-005", Fonctionnel = true,  IdEspace = E("PC Gaming").IdEspace,   IdPlateforme = P("Steam Deck").IdPlateforme        },
                        // Rétrogaming
                        new PosteJeu { Reference = "PJ-RTR-001", Fonctionnel = true,  IdEspace = E("Rétrogaming").IdEspace, IdPlateforme = P("PlayStation 3").IdPlateforme     },
                        new PosteJeu { Reference = "PJ-RTR-002", Fonctionnel = true,  IdEspace = E("Rétrogaming").IdEspace, IdPlateforme = P("Xbox 360").IdPlateforme          },
                        new PosteJeu { Reference = "PJ-RTR-003", Fonctionnel = false, IdEspace = E("Rétrogaming").IdEspace, IdPlateforme = P("Nintendo 3DS").IdPlateforme      },
                        new PosteJeu { Reference = "PJ-RTR-004", Fonctionnel = true,  IdEspace = E("Rétrogaming").IdEspace, IdPlateforme = P("PlayStation Portable (PSP)").IdPlateforme },
                        new PosteJeu { Reference = "PJ-RTR-005", Fonctionnel = true,  IdEspace = E("Rétrogaming").IdEspace, IdPlateforme = P("PlayStation Vita").IdPlateforme  },
                        // VR Zone
                        new PosteJeu { Reference = "PJ-VRZ-001", Fonctionnel = true,  IdEspace = E("VR Zone").IdEspace,     IdPlateforme = P("PC (Windows)").IdPlateforme      },
                        new PosteJeu { Reference = "PJ-VRZ-002", Fonctionnel = true,  IdEspace = E("VR Zone").IdEspace,     IdPlateforme = P("PlayStation 5").IdPlateforme     },
                        new PosteJeu { Reference = "PJ-VRZ-003", Fonctionnel = false, IdEspace = E("VR Zone").IdEspace,     IdPlateforme = P("PC (Windows)").IdPlateforme      },
                        // Esport Arena
                        new PosteJeu { Reference = "PJ-ESA-001", Fonctionnel = true,  IdEspace = E("Esport Arena").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme     },
                        new PosteJeu { Reference = "PJ-ESA-002", Fonctionnel = true,  IdEspace = E("Esport Arena").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme     },
                        new PosteJeu { Reference = "PJ-ESA-003", Fonctionnel = true,  IdEspace = E("Esport Arena").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme     },
                        new PosteJeu { Reference = "PJ-ESA-004", Fonctionnel = true,  IdEspace = E("Esport Arena").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme     },
                        new PosteJeu { Reference = "PJ-ESA-005", Fonctionnel = false, IdEspace = E("Esport Arena").IdEspace, IdPlateforme = P("PC (Windows)").IdPlateforme     },
                        // LAN Party
                        new PosteJeu { Reference = "PJ-LAN-001", Fonctionnel = true,  IdEspace = E("LAN Party").IdEspace,   IdPlateforme = P("PC (Windows)").IdPlateforme      },
                        new PosteJeu { Reference = "PJ-LAN-002", Fonctionnel = true,  IdEspace = E("LAN Party").IdEspace,   IdPlateforme = P("PC (Windows)").IdPlateforme      },
                        new PosteJeu { Reference = "PJ-LAN-003", Fonctionnel = true,  IdEspace = E("LAN Party").IdEspace,   IdPlateforme = P("PC (Linux)").IdPlateforme        },
                        new PosteJeu { Reference = "PJ-LAN-004", Fonctionnel = false, IdEspace = E("LAN Party").IdEspace,   IdPlateforme = P("PC (Windows)").IdPlateforme      },
                        // Mobile Gaming
                        new PosteJeu { Reference = "PJ-MOB-001", Fonctionnel = true,  IdEspace = E("Mobile Gaming").IdEspace, IdPlateforme = P("iOS").IdPlateforme             },
                        new PosteJeu { Reference = "PJ-MOB-002", Fonctionnel = true,  IdEspace = E("Mobile Gaming").IdEspace, IdPlateforme = P("Android").IdPlateforme         },
                        new PosteJeu { Reference = "PJ-MOB-003", Fonctionnel = false, IdEspace = E("Mobile Gaming").IdEspace, IdPlateforme = P("Android").IdPlateforme         },
                        // Simulation
                        new PosteJeu { Reference = "PJ-SIM-001", Fonctionnel = true,  IdEspace = E("Simulation").IdEspace,  IdPlateforme = P("PC (Windows)").IdPlateforme      },
                        new PosteJeu { Reference = "PJ-SIM-002", Fonctionnel = true,  IdEspace = E("Simulation").IdEspace,  IdPlateforme = P("PC (Windows)").IdPlateforme      },
                        new PosteJeu { Reference = "PJ-SIM-003", Fonctionnel = false, IdEspace = E("Simulation").IdEspace,  IdPlateforme = P("Xbox Series X/S").IdPlateforme   },
                        // Fighting Games
                        new PosteJeu { Reference = "PJ-FGT-001", Fonctionnel = true,  IdEspace = E("Fighting Games").IdEspace, IdPlateforme = P("PlayStation 5").IdPlateforme  },
                        new PosteJeu { Reference = "PJ-FGT-002", Fonctionnel = true,  IdEspace = E("Fighting Games").IdEspace, IdPlateforme = P("Xbox Series X/S").IdPlateforme},
                        new PosteJeu { Reference = "PJ-FGT-003", Fonctionnel = true,  IdEspace = E("Fighting Games").IdEspace, IdPlateforme = P("Nintendo Switch").IdPlateforme},
                        // Sports Games
                        new PosteJeu { Reference = "PJ-SPT-001", Fonctionnel = true,  IdEspace = E("Sports Games").IdEspace, IdPlateforme = P("PlayStation 5").IdPlateforme    },
                        new PosteJeu { Reference = "PJ-SPT-002", Fonctionnel = true,  IdEspace = E("Sports Games").IdEspace, IdPlateforme = P("Xbox Series X/S").IdPlateforme  },
                        new PosteJeu { Reference = "PJ-SPT-003", Fonctionnel = false, IdEspace = E("Sports Games").IdEspace, IdPlateforme = P("PlayStation 4").IdPlateforme    },
                        // Party Games
                        new PosteJeu { Reference = "PJ-PTY-001", Fonctionnel = true,  IdEspace = E("Party Games").IdEspace, IdPlateforme = P("Nintendo Switch").IdPlateforme   },
                        new PosteJeu { Reference = "PJ-PTY-002", Fonctionnel = true,  IdEspace = E("Party Games").IdEspace, IdPlateforme = P("Nintendo Switch 2").IdPlateforme },
                        new PosteJeu { Reference = "PJ-PTY-003", Fonctionnel = true,  IdEspace = E("Party Games").IdEspace, IdPlateforme = P("PlayStation 5").IdPlateforme     },
                    });
                    context.SaveChanges();
                }

                // -------------------------------------------------------
                // 7. ROLES  (pas de FK sortante)
                // -------------------------------------------------------
                if (!context.Roles.Any())
                {
                    roleService.Creer(new Role { Libelle = "Administrateur" });
                    roleService.Creer(new Role { Libelle = "Gestionnaire du stock" });
                    roleService.Creer(new Role { Libelle = "Gestionnaire de l'espace" });
                    roleService.Creer(new Role { Libelle = "Gestionnaire des tournois" });
                }

                // -------------------------------------------------------
                // 8. ORGANISATEURS  (FK → Role)
                // -------------------------------------------------------
                if (!context.Organisateurs.Any())
                {
                    organisateurService.Creer(new Organisateur
                    {
                        Login = "admin",
                        motPasse = "ADMINSIO2026+",
                        Mail = "mailSio2026@gmail.com",
                        IdRole = context.Roles.First(r => r.Libelle == "Administrateur").IdRole
                    });
                    organisateurService.Creer(new Organisateur
                    {
                        Login = "adminStock",
                        motPasse = "ADMINSIO2026+",
                        Mail = "mailSio2026@gmail.com",
                        IdRole = context.Roles.First(r => r.Libelle == "Gestionnaire du stock").IdRole
                    });
                    organisateurService.Creer(new Organisateur
                    {
                        Login = "adminEspace",
                        motPasse = "ADMINSIO2026+",
                        Mail = "mailSio2026@gmail.com",
                        IdRole = context.Roles.First(r => r.Libelle == "Gestionnaire de l'espace").IdRole
                    });
                    organisateurService.Creer(new Organisateur
                    {
                        Login = "adminTournoi",
                        motPasse = "ADMINSIO2026+",
                        Mail = "mailSio2026@gmail.com",
                        IdRole = context.Roles.First(r => r.Libelle == "Gestionnaire des tournois").IdRole
                    });
                }

                // -------------------------------------------------------
                // 9. JEUX  (plus de lien direct vers Plateforme)
                // -------------------------------------------------------
                if (!context.Jeux.Any())
                {
                    context.Jeux.AddRange(new List<Jeu>
                    {
                        // --- Nintendo ---
                        new Jeu { Titre = "Mario Kart 8 Deluxe",
                            Description = "Terminer les courses en première position en utilisant des objets pour ralentir les adversaires ou se protéger",
                            Editeur = "Nintendo", AnneeSortie = "2017", Pegi = 3, DateSortie = new DateTime(2017, 04, 28) },

                        new Jeu { Titre = "The Legend of Zelda: BOTW",
                            Description = "Explorez un vaste monde ouvert pour libérer le royaume d'Hyrule des griffes de Calamity Ganon",
                            Editeur = "Nintendo", AnneeSortie = "2017", Pegi = 12, DateSortie = new DateTime(2017, 03, 03) },

                        new Jeu { Titre = "The Legend of Zelda: TOTK",
                            Description = "Continuez l'aventure dans un Hyrule transformé, avec de nouvelles îles célestes et des pouvoirs inédits",
                            Editeur = "Nintendo", AnneeSortie = "2023", Pegi = 12, DateSortie = new DateTime(2023, 05, 12) },

                        new Jeu { Titre = "Super Smash Bros. Ultimate",
                            Description = "Affrontez des adversaires avec des personnages iconiques de nombreuses franchises dans des combats frénétiques",
                            Editeur = "Nintendo", AnneeSortie = "2018", Pegi = 12, DateSortie = new DateTime(2018, 12, 07) },

                        new Jeu { Titre = "Splatoon 3",
                            Description = "Participez à des batailles de peinture colorées en équipe de quatre joueurs dans des arènes variées",
                            Editeur = "Nintendo", AnneeSortie = "2022", Pegi = 7, DateSortie = new DateTime(2022, 09, 09) },

                        new Jeu { Titre = "Pokémon Écarlate",
                            Description = "Devenez le meilleur dresseur dans une région ouverte en capturant et entraînant des centaines de Pokémon",
                            Editeur = "Game Freak", AnneeSortie = "2022", Pegi = 7, DateSortie = new DateTime(2022, 11, 18) },

                        new Jeu { Titre = "Animal Crossing: NH",
                            Description = "Construisez et personnalisez votre île déserte en rencontrant des habitants animaux attachants",
                            Editeur = "Nintendo", AnneeSortie = "2020", Pegi = 3, DateSortie = new DateTime(2020, 03, 20) },

                        new Jeu { Titre = "Super Mario Odyssey",
                            Description = "Parcourez des royaumes colorés pour récupérer les Lunes de puissance et sauver la princesse Peach",
                            Editeur = "Nintendo", AnneeSortie = "2017", Pegi = 7, DateSortie = new DateTime(2017, 10, 27) },

                        // --- PlayStation ---
                        new Jeu { Titre = "God of War Ragnarök",
                            Description = "Incarnez Kratos et son fils Atreus dans une épopée nordique vers le crépuscule des dieux",
                            Editeur = "Sony Santa Monica", AnneeSortie = "2022", Pegi = 18, DateSortie = new DateTime(2022, 11, 09) },

                        new Jeu { Titre = "Spider-Man 2",
                            Description = "Incarnez Peter Parker et Miles Morales pour défendre New York contre de nouveaux ennemis redoutables",
                            Editeur = "Insomniac Games", AnneeSortie = "2023", Pegi = 16, DateSortie = new DateTime(2023, 10, 20) },

                        new Jeu { Titre = "Horizon Forbidden West",
                            Description = "Explorez des terres inconnues et affrontez des machines colossales pour percer les mystères d'une catastrophe imminente",
                            Editeur = "Guerrilla Games", AnneeSortie = "2022", Pegi = 16, DateSortie = new DateTime(2022, 02, 18) },

                        new Jeu { Titre = "The Last of Us Part I",
                            Description = "Survivez dans un monde post-apocalyptique ravagé par une infection fongique en escortant une jeune fille à travers les États-Unis",
                            Editeur = "Naughty Dog", AnneeSortie = "2022", Pegi = 18, DateSortie = new DateTime(2022, 09, 02) },

                        new Jeu { Titre = "Gran Turismo 7",
                            Description = "Vivez l'expérience de simulation automobile ultime avec des centaines de voitures et circuits authentiques",
                            Editeur = "Polyphony Digital", AnneeSortie = "2022", Pegi = 3, DateSortie = new DateTime(2022, 03, 04) },

                        // --- Xbox / Microsoft ---
                        new Jeu { Titre = "Halo Infinite",
                            Description = "Incarnez le Master Chief pour repousser une nouvelle menace alien dans un monde semi-ouvert",
                            Editeur = "343 Industries", AnneeSortie = "2021", Pegi = 16, DateSortie = new DateTime(2021, 12, 08) },

                        new Jeu { Titre = "Forza Horizon 5",
                            Description = "Explorez un immense monde ouvert mexicain au volant de centaines de voitures de rêve",
                            Editeur = "Playground Games", AnneeSortie = "2021", Pegi = 3, DateSortie = new DateTime(2021, 11, 09) },

                        new Jeu { Titre = "Sea of Thieves",
                            Description = "Devenez un pirate légendaire en explorant les mers, chassant des trésors et affrontant d'autres équipages",
                            Editeur = "Rare", AnneeSortie = "2018", Pegi = 12, DateSortie = new DateTime(2018, 03, 20) },

                        // --- PC / Multi ---
                        new Jeu { Titre = "Minecraft",
                            Description = "Construisez, explorez et survivez dans un monde infini généré aléatoirement en blocs",
                            Editeur = "Mojang", AnneeSortie = "2011", Pegi = 7, DateSortie = new DateTime(2011, 11, 18) },

                        new Jeu { Titre = "Cyberpunk 2077",
                            Description = "Incarnez V, un mercenaire dans la mégalopole Night City, dans un RPG d'action futuriste aux choix déterminants",
                            Editeur = "CD Projekt Red", AnneeSortie = "2020", Pegi = 18, DateSortie = new DateTime(2020, 12, 10) },

                        new Jeu { Titre = "Elden Ring",
                            Description = "Explorez les Terres Intermédiaires dans un RPG d'action en monde ouvert d'une difficulté légendaire",
                            Editeur = "FromSoftware", AnneeSortie = "2022", Pegi = 16, DateSortie = new DateTime(2022, 02, 25) },

                        new Jeu { Titre = "Baldur's Gate 3",
                            Description = "Vivez une aventure RPG au tour par tour colossale dans l'univers de Donjons & Dragons avec une liberté de choix totale",
                            Editeur = "Larian Studios", AnneeSortie = "2023", Pegi = 18, DateSortie = new DateTime(2023, 08, 03) },

                        new Jeu { Titre = "Stardew Valley",
                            Description = "Gérez votre ferme, cultivez, élevez des animaux et tissez des liens avec les habitants d'un charmant village",
                            Editeur = "ConcernedApe", AnneeSortie = "2016", Pegi = 7, DateSortie = new DateTime(2016, 02, 26) },

                        new Jeu { Titre = "Among Us",
                            Description = "Démasquez les imposteurs à bord d'un vaisseau spatial en accomplissant des tâches et en votant pour éliminer les suspects",
                            Editeur = "InnerSloth", AnneeSortie = "2018", Pegi = 7, DateSortie = new DateTime(2018, 06, 15) },

                        new Jeu { Titre = "Valorant",
                            Description = "Affrontez des équipes adverses dans un FPS tactique 5v5 où chaque agent possède des capacités uniques",
                            Editeur = "Riot Games", AnneeSortie = "2020", Pegi = 16, DateSortie = new DateTime(2020, 06, 02) },

                        new Jeu { Titre = "League of Legends",
                            Description = "Défendez votre base et détruisez celle de l'ennemi dans des parties de MOBA stratégiques à 5 contre 5",
                            Editeur = "Riot Games", AnneeSortie = "2009", Pegi = 12, DateSortie = new DateTime(2009, 10, 27) },

                        new Jeu { Titre = "Counter-Strike 2",
                            Description = "Affrontez des terroristes ou défendez les otages dans le FPS tactique compétitif de référence",
                            Editeur = "Valve", AnneeSortie = "2023", Pegi = 18, DateSortie = new DateTime(2023, 09, 27) },

                        new Jeu { Titre = "Schedule 1",
                            Description = "From small-time dope pusher to kingpin - manufacture and distribute a range of drugs throughout the grungy city of Hyland Point",
                            Editeur = "TVGS", AnneeSortie = "2025", Pegi = 18, DateSortie = new DateTime(2025, 04, 24) },

                        new Jeu { Titre = "Hogwarts Legacy",
                            Description = "Vivez votre propre aventure de sorcier au XIXe siècle dans un Poudlard en monde ouvert regorgeant de secrets",
                            Editeur = "Avalanche Software", AnneeSortie = "2023", Pegi = 12, DateSortie = new DateTime(2023, 02, 10) },

                        new Jeu { Titre = "EA Sports FC 25",
                            Description = "Vivez l'expérience football ultime avec des licences officielles, des modes carrière enrichis et l'Ultimate Team",
                            Editeur = "EA Sports", AnneeSortie = "2024", Pegi = 3, DateSortie = new DateTime(2024, 09, 27) },

                        new Jeu { Titre = "Call of Duty: Black Ops 6",
                            Description = "Plongez dans une campagne solo haletante et des modes multijoueurs intenses dans le dernier opus de la franchise emblématique",
                            Editeur = "Treyarch", AnneeSortie = "2024", Pegi = 18, DateSortie = new DateTime(2024, 10, 25) },

                        new Jeu { Titre = "Fortnite",
                            Description = "Survivez et soyez le dernier joueur debout dans un Battle Royale en constante évolution avec des collaborations pop culture",
                            Editeur = "Epic Games", AnneeSortie = "2017", Pegi = 12, DateSortie = new DateTime(2017, 07, 25) },
                    });
                    context.SaveChanges();
                }

                // -------------------------------------------------------
                // 10. TOURNOIS  (FK → Espace, FK → Jeu)
                // -------------------------------------------------------
                if (!context.Tournois.Any())
                {
                    Espace E(string nom) => context.Espaces.First(e => e.Nom == nom);
                    Jeu J(string titre) => context.Jeux.First(j => j.Titre == titre);

                    tournoisService.Creer(new Tournoi { Nom = "Tournoi Mario Kart", DateHeure = new DateTime(2026, 05, 24, 11, 0, 0), NbParticipants = 16, DureePrevue = 20, Statut = "Terminé", IdEspace = E("Nintendo").IdEspace, IdJeu = J("Mario Kart 8 Deluxe").IdJeu });
                    tournoisService.Creer(new Tournoi { Nom = "Tournoi Fortnite Saison 1", DateHeure = new DateTime(2026, 05, 24, 12, 0, 0), NbParticipants = 16, DureePrevue = 50, Statut = "Terminé", IdEspace = E("X Box").IdEspace, IdJeu = J("Fortnite").IdJeu });
                    tournoisService.Creer(new Tournoi { Nom = "Tournoi Halo Open", DateHeure = new DateTime(2026, 05, 24, 13, 0, 0), NbParticipants = 16, DureePrevue = 60, Statut = "Terminé", IdEspace = E("FPS Arena").IdEspace, IdJeu = J("Halo Infinite").IdJeu });
                    tournoisService.Creer(new Tournoi { Nom = "Tournoi FC 25 Ligue 1", DateHeure = new DateTime(2026, 05, 24, 14, 0, 0), NbParticipants = 8, DureePrevue = 20, Statut = "Terminé", IdEspace = E("Sports Games").IdEspace, IdJeu = J("EA Sports FC 25").IdJeu });
                    tournoisService.Creer(new Tournoi { Nom = "Tournoi Smash Bros Elite", DateHeure = new DateTime(2026, 05, 24, 15, 0, 0), NbParticipants = 16, DureePrevue = 30, Statut = "Terminé", IdEspace = E("Fighting Games").IdEspace, IdJeu = J("Super Smash Bros. Ultimate").IdJeu });
                    tournoisService.Creer(new Tournoi { Nom = "Tournoi LoL Printemps", DateHeure = new DateTime(2026, 05, 24, 11, 0, 0), NbParticipants = 10, DureePrevue = 20, Statut = "Terminé", IdEspace = E("MOBA Zone").IdEspace, IdJeu = J("League of Legends").IdJeu });
                    tournoisService.Creer(new Tournoi { Nom = "Tournoi CS2 Qualif", DateHeure = new DateTime(2026, 05, 24, 11, 0, 0), NbParticipants = 10, DureePrevue = 15, Statut = "Terminé", IdEspace = E("FPS Arena").IdEspace, IdJeu = J("Counter-Strike 2").IdJeu });
                    tournoisService.Creer(new Tournoi { Nom = "Tournoi Valorant Invitatio", DateHeure = new DateTime(2026, 05, 24, 11, 0, 0), NbParticipants = 10, DureePrevue = 25, Statut = "En cours", IdEspace = E("Esport Arena").IdEspace, IdJeu = J("Valorant").IdJeu });
                    tournoisService.Creer(new Tournoi { Nom = "Tournoi Elden Ring No Hit", DateHeure = new DateTime(2026, 05, 24, 11, 0, 0), NbParticipants = 8, DureePrevue = 30, Statut = "En cours", IdEspace = E("PlayStation").IdEspace, IdJeu = J("Elden Ring").IdJeu });
                    tournoisService.Creer(new Tournoi { Nom = "Tournoi Minecraft Build", DateHeure = new DateTime(2026, 05, 24, 11, 0, 0), NbParticipants = 12, DureePrevue = 50, Statut = "Planifié", IdEspace = E("X Box").IdEspace, IdJeu = J("Minecraft").IdJeu });
                }

                // -------------------------------------------------------
                // 11. SOUMIS VOTES  (FK → Jeu, FK → Plateforme)
                //     On passe directement par les IDs — plus de jeu.Plateformes
                // -------------------------------------------------------
                if (!context.SoumisVotes.Any())
                {
                    Jeu J(string titre) => context.Jeux.First(j => j.Titre == titre);
                    Plateforme P(string lib) => context.Plateformes.First(p => p.Libelle == lib);

                    context.SoumisVotes.AddRange(new List<SoumisVote>
                    {
                        new SoumisVote { DateDebutVote = DateTime.Now.AddDays(-5), DateFinVote = DateTime.Now.AddDays(15), IdJeu = J("Mario Kart 8 Deluxe").IdJeu,        IdPlateforme = P("Nintendo Switch").IdPlateforme   },
                        new SoumisVote { DateDebutVote = DateTime.Now.AddDays(-5), DateFinVote = DateTime.Now.AddDays(15), IdJeu = J("Fortnite").IdJeu,                   IdPlateforme = P("PC (Windows)").IdPlateforme      },
                        new SoumisVote { DateDebutVote = DateTime.Now.AddDays(-5), DateFinVote = DateTime.Now.AddDays(15), IdJeu = J("Halo Infinite").IdJeu,              IdPlateforme = P("Xbox Series X/S").IdPlateforme   },
                        new SoumisVote { DateDebutVote = DateTime.Now.AddDays(-5), DateFinVote = DateTime.Now.AddDays(15), IdJeu = J("Valorant").IdJeu,                   IdPlateforme = P("PC (Windows)").IdPlateforme      },
                        new SoumisVote { DateDebutVote = DateTime.Now.AddDays(-5), DateFinVote = DateTime.Now.AddDays(15), IdJeu = J("League of Legends").IdJeu,          IdPlateforme = P("PC (Windows)").IdPlateforme      },
                        new SoumisVote { DateDebutVote = DateTime.Now.AddDays(-5), DateFinVote = DateTime.Now.AddDays(15), IdJeu = J("Counter-Strike 2").IdJeu,           IdPlateforme = P("PC (Windows)").IdPlateforme      },
                        new SoumisVote { DateDebutVote = DateTime.Now.AddDays(-5), DateFinVote = DateTime.Now.AddDays(15), IdJeu = J("EA Sports FC 25").IdJeu,            IdPlateforme = P("PlayStation 5").IdPlateforme     },
                        new SoumisVote { DateDebutVote = DateTime.Now.AddDays(-5), DateFinVote = DateTime.Now.AddDays(15), IdJeu = J("Elden Ring").IdJeu,                 IdPlateforme = P("PlayStation 5").IdPlateforme     },
                        new SoumisVote { DateDebutVote = DateTime.Now.AddDays(-5), DateFinVote = DateTime.Now.AddDays(15), IdJeu = J("Minecraft").IdJeu,                  IdPlateforme = P("PlayStation 5").IdPlateforme     },
                        new SoumisVote { DateDebutVote = DateTime.Now.AddDays(-5), DateFinVote = DateTime.Now.AddDays(15), IdJeu = J("Super Smash Bros. Ultimate").IdJeu, IdPlateforme = P("Nintendo Switch").IdPlateforme   },
                    });
                    context.SaveChanges();
                }

                // -------------------------------------------------------
                // 12. VOTER  (FK → Joueur, FK → SoumisVote via Jeu+Plateforme)
                // -------------------------------------------------------
                if (!context.Voter.Any())
                {
                    Jeu J(string titre) => context.Jeux.First(j => j.Titre == titre);
                    Plateforme P(string lib) => context.Plateformes.First(p => p.Libelle == lib);

                    context.Voter.AddRange(new List<Voter>
                    {
                        // Mario Kart → Nintendo Switch
                        new Voter { IdJeu = J("Mario Kart 8 Deluxe").IdJeu,        IdPlateforme = P("Nintendo Switch").IdPlateforme,  IdUser = 946, DateVote = DateTime.Now.AddDays(-3) },
                        new Voter { IdJeu = J("Mario Kart 8 Deluxe").IdJeu,        IdPlateforme = P("Nintendo Switch").IdPlateforme,  IdUser = 785, DateVote = DateTime.Now.AddDays(-1) },
                        new Voter { IdJeu = J("Mario Kart 8 Deluxe").IdJeu,        IdPlateforme = P("Nintendo Switch").IdPlateforme,  IdUser = 453, DateVote = DateTime.Now             },
                        new Voter { IdJeu = J("Mario Kart 8 Deluxe").IdJeu,        IdPlateforme = P("Nintendo Switch").IdPlateforme,  IdUser = 864, DateVote = DateTime.Now.AddDays(-4) },
                        new Voter { IdJeu = J("Mario Kart 8 Deluxe").IdJeu,        IdPlateforme = P("Nintendo Switch").IdPlateforme,  IdUser = 125, DateVote = DateTime.Now.AddDays(-3) },
                        new Voter { IdJeu = J("Mario Kart 8 Deluxe").IdJeu,        IdPlateforme = P("Nintendo Switch").IdPlateforme,  IdUser = 666, DateVote = DateTime.Now.AddDays(-2) },
                        // Fortnite → PC
                        new Voter { IdJeu = J("Fortnite").IdJeu,                   IdPlateforme = P("PC (Windows)").IdPlateforme,     IdUser = 666, DateVote = DateTime.Now.AddDays(-2) },
                        new Voter { IdJeu = J("Fortnite").IdJeu,                   IdPlateforme = P("PC (Windows)").IdPlateforme,     IdUser = 453, DateVote = DateTime.Now.AddDays(-1) },
                        new Voter { IdJeu = J("Fortnite").IdJeu,                   IdPlateforme = P("PC (Windows)").IdPlateforme,     IdUser = 125, DateVote = DateTime.Now.AddDays(-1) },
                        new Voter { IdJeu = J("Fortnite").IdJeu,                   IdPlateforme = P("PC (Windows)").IdPlateforme,     IdUser = 785, DateVote = DateTime.Now.AddDays(-4) },
                        new Voter { IdJeu = J("Fortnite").IdJeu,                   IdPlateforme = P("PC (Windows)").IdPlateforme,     IdUser = 946, DateVote = DateTime.Now             },
                        // Halo → Xbox Series X/S
                        new Voter { IdJeu = J("Halo Infinite").IdJeu,              IdPlateforme = P("Xbox Series X/S").IdPlateforme,  IdUser = 163, DateVote = DateTime.Now.AddDays(-3) },
                        new Voter { IdJeu = J("Halo Infinite").IdJeu,              IdPlateforme = P("Xbox Series X/S").IdPlateforme,  IdUser = 453, DateVote = DateTime.Now.AddDays(-3) },
                        new Voter { IdJeu = J("Halo Infinite").IdJeu,              IdPlateforme = P("Xbox Series X/S").IdPlateforme,  IdUser = 785, DateVote = DateTime.Now.AddDays(-3) },
                        // Valorant → PC
                        new Voter { IdJeu = J("Valorant").IdJeu,                   IdPlateforme = P("PC (Windows)").IdPlateforme,     IdUser = 125, DateVote = DateTime.Now.AddDays(-5) },
                        // League of Legends → PC
                        new Voter { IdJeu = J("League of Legends").IdJeu,          IdPlateforme = P("PC (Windows)").IdPlateforme,     IdUser = 942, DateVote = DateTime.Now.AddDays(-5) },
                        new Voter { IdJeu = J("League of Legends").IdJeu,          IdPlateforme = P("PC (Windows)").IdPlateforme,     IdUser = 457, DateVote = DateTime.Now.AddDays(-3) },
                        new Voter { IdJeu = J("League of Legends").IdJeu,          IdPlateforme = P("PC (Windows)").IdPlateforme,     IdUser = 453, DateVote = DateTime.Now.AddDays(-4) },
                        new Voter { IdJeu = J("League of Legends").IdJeu,          IdPlateforme = P("PC (Windows)").IdPlateforme,     IdUser = 125, DateVote = DateTime.Now.AddDays(-5) },
                        // Counter-Strike 2 → PC
                        new Voter { IdJeu = J("Counter-Strike 2").IdJeu,           IdPlateforme = P("PC (Windows)").IdPlateforme,     IdUser = 163, DateVote = DateTime.Now             },
                        // EA Sports FC 25 → PS5
                        new Voter { IdJeu = J("EA Sports FC 25").IdJeu,            IdPlateforme = P("PlayStation 5").IdPlateforme,    IdUser = 180, DateVote = DateTime.Now             },
                        new Voter { IdJeu = J("EA Sports FC 25").IdJeu,            IdPlateforme = P("PlayStation 5").IdPlateforme,    IdUser = 457, DateVote = DateTime.Now             },
                        new Voter { IdJeu = J("EA Sports FC 25").IdJeu,            IdPlateforme = P("PlayStation 5").IdPlateforme,    IdUser = 917, DateVote = DateTime.Now.AddDays(-1) },
                        new Voter { IdJeu = J("EA Sports FC 25").IdJeu,            IdPlateforme = P("PlayStation 5").IdPlateforme,    IdUser = 125, DateVote = DateTime.Now             },
                        new Voter { IdJeu = J("EA Sports FC 25").IdJeu,            IdPlateforme = P("PlayStation 5").IdPlateforme,    IdUser = 74,  DateVote = DateTime.Now             },
                        new Voter { IdJeu = J("EA Sports FC 25").IdJeu,            IdPlateforme = P("PlayStation 5").IdPlateforme,    IdUser = 163, DateVote = DateTime.Now.AddDays(-2) },
                        new Voter { IdJeu = J("EA Sports FC 25").IdJeu,            IdPlateforme = P("PlayStation 5").IdPlateforme,    IdUser = 453, DateVote = DateTime.Now             },
                        // Minecraft → PS5
                        new Voter { IdJeu = J("Minecraft").IdJeu,                  IdPlateforme = P("PlayStation 5").IdPlateforme,    IdUser = 453, DateVote = DateTime.Now             },
                        // Elden Ring → PS5
                        new Voter { IdJeu = J("Elden Ring").IdJeu,                 IdPlateforme = P("PlayStation 5").IdPlateforme,    IdUser = 453, DateVote = DateTime.Now.AddDays(-1) },
                        new Voter { IdJeu = J("Elden Ring").IdJeu,                 IdPlateforme = P("PlayStation 5").IdPlateforme,    IdUser = 845, DateVote = DateTime.Now.AddDays(-3) },
                        new Voter { IdJeu = J("Elden Ring").IdJeu,                 IdPlateforme = P("PlayStation 5").IdPlateforme,    IdUser = 920, DateVote = DateTime.Now             },
                        new Voter { IdJeu = J("Elden Ring").IdJeu,                 IdPlateforme = P("PlayStation 5").IdPlateforme,    IdUser = 841, DateVote = DateTime.Now.AddDays(-2) },
                        new Voter { IdJeu = J("Elden Ring").IdJeu,                 IdPlateforme = P("PlayStation 5").IdPlateforme,    IdUser = 120, DateVote = DateTime.Now             },
                        // Super Smash Bros. → Nintendo Switch
                        new Voter { IdJeu = J("Super Smash Bros. Ultimate").IdJeu, IdPlateforme = P("Nintendo Switch").IdPlateforme,  IdUser = 510, DateVote = DateTime.Now             },
                    });
                    context.SaveChanges();
                }

                // -------------------------------------------------------
                // 13. PARTICIPER  (FK → Joueur, FK → Tournoi)
                // -------------------------------------------------------
                if (!context.Participer.Any())
                {
                    Tournoi T(string nom) => context.Tournois.First(t => t.Nom == nom);

                    context.Participer.AddRange(new List<Participer>
                    {
                        // Tournoi Mario Kart
                        new Participer { IdUser = 845, NumeroTournoi = T("Tournoi Mario Kart").NumeroTournoi,        DateHeureInscription = DateTime.Now.AddDays(-10), Rang = 0 },
                        new Participer { IdUser = 453, NumeroTournoi = T("Tournoi Mario Kart").NumeroTournoi,        DateHeureInscription = DateTime.Now.AddDays(-7),  Rang = 0 },
                        new Participer { IdUser = 120, NumeroTournoi = T("Tournoi Mario Kart").NumeroTournoi,        DateHeureInscription = DateTime.Now.AddDays(-7),  Rang = 0 },
                        new Participer { IdUser = 457, NumeroTournoi = T("Tournoi Mario Kart").NumeroTournoi,        DateHeureInscription = DateTime.Now.AddDays(-5),  Rang = 0 },
                        new Participer { IdUser = 812, NumeroTournoi = T("Tournoi Mario Kart").NumeroTournoi,        DateHeureInscription = DateTime.Now.AddDays(-4),  Rang = 0 },
                        new Participer { IdUser = 920, NumeroTournoi = T("Tournoi Mario Kart").NumeroTournoi,        DateHeureInscription = DateTime.Now.AddDays(-3),  Rang = 0 },
                        new Participer { IdUser = 150, NumeroTournoi = T("Tournoi Mario Kart").NumeroTournoi,        DateHeureInscription = DateTime.Now.AddDays(-3),  Rang = 0 },
                        new Participer { IdUser = 760, NumeroTournoi = T("Tournoi Mario Kart").NumeroTournoi,        DateHeureInscription = DateTime.Now,              Rang = 0 },
                        new Participer { IdUser = 125, NumeroTournoi = T("Tournoi Mario Kart").NumeroTournoi,        DateHeureInscription = DateTime.Now,              Rang = 0 },
                        // Tournoi Elden Ring No Hit
                        new Participer { IdUser = 845, NumeroTournoi = T("Tournoi Elden Ring No Hit").NumeroTournoi, DateHeureInscription = DateTime.Now.AddDays(-10), Rang = 0 },
                        new Participer { IdUser = 453, NumeroTournoi = T("Tournoi Elden Ring No Hit").NumeroTournoi, DateHeureInscription = DateTime.Now.AddDays(-7),  Rang = 0 },
                        new Participer { IdUser = 920, NumeroTournoi = T("Tournoi Elden Ring No Hit").NumeroTournoi, DateHeureInscription = DateTime.Now.AddDays(-3),  Rang = 0 },
                        new Participer { IdUser = 150, NumeroTournoi = T("Tournoi Elden Ring No Hit").NumeroTournoi, DateHeureInscription = DateTime.Now.AddDays(-3),  Rang = 0 },
                        new Participer { IdUser = 760, NumeroTournoi = T("Tournoi Elden Ring No Hit").NumeroTournoi, DateHeureInscription = DateTime.Now,              Rang = 0 },
                        new Participer { IdUser = 125, NumeroTournoi = T("Tournoi Elden Ring No Hit").NumeroTournoi, DateHeureInscription = DateTime.Now,              Rang = 0 },
                        // Tournoi Fortnite Saison 1
                        new Participer { IdUser = 845, NumeroTournoi = T("Tournoi Fortnite Saison 1").NumeroTournoi, DateHeureInscription = DateTime.Now.AddDays(-10), Rang = 0 },
                        new Participer { IdUser = 453, NumeroTournoi = T("Tournoi Fortnite Saison 1").NumeroTournoi, DateHeureInscription = DateTime.Now.AddDays(-7),  Rang = 0 },
                        new Participer { IdUser = 120, NumeroTournoi = T("Tournoi Fortnite Saison 1").NumeroTournoi, DateHeureInscription = DateTime.Now.AddDays(-7),  Rang = 0 },
                        // Tournoi LoL Printemps
                        new Participer { IdUser = 845, NumeroTournoi = T("Tournoi LoL Printemps").NumeroTournoi,     DateHeureInscription = DateTime.Now.AddDays(-10), Rang = 0 },
                        new Participer { IdUser = 453, NumeroTournoi = T("Tournoi LoL Printemps").NumeroTournoi,     DateHeureInscription = DateTime.Now.AddDays(-7),  Rang = 0 },
                        new Participer { IdUser = 920, NumeroTournoi = T("Tournoi LoL Printemps").NumeroTournoi,     DateHeureInscription = DateTime.Now.AddDays(-3),  Rang = 0 },
                        new Participer { IdUser = 150, NumeroTournoi = T("Tournoi LoL Printemps").NumeroTournoi,     DateHeureInscription = DateTime.Now.AddDays(-3),  Rang = 0 },
                        new Participer { IdUser = 858, NumeroTournoi = T("Tournoi LoL Printemps").NumeroTournoi,     DateHeureInscription = DateTime.Now,              Rang = 0 },
                        new Participer { IdUser = 495, NumeroTournoi = T("Tournoi LoL Printemps").NumeroTournoi,     DateHeureInscription = DateTime.Now.AddDays(-1),  Rang = 0 },
                        new Participer { IdUser = 921, NumeroTournoi = T("Tournoi LoL Printemps").NumeroTournoi,     DateHeureInscription = DateTime.Now.AddDays(-1),  Rang = 0 },
                        new Participer { IdUser = 152, NumeroTournoi = T("Tournoi LoL Printemps").NumeroTournoi,     DateHeureInscription = DateTime.Now.AddDays(-1),  Rang = 0 },
                        new Participer { IdUser = 857, NumeroTournoi = T("Tournoi LoL Printemps").NumeroTournoi,     DateHeureInscription = DateTime.Now.AddDays(-2),  Rang = 0 },
                        new Participer { IdUser = 470, NumeroTournoi = T("Tournoi LoL Printemps").NumeroTournoi,     DateHeureInscription = DateTime.Now.AddDays(-2),  Rang = 0 },
                        new Participer { IdUser = 910, NumeroTournoi = T("Tournoi LoL Printemps").NumeroTournoi,     DateHeureInscription = DateTime.Now.AddDays(-3),  Rang = 0 },
                        new Participer { IdUser = 149, NumeroTournoi = T("Tournoi LoL Printemps").NumeroTournoi,     DateHeureInscription = DateTime.Now.AddDays(-3),  Rang = 0 },
                    });
                    context.SaveChanges();
                }

                // Lancement du formulaire principal
                ApplicationConfiguration.Initialize();
                Application.Run(new FormAuthentification());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Crash au démarrage");
                MessageBox.Show($"Erreur au démarrage : {ex.Message}");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}