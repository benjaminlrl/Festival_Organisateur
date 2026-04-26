# 🎪 Festival Organisateur

Application de bureau **Windows Forms** développée en **C#** dans le cadre d'un BTS SIO Option SLAM (2025-2026).

Elle permet la gestion complète d'un festival : organisateurs, espaces, tournois, jeux, plateformes, lots et système de vote.

> ⚠️ Projet en cours de développement — versions alpha uniquement, ne pas déployer en production.

---

## 📋 Sommaire

- [Fonctionnalités](#-fonctionnalités)
- [Architecture](#-architecture)
- [Modèle de données](#-modèle-de-données)
- [Gestion des rôles](#-gestion-des-rôles)
- [Validations métiers](#-validations-metier)
- [Prérequis](#-prérequis)
- [Installation & Migrations](#-installation--migrations)
- [Contributeurs](#-contributeurs)
- [Releases](#-releases)

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

Le projet suit une **architecture en couches** afin de séparer clairement les responsabilités et faciliter la maintenance.

```
Festival_Organisateur/
├── ApplicationUi/              # Interface utilisateur (WinForms)
├── ApplicationUI.TestUnits/    # Tests unitaires
├── Lib_Entities/               # Entités métier (POCO)
├── Lib_Metier/                 # DbContext EF Core, configurations, migrations
├── Lib_Services/               # Logique métier, interfaces, validations
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
Contient les interfaces (`IxxxService`) et leurs implémentations. Centralise les règles métier et les accès EF Core.

**`ApplicationUI`** — Interface utilisateur  
Contient la `FormMain`, les `UserControls` par module et la gestion des droits d'accès.

### Stack technique

| Technologie | Usage |
|---|---|
| C# / WinForms | Interface utilisateur |
| Entity Framework Core | ORM |
| SQLite | Base de données |
| BCrypt | Hashage des mots de passe |

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

| Rôle | CRUD | Consultation |
|---|---|---|
| **Administrateur** | Toutes les tables | — |
| **Gestionnaire du stock** | Lot, LotComposant | Tournoi, Jeu, Espace, PosteJeu, Plateforme |
| **Gestionnaire de l'espace** | Espace, PosteJeu, Tournoi | Plateforme, Jeu, Participer |
| **Gestionnaire des tournois** | Tournoi, Participer, SoumisVote | Espace, PosteJeu, Plateforme, Jeu, Lot, Voter |

---

## Documentation des validations métier

---

### Espace

#### Création et modification
- Le nom est requis
- Le nom doit être unique (pas déjà attribué à un autre espace)
- Les 3 premières lettres du nom doivent être uniques (utilisées pour le formatage des références des postes de jeu) — ignoré si `modifPosteJeu = true`
- La description est requise
- La superficie doit être comprise entre 9 et 60
- La capacité maximale doit être comprise entre 0 et 50

#### Modification uniquement
- L'espace doit exister en base
- L'identifiant ne peut pas être modifié
- Au moins une modification doit être détectée
- Si le nom est modifié sans `modifPosteJeu = true`, une confirmation est requise (les postes de jeu associés seraient désynchronisés)

---

### Jeu

#### Création et modification
- Le titre est requis
- Le titre doit être unique
- La description est requise et ne doit pas dépasser 500 caractères
- L'éditeur est requis
- La date de sortie est requise
- Le PEGI doit correspondre à une valeur valide de l'énumération

---

### Plateforme

#### Création et modification
- Le libellé est requis
- Le libellé doit être unique
- L'identifiant doit être positif ou nul

#### Modification uniquement
- La plateforme doit exister en base
- Au moins une modification doit être détectée

#### Suppression
- La plateforme ne doit pas avoir de postes de jeu associés
- La plateforme ne doit pas avoir de jeux associés

---

### Poste de jeu

#### Création et modification
- La référence est requise
- Un espace doit être associé (`IdEspace > 0`)
- Une plateforme doit être associée (`IdPlateforme > 0`)
- La référence doit être unique parmi les postes de jeu existants

#### Création uniquement
- La référence est générée automatiquement à partir des 3 premières lettres de l'espace et d'un numéro séquentiel
- Si la référence générée existe déjà, le numéro est incrémenté jusqu'à trouver une référence disponible

#### Modification uniquement
- Le poste de jeu doit exister en base
- Au moins une modification doit être détectée
- L'espace associé ne peut pas être modifié
- La plateforme associée ne peut pas être modifiée

---

### Tournoi

#### Création et modification
- Le nom est requis
- Le nom doit être unique
- Un jeu doit être associé (`IdJeu > 0`)
- Un espace doit être associé (`IdEspace > 0`)
- Le nombre de participants doit être supérieur à 0
- La durée prévue doit être supérieure à 0
- Le statut est requis
- Pas de conflit horaire avec un autre tournoi dans le même espace (chevauchement ou doublon "En cours")
- Les horaires doivent respecter les plages autorisées : Samedi 10h–20h, Dimanche 10h–18h

#### Création uniquement
- La date et l'heure doivent être dans le futur

#### Modification uniquement
- Le tournoi doit exister en base
- Au moins une modification doit être détectée
- Le jeu associé ne peut pas être modifié
- Le statut d'un tournoi "Terminé" ne peut pas être changé

---

### SoumisVote

#### Création et modification
- Le jeu associé doit exister en base
- La plateforme associée doit exister en base
- La date de début doit être antérieure à la date de fin
- La date de début ne peut pas être dans le passé
- La date de fin ne peut pas être dans le passé

#### Création uniquement
- La combinaison jeu/plateforme doit être unique

#### Modification uniquement
- Au moins une modification doit être détectée (date de début ou date de fin)

---

## Participer (Inscription à un tournoi)

#### Création et modification
- Le tournoi associé doit exister en base
- L'utilisateur ne peut pas participer à deux tournois se déroulant au même moment (chevauchement horaire)
- L'évaluation doit être comprise entre 0 et 10
- Le commentaire ne peut pas dépasser 500 caractères

#### Création uniquement
- L'utilisateur ne peut pas s'inscrire deux fois au même tournoi
- Le tournoi ne doit pas être terminé
- Le tournoi ne doit pas être en cours
- Le nombre de participants ne doit pas avoir atteint la limite du tournoi
- Le rang doit être 0 à l'inscription
- Le score final doit être 0 à l'inscription
- Le lot ne peut pas être marqué comme remis à l'inscription

#### Modification uniquement
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

### Vote (Voter)

#### Création et modification
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
dotnet ef database update --project Lib_Metier --startup-project ApplicationUi
```

> ⚠️ Le projet par défaut de la console NuGet doit être `Lib_Metier` et le projet de démarrage doit être `ApplicationUi`.

### 4. Lancer l'application

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

| Version | Date | Description |
|---|---|---|
| [v1.3.0-alpha](https://github.com/benjaminlrl/Festival_Organisateur/releases/tag/v1.3.0-alpha) | Avr. 2026 | Gestion des lots, amélioration postes de jeu, corrections bugs |
| [v1.2.0-alpha](https://github.com/benjaminlrl/Festival_Organisateur/releases/tag/v1.2.0-alpha) | Avr. 2026 | Système de vote, gestion des lots, association jeux/plateformes |
| [v1.1.0-alpha](https://github.com/benjaminlrl/Festival_Organisateur/releases/tag/v1.1.0-alpha) | Mar. 2026 | Gestion des jeux, lots, tournois, enrichissement validations |
| [v1.0.1-alpha](https://github.com/benjaminlrl/Festival_Organisateur/releases/tag/v1.0.1-alpha) | Mar. 2026 | Correction bug lancement application |
| [v1.0.0-alpha](https://github.com/benjaminlrl/Festival_Organisateur/releases/tag/v1.0.0-alpha) | Mar. 2026 | Connexion BCrypt, organisateurs, espaces, postes de jeu, tournois |
| [v0.0.0](https://github.com/benjaminlrl/Festival_Organisateur/releases/tag/v0.0.0) | Mar. 2026 | État initial de référence |

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
