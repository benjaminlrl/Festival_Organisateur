# Festival_Organisateur

Afin de lancer une nouvelle migration
Installer et mettre a jour dotnet sur la machine
dotnet tool update --global dotnet-ef

Puis:
dotnet ef migrations add InitialCreate --project Lib_Metier --startup-project ApplicationUi
dotnet ef database update --project Lib_Metier --startup-project ApplicationUi
