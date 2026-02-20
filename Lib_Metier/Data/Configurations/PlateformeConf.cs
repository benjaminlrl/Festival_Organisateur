using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Metier.Data.Configurations
{
    /// <summary>
    /// Configuration Entity Framework Core pour l'entité Plateforme.
    /// Définit le mapping table/colonnes et la clé primaire utilisée par le DbContext.
    /// </summary>
    public class PlateformeConf : IEntityTypeConfiguration<Plateforme>
    {
        /// <summary>
        /// Configure le mapping EF Core pour l'entité Plateforme>.
        /// Appelé par le DbContext lors de la construction du modèle.
        /// </summary>
        /// <param name="builder">Builder utilisé pour configurer l'entité.</param>
        public void Configure(EntityTypeBuilder<Plateforme> builder)
        {
            // Nom explicite de la table en base de données
            builder.ToTable("Plateforme");

            // Définition de la clé primaire
            builder.HasKey(p => p.IdPlateforme);

            // Mapping explicite des colonnes : utile pour conserver la compatibilité
            // avec un schéma existant ou des conventions de nommage particulières.
            builder.Property(p => p.IdPlateforme)
                   .HasColumnName("id_plateform");

            builder.Property(p => p.Libelle)
                   .HasColumnName("libelle");
        }
    }
}
