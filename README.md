# 🎪 Festival Organisateur

Application de bureau **Windows Forms** développée en **C#** dans le cadre d'un BTS SIO Option SLAM (2025-2026).

Elle permet la gestion complète d'un festival : organisateurs, espaces, tournois, jeux, plateformes, lots et système de vote.

> ⚠️ Projet en cours de développement — versions alpha uniquement, ne pas déployer en production.

---

## 📋 Sommaire

- [Fonctionnalités](#-fonctionnalités)
- [Architecture](#-architecture)
  - [Relations entre les couches](#relations-entre-les-couches)
  - [Détail des couches](#détail-des-couches)
  - [Stack technique](#stack-technique)
  - [Packages NuGet](#packages-nuget)
- [Modèle de données](#-modèle-de-données)
- [Gestion des rôles](#-gestion-des-rôles)
- [Documentation des validations métier](#-documentation-des-validations-métier)
  - [Architecture des contrôles](#architecture-de-mise-en-place-du-controles-des-données)
  - [UserControl Tournois](#démarche-à-suivre-dans-le-usercontrol-dédié-aux-tournoisconfiguration-minimale)
  - [Interface & Service](#faire-le-lien-entre-linterface-et-le-service)
  - [Exceptions métier](#création-des-exceptions-liés-aux-tournois)
  - [Liste des contrôles](#listes-des-controles-présents-actuellement)
- [Prérequis](#-prérequis)
- [Installation & Migrations](#-installation--migrations)
  - [Cloner le dépôt](#1-cloner-le-dépôt)
  - [Installer EF CLI](#2-installer-loutil-ef-core-cli)
  - [Appliquer les migrations](#3-appliquer-les-migrations)
  - [Mettre à jour la base](#4-mettre-à-jour-une-migration)
  - [Lancer l'application](#5-lancer-lapplication)
  - [Réinitialiser la base](#réinitialiser-la-base-de-données-développement-uniquement)
- [Contributeurs](#-contributeurs)
- [Releases](#-releases)
- [Captures d'écran](#-captures-décran)

---

## ✨ Fonctionnalités

### 👤 Organisateurs

- Authentification avec hashage du mot de passe (BCrypt)
- Création et gestion des comptes organisateurs
- Gestion des rôles et permissions par module

### 🏟️ Espaces

- Création et gestion des espaces du festival (nom, description, superficie, capacité max)
- Statut des espaces associés à des tournois

### 🎮 Jeux & Plateformes

- Ajout et gestion des jeux (titre, éditeur, année de sortie, PEGI, description)
- Gestion des plateformes
- Association des jeux aux plateformes

### 🏆 Tournois

- Création et suivi des tournois (date, durée prévue, nb participants, statut)
- Plusieurs tournois peuvent avoir lieu simultanément dans des espaces différents
- Indication si un tournoi est en cours sur un poste de jeu

### 🖥️ Postes de jeu

- Gestion des postes de jeu associés aux espaces et plateformes
- Suivi de l'état fonctionnel de chaque poste

### 🎁 Lots

- Création et gestion des lots (libellé, valeur totale, rang d'attribution)
- Ajout de composants de lot (libellé, description, valeur)
- Ajout automatique de lots dans le programme
- Attribution des lots aux tournois

### 🗳️ Système de vote

- Soumission de jeux au vote avec période configurable (date début / date fin)
- Classement des binômes (jeu, plateforme) les plus votés
- Gestion des votes par joueur

### 👥 Joueurs

- Inscription des joueurs (pseudo, email, nom, prénom)
- Participation aux tournois avec rang, évaluation, commentaire et score final

---

## 🏗️ Architecture

_CRUD signifie Create, Read, Update, Delete_
_CUD signifie Create, Update, Delete_
_R signifie Read_
Le projet suit une **architecture en couches** afin de séparer clairement les responsabilités et faciliter la maintenance.

```
Festival_Organisateur/
├── ApplicationUi/              # Interface utilisateur (WinForms)
├── Lib_Entities/               # Entités métier (POCO)
├── Lib_Metier/                 # DbContext EF Core, configurations, migrations
├── Lib_Services/               # Logique métier, interfaces, validations, exceptions
└── Documentation/              # Captures d'écran & documents
```

### Relations entre les couches

```
ApplicationUI → Lib_Services → Lib_Entities
               Lib_Metier   → Lib_Entities
```

### Détail des couches

**`Lib_Entities`** — Entités métier  
Contient uniquement les classes métier, chacune correspondant à une table de la base de données.

**`Lib_Metier`** — Accès aux données (EF Core)  
Contient le `DbContext`, les classes de configuration EF Core (`XxxConf.cs`) définissant les clés primaires, relations et contraintes, ainsi que le dossier `Migrations`.

**`Lib_Services`** — Logique métier  
Contient les interfaces (`IxxxService`) et leurs implémentations. Centralise les règles métier, les exceptions et les accès EF Core.

**`ApplicationUI`** — Interface utilisateur  
Contient la `FormMain`, les `UserControls` par module et la gestion des droits d'accès.

### Stack technique

| Technologie           | Usage                     |
| --------------------- | ------------------------- |
| C# / WinForms         | Interface utilisateur     |
| Entity Framework Core | ORM                       |
| SQLite                | Base de données           |
| BCrypt                | Hashage des mots de passe |
| SeriLog               | Loggeur d'informations    |

### Packages NuGet

- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.Sqlite`
- `Microsoft.EntityFrameworkCore.Tools`
- `Microsoft.EntityFrameworkCore.Design`

---

## 🗄️ Modèle de données

Le schéma UML complet est disponible dans le dossier [`Documentation/`](./Documentation/).

Les entités principales sont : `Organisateur`, `Role`, `Joueur`, `Jeu`, `Plateforme`, `Tournoi`, `Espace`, `Poste_Jeu`, `Lot`, `LotComposant`, `SoumisVote`, `Voter`, `Participer`.

---

## 🔐 Gestion des rôles

Quatre rôles ont été définis dans l'application :

| Rôle                          | CRUD                            | Consultation                                  |
| ----------------------------- | ------------------------------- | --------------------------------------------- |
| **Administrateur**            | Toutes les tables               | —                                             |
| **Gestionnaire du stock**     | Lot, LotComposant               | Tournoi, Jeu, Espace, PosteJeu, Plateforme    |
| **Gestionnaire de l'espace**  | Espace, PosteJeu, Tournoi       | Plateforme, Jeu, Participer                   |
| **Gestionnaire des tournois** | Tournoi, Participer, SoumisVote | Espace, PosteJeu, Plateforme, Jeu, Lot, Voter |

---

## 🔐 Documentation des validations métier

---

Architecture de mise en place du controles des données :

Festival_Organisateur/
├── Application_Ui/TournoiUc.cs # Controles sur les interractions et données entre l'IHM et TournoiService.cs
|
├── Lib_Services/ITournoiService.cs # Interface qui permet de ne pas avoir à réécrire les Uc en cas de migrations techniques
├── Lib_Services/TournoiService.cs # Controles sur les données liés aux tournois avant interraction dans la bdd
|
└── ServiceTests/TournoiServiceValidationTests # Tests unitaires dédiés aux tournois

### Démarche à suivre dans le UserControl dédié aux Tournois(configuration minimale)

_Faire le lien entre le UserControl et l'Interface_

```
Festival_Organisateur/
└── Application_Ui/TournoiUc.cs
```

```C#
using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Exceptions;
using Lib_Services.Interfaces;
using Lib_Services.Services;

namespace ApplicationUi
{
    public partial class UcTournois : UserControl
    {
        private readonly ApplicationDbContext _context;
        private readonly ITournoiService _serviceTournoi;

        public UcTournois()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _serviceTournoi = new TournoiService(_context);
[...]
```

_Ajouter un Tournoi dans la base de données_

```C#
 private void ButtonAjouter_Click(object sender, EventArgs e)
 {
     Tournoi tournoi = new ()
     {
         Nom = textBoxNom.Text,
         DateHeure = dateTimePickerDateTournoi.Value,
         NbParticipants = (int)numericUpDownNbParticip.Value,
         DureePrevue = (int)numericUpDownDuree.Value,
         Statut = statutSelectionne,
         IdEspace = (comboBoxEspace.SelectedItem as Espace).IdEspace,
         IdJeu = (comboBoxJeu.SelectedItem as Jeu).IdJeu,
     };

     try
     {
         _serviceTournoi.Creer(tournoi);
         MessageBox.Show("Le tournoi a bien été ajouté.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
         Raz_Zones();
     }
     catch (TournoiException ex)
     {
         Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
         MessageBox.Show("Veuillez vérifier les informations saisies.\n" + ex.Message, "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
     }
     catch (DbException ex)
     {
         Log.Error(ex, "Une erreur technique est survenue lors de l'ajout du tournoi.");
         MessageBox.Show("Erreur technique, réessayez plus tard.");
     }
     catch (Exception ex)
     {
         Log.Error(ex, "Une erreur inattendue est survenue.");
         MessageBox.Show("Une erreur inattendue est survenue.");
     }
 }

```

_Faire le lien entre l'Interface et le Service'_

> Info: La méthode n'est pas accessible dans le Uc si sa signature n'est pas définie dans l'Interface et si sa signature existe dans le service

```
Festival_Organisateur/
└── Lib_Services/Interfaces/ITournoiService.cs
```

```C#
using Lib_Entities.Entities;

namespace Lib_Services.Interfaces
{
    public interface ITournoiService
    {
        #region CUD
        /// <summary>
        /// Crée un nouveau tournoi en base après validation métier minimale.
        /// Lance une <see cref="ArgumentException"/> si le nombre de participants est invalide.
        /// </summary>
        /// <param name="tournoi">Instance du tournoi à créer.</param>
        void Creer(Tournoi tournoi);
[...]
```

```
Festival_Organisateur/
└── Lib_Services/Services/TournoiService.cs
```

```C#
using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Exceptions;
using Lib_Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib_Services.Services
{
    /// <summary>
    /// Service métier responsable des opérations
    /// CRUD sur l'entité <see cref="Tournoi"/>.
    /// </summary>
    public class TournoiService : ITournoiService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initialise une nouvelle instance
        /// de <see cref="TournoiService"/>.
        /// <param name="context">DbContext
        /// injecté pour l'accès aux données.</param>
        /// </summary>
        public TournoiService(ApplicationDbContext context)
        {
            _context = context;
        }
[...]
#region CUD
/// <summary>
/// Crée un nouveau tournoi en base après validation métier minimale.
/// Lance une <see cref="ArgumentException"/> si le nombre de participants est invalide.
/// </summary>
/// <param name="tournoi">Instance du tournoi à créer.</param>
public void Creer(Tournoi tournoi)
{
    ValiderTournoi(tournoi, false);
    // Ajout et sauvegarde immédiate.
    _context.Tournois.Add(tournoi);
    _context.SaveChanges();
}
```

---

### Création des Exceptions liés aux tournois

> Info: on contrôle chaque action de l'utilisateur (politique du moindre privilège).
> Pour controler ses actions, nous utilisons les exceptions.

#### Avantages :

- Indépendant des Uc
- Controles profond des données
- Meilleure maintenabilité
- Exceptions personnalisées
- Facile à utiliser pour les tests unitaires

#### Inconvéniants :

- Lourd à mettre en place

#### Mise en place

```
Festival_Organisateur/
└── Lib_Services/Services/TournoiService.cs
```

```C#
/// <summary>
/// Permet de valider les données d'un tournoi avant
/// création ou modification.
/// </summary>
/// <param name="tournoi">Tournoi à valider</param>
/// <param name="estModification">Indique si c'est une modification
/// ou une création</param>
/// <exception cref="TournoiException">Exception si les données du
/// tournoi sont invalides</exception>
public void ValiderTournoi(Tournoi tournoi, bool estModification = false)
{
    if (string.IsNullOrWhiteSpace(tournoi.Nom))
        throw new TournoiException("Le nom est requis.",
            (int)TournoiException.TournoiErreur.TournoiNomRequis);

    if (estModification)
    {
        Tournoi? enBdd = Obtenir(tournoi.NumeroTournoi);

        if(enBdd == null)
            throw new TournoiException("Tournoi inexistant en base de donnée.",
                (int)TournoiException.TournoiErreur.ModificationTournoiInexistant);

    [...]
```

_`TournoiNomRequis`_ corresppond au nom associé au code de l'Exception

_`TournoiException`_ corresppond la classe dédié aux exceptions liés aux tournois

_`TournoiErreur`_ correspond à la propriété de la classe _`TournoiException`_ qui contient les codes

#### Définir les codes des exceptions

```
Festival_Organisateur/
└── Lib_Services/Exceptions/TournoiException.cs
```

```C#
namespace Lib_Services.Exceptions
{
    public class TournoiException : Exception
    {
        public int CodeErreur { get; }

        public enum TournoiErreur
        {
            TournoiNomRequis = 1,
            ModificationTournoiInexistant = 2,
            // LeNomDeException = ...,
        }

        public TournoiException(string message, int codeErreur) : base(message)
        {
            CodeErreur = codeErreur;
        }
    }
}
```

---

### Listes des controles présents actuellement

#### Espace

##### Création et modification

- Le nom est requis
- Le nom doit être unique (pas déjà attribué à un autre espace)
- Les 3 premières lettres du nom doivent être uniques (utilisées pour le formatage des références des postes de jeu) — ignoré si `modifPosteJeu = true`
- La description est requise
- La superficie doit être comprise entre 9 et 60
- La capacité maximale doit être comprise entre 0 et 50

##### Modification uniquement

- L'espace doit exister en base
- L'identifiant ne peut pas être modifié
- Au moins une modification doit être détectée
- Si le nom est modifié sans `modifPosteJeu = true`, une confirmation est requise (les postes de jeu associés seraient désynchronisés)

---

#### Jeu

##### Création et modification

- Le titre est requis
- Le titre doit être unique
- La description est requise et ne doit pas dépasser 500 caractères
- L'éditeur est requis
- La date de sortie est requise
- Le PEGI doit correspondre à une valeur valide de l'énumération

---

#### Plateforme

##### Création et modification

- Le libellé est requis
- Le libellé doit être unique
- L'identifiant doit être positif ou nul

##### Modification uniquement

- La plateforme doit exister en base
- Au moins une modification doit être détectée

##### Suppression

- La plateforme ne doit pas avoir de postes de jeu associés
- La plateforme ne doit pas avoir de jeux associés

---

#### Poste de jeu

##### Création et modification

- La référence est requise
- Un espace doit être associé (`IdEspace > 0`)
- Une plateforme doit être associée (`IdPlateforme > 0`)
- La référence doit être unique parmi les postes de jeu existants

##### Création uniquement

- La référence est générée automatiquement à partir des 3 premières lettres de l'espace et d'un numéro séquentiel
- Si la référence générée existe déjà, le numéro est incrémenté jusqu'à trouver une référence disponible

##### Modification uniquement

- Le poste de jeu doit exister en base
- Au moins une modification doit être détectée
- L'espace associé ne peut pas être modifié
- La plateforme associée ne peut pas être modifiée

---

#### Tournoi

##### Création et modification

- Le nom est requis
- Le nom doit être unique
- Un jeu doit être associé (`IdJeu > 0`)
- Un espace doit être associé (`IdEspace > 0`)
- Le nombre de participants doit être supérieur à 0
- La durée prévue doit être supérieure à 0
- Le statut est requis
- Pas de conflit horaire avec un autre tournoi dans le même espace (chevauchement ou doublon "En cours")
- Les horaires doivent respecter les plages autorisées : Samedi 10h–20h, Dimanche 10h–18h

##### Création uniquement

- La date et l'heure doivent être dans le futur

##### Modification uniquement

- Le tournoi doit exister en base
- Au moins une modification doit être détectée
- Le jeu associé ne peut pas être modifié
- Le statut d'un tournoi "Terminé" ne peut pas être changé

---

#### SoumisVote

##### Création et modification

- Le jeu associé doit exister en base
- La plateforme associée doit exister en base
- La date de début doit être antérieure à la date de fin
- La date de début ne peut pas être dans le passé
- La date de fin ne peut pas être dans le passé

##### Création uniquement

- La combinaison jeu/plateforme doit être unique

##### Modification uniquement

- Au moins une modification doit être détectée (date de début ou date de fin)

---

#### Participer (Inscription à un tournoi)

##### Création et modification

- Le tournoi associé doit exister en base
- L'utilisateur ne peut pas participer à deux tournois se déroulant au même moment (chevauchement horaire)
- L'évaluation doit être comprise entre 0 et 10
- Le commentaire ne peut pas dépasser 500 caractères

##### Création uniquement

- L'utilisateur ne peut pas s'inscrire deux fois au même tournoi
- Le tournoi ne doit pas être terminé
- Le tournoi ne doit pas être en cours
- Le nombre de participants ne doit pas avoir atteint la limite du tournoi
- Le rang doit être 0 à l'inscription
- Le score final doit être 0 à l'inscription
- Le lot ne peut pas être marqué comme remis à l'inscription

##### Modification uniquement

- La participation doit exister en base
- L'identifiant de l'utilisateur ne peut pas être modifié
- La date et l'heure d'inscription ne peuvent pas être modifiées
- Le rang ne peut pas être négatif
- Le rang ne peut pas dépasser le nombre de participants du tournoi
- Le rang ne peut être défini (> 0) que si le tournoi est terminé
- Le score final ne peut pas être négatif
- Le score final ne peut être défini (≠ 0) que si le tournoi est terminé
- Le lot ne peut être marqué comme remis que si le tournoi est terminé
- Au moins une modification doit être détectée

---

#### Vote (Voter)

##### Création et modification

- L'identifiant de l'utilisateur doit être supérieur à 0
- Un utilisateur ne peut pas dépasser le nombre maximum de votes autorisés (`NbMaxVotesParJoueur`)
- Un utilisateur ne peut pas voter deux fois pour le même binôme jeu/plateforme

---

## 🛠️ Prérequis

- [.NET 8+](https://dotnet.microsoft.com/download)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/fr/)
- `dotnet-ef` (Entity Framework CLI)

---

## 🚀 Installation & Migrations

### 1. Cloner le dépôt

```bash
git clone https://github.com/benjaminlrl/Festival_Organisateur.git
```

### 2. Installer l'outil EF Core CLI

```bash
dotnet tool update --global dotnet-ef
```

### 3. Appliquer les migrations

```bash
dotnet ef migrations add InitialCreate --project Lib_Metier --startup-project ApplicationUi
```

### 4. Mettre à jour une migration

```bash
dotnet ef database update --project Lib_Metier --startup-project ApplicationUi
```

> ⚠️ Le projet par défaut de la console NuGet doit être `Lib_Metier` et le projet de démarrage doit être `ApplicationUi`.

### 5. Lancer l'application

Ouvrir la solution dans Visual Studio et lancer `ApplicationUi` comme projet de démarrage.

### Réinitialiser la base de données (développement uniquement)

Supprimer le dossier `Migrations` et le fichier `.db`, puis relancer les commandes ci-dessus.

> ⚠️ Cette méthode est interdite en production.

---

## 👥 Contributeurs

- [@benjaminlrl](https://github.com/benjaminlrl)
- [@lucienlaf](https://github.com/lucienlaf)

---

## 📦 Releases

| Version                                                                                        | Date      | Description                                                       |
| ---------------------------------------------------------------------------------------------- | --------- | ----------------------------------------------------------------- |
| [v1.3.0-alpha](https://github.com/benjaminlrl/Festival_Organisateur/releases/tag/v1.3.0-alpha) | Avr. 2026 | Gestion des lots, amélioration postes de jeu, corrections bugs    |
| [v1.2.0-alpha](https://github.com/benjaminlrl/Festival_Organisateur/releases/tag/v1.2.0-alpha) | Avr. 2026 | Système de vote, gestion des lots, association jeux/plateformes   |
| [v1.1.0-alpha](https://github.com/benjaminlrl/Festival_Organisateur/releases/tag/v1.1.0-alpha) | Mar. 2026 | Gestion des jeux, lots, tournois, enrichissement validations      |
| [v1.0.1-alpha](https://github.com/benjaminlrl/Festival_Organisateur/releases/tag/v1.0.1-alpha) | Mar. 2026 | Correction bug lancement application                              |
| [v1.0.0-alpha](https://github.com/benjaminlrl/Festival_Organisateur/releases/tag/v1.0.0-alpha) | Mar. 2026 | Connexion BCrypt, organisateurs, espaces, postes de jeu, tournois |
| [v0.0.0](https://github.com/benjaminlrl/Festival_Organisateur/releases/tag/v0.0.0)             | Mar. 2026 | État initial de référence                                         |

## 📸 Captures d'écran

### Portail de connexion

![Portail de connexion](Documentation/App/portailConnexion.png)

### Accueil

![Acceuil](Documentation/App/Accueil.png)

### Gestion des espaces

![Gestion des espaces](Documentation/App/gestionEspaces.png)

### Gestion des plateformes

![Gestion des plateformes](Documentation/App/gestionPlateformes.png)

### Gestion des tournois

![Gestion des tournois](Documentation/App/gestionTournois.png)

### Gestion des postes de jeu

![Gestion des postes de jeu](Documentation/App/gestionPostesJeu.png)

### Gestion des organisateurs

![Gestion des organisateurs](Documentation/App/gestionOrganisateurs.png)

### Gestion des jeux

![Gestion des organisateurs](Documentation/App/gestionJeux.png)

### Espace de votes pour les utilisateurs

![Espace de votes dédié aux utilisateurs](Documentation/App/espaceVoter.png)

### Gestion des lots

![Gestion des lots](Documentation/App/gestionLots.png)

### Gestion des composants des lots

![Espace de votes dédié aux utilisateurs](Documentation/App/gestionComposantsLots.png)
