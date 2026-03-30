using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lib_Metier.Data.Configurations
{
    /// <summary>
    /// DbContext Entity Framework Core pour l'application.
    /// Expose les ensembles d'entités (DbSet) et applique les configurations
    /// définies dans l'assembly via <see cref="OnModelCreating"/>.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Ensemble des organisateurs (table `Organisateur`).
        /// Utilise `Set<T>()` pour rester compatible avec le pattern DbContext minimal.
        /// </summary>
        public DbSet<Organisateur> Organisateurs => Set<Organisateur>();

        /// <summary>
        /// Ensemble des plateformes (table `Plateforme`).
        /// </summary>
        public DbSet<Plateforme> Plateformes => Set<Plateforme>();

        /// <summary>
        /// Ensemble des postes de jeu (table `Poste_Jeu`).
        /// </summary>
        public DbSet<PosteJeu> PostesJeu => Set<PosteJeu>();

        /// <summary>
        /// Ensemble des tournois (table `Tournoi`).
        /// </summary>
        public DbSet<Tournoi> Tournois => Set<Tournoi>();

        /// <summary>
        /// Ensemble des Lot (table `Lot`).
        /// </summary>
        public DbSet<Lot> Lots => Set<Lot>();

        /// <summary>
        /// Ensemble des LotComposant (table `LotComposant`).
        /// </summary>
        public DbSet<LotComposant> LotComposants => Set<LotComposant>();

        /// <summary>
        /// Ensemble des Espaces (table `Espace`).
        /// </summary>
        public DbSet<Espace> Espaces => Set<Espace>();

        /// <summary>
        /// Ensemble des Role (table `Role`).
        /// </summary>
        public DbSet<Role> Roles => Set<Role>();


        /// <summary>
        /// Configure la source de données : ici une base SQLite locale : `gestionTournois.db`
        /// </summary>
        /// <param name="options">Builder des options de DbContext.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=C:\Users\Lucien\Desktop\Reste\Skript Github\Festival_Organisateur\ApplicationUi\gestionTournois.db");
        }

        /// <summary>
        /// Applique les configurations EF Core définies dans l'assembly.
        /// Utilise `ApplyConfigurationsFromAssembly` pour centraliser les mappings
        /// (IEntityTypeConfiguration&lt;T&gt;).
        /// </summary>
        /// <param name="modelBuilder">Builder du modèle EF Core.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Charge automatiquement toutes les classes de configuration (PlateformeConf, EspaceConf, etc.).
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }

}
