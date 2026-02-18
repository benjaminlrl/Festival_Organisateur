using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lib_Metier.Data.Configurations
{
    /// <summary>
    /// Configuration Entity Framework Core pour l'entité Espace.
    /// Définit le mapping table/colonnes, la clé primaire et le mapping des propriétés.
    /// Utilisé par le DbContext lors de la construction du modèle.
    /// </summary>
    public class EspaceConf : IEntityTypeConfiguration<Espace>
    {
        /// <summary>
        /// Configure les règles de mapping pour l'entité Espace.
        /// </summary>
        /// <param name="builder">Builder EF Core pour configurer l'entité.</param>
        public void Configure(EntityTypeBuilder<Espace> builder)
        {
            // Nom de la table en base de données
            builder.ToTable("Espace");

            // Définition de la clé primaire
            builder.HasKey(e => e.IdEspace);

            // Mapping explicite des colonnes : utile pour conserver la compatibilité
            // avec un schéma existant ou des conventions de nommage particulières.
            builder.Property(e => e.IdEspace)
                   .HasColumnName("id_espace");

            builder.Property(e => e.Nom)
                   .HasColumnName("nom");

            builder.Property(e => e.Description)
                   .HasColumnName("description");

            builder.Property(e => e.Superficie)
                   .HasColumnName("superficie");

            builder.Property(e => e.CapaciteMaxi)
                   .HasColumnName("capaciteMaxi");
        }
    }

}
