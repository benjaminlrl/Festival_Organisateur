# Festival_Organisateur

Afin de lancer une nouvelle migration
Installer et mettre a jour dotnet sur la machine
dotnet tool update --global dotnet-ef

Puis:
dotnet ef migrations add InitialCreate --project Lib_Metier --startup-project ApplicationUi
dotnet ef database update --project Lib_Metier --startup-project ApplicationUi

## 📸 Captures d'écran

### Portail de connexion

![Portail de connexion](Documentation/App/portailConnexion.png)

### Acceuil

![Acceuil](Documentation/App/acceuilVotes.png)

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
![Espace de vote dédiés aux utilisateurs](Documentation/App/espaceVoter.png)
