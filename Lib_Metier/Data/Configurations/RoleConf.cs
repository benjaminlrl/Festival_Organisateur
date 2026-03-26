using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Metier.Data.Configurations
{
    public class RoleConf : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Nom de la table en base de données
            builder.ToTable("Role");

            // Définition de la clé primaire
            builder.HasKey(e => e.IdRole);

            // Mapping explicite des colonnes : utile pour conserver la compatibilité
            // avec un schéma existant ou des conventions de nommage particulières.
            builder.Property(e => e.Libelle);

            // Clés étrangères (noms de colonnes explicites)
            builder.Property(p => p.IdRole)
                   .HasColumnName("id_role");
        }
    }
}
