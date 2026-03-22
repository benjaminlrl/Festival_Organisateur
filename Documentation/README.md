# Festival_Organisateur

## Conventions de nommage

- Les classes sont écrites en PascalCase (ex: `FestivalOrganisateur`).
- Les méthodes sont écrites en camelCase (ex: `organiserFestival()`).
- Les variables sont écrites en camelCase (ex: `nomFestival`).
- Les constantes sont écrites en majuscules avec des underscores (ex: `NOMBRE_MAX_FESTIVALS`).
- Les fichiers sont nommés en fonction de la classe qu'ils contiennent (ex: `FestivalOrganisateur`).
- Les packages sont nommés en minuscules (ex: `com.festival.organisateur`).
- Les interfaces sont nommées en PascalCase et commencent par "I" (ex: `IFestivalOrganisateur`).
- Les exceptions sont nommées en PascalCase et se terminent par "Exception" (ex: `FestivalOrganisateurException`).
- Les tests unitaires sont nommés en fonction de la classe qu'ils testent, suivis de "Test" (ex: `FestivalOrganisateurTest`).
- Les commentaires sont écrits en franéais et expliquent clairement le but de chaque classe, méthode et variable.
- Les noms de variables et de méthodes doivent être descriptifs et refléter leur fonction (ex: `organiserFestival()` au lieu de `organiser()`).
- Les noms de classes et de méthodes doivent être cohérents avec les conventions de nommage utilisées dans le projet.

## Conventions de nommage pour les branches

feature/auth
feature/user-profile
fix/login-bug
hotfix/security-patch

## Conventions de nommage pour les commit

type(scope): message

### Types principaux :

    feat → nouvelle feature
    fix → bug
    refactor → amélioration sans changement fonctionnel
    docs → documentation
    test → tests
    chore → maintenance

#### Exemples :

feat(auth): add JWT authentication
fix(auth): resolve token expiration issue
refactor(auth): simplify middleware logic

## Template pour les Pull Request

## 🧩 Description

Explique clairement ce que fait cette PR.

## 🎯 Objectif

Pourquoi ce changement est nécessaire ?

## 🔨 Changements principaux

-
-
-

## 🔗 Dépendances

- Dépend de : (ex: feature/auth)
- Impacte : (ex: routes protégées, API…)

## 🧪 Tests

- [ ] Testé manuellement
- [ ] Tests unitaires ajoutés
- [ ] Pas de test nécessaire

## ⚠️ Points d’attention

-

## 📸 Screenshots (si UI)

Ajoute des images si nécessaire

## ✅ Checklist

- [ ] Code relu
- [ ] Pas de conflit avec main
- [ ] Build OK

## Workflow d’équipe (simple et pro)

### Étapes standard :

Créer une branche depuis main
git checkout main
git pull
git checkout -b feature/ma-feature

### Travailler + commits propres

Ouvrir PR vers :
👉 soit feature/auth (si dépendance)
👉 soit main (si autonome)

### Merge après validation

Toujours se resync :
git checkout ma-branche
git pull origin main

## Règles d’or (très importantes)

PR petites → plus faciles à review
Ne pas laisser une branche diverger trop longtemps
Toujours partir de main à jour
Une feature critique (comme auth) → branch dédiée ✅ (ce que tu as fait 👍)
