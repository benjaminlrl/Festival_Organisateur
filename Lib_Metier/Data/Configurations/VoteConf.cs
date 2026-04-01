using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Metier.Data.Configurations
{
    internal class VoteConf : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            // Nom de la table en base de données
            builder.ToTable("Vote");

            // Définition de la clé primaire
            builder.HasKey(v =>
                new { v.IdJeu, v.IdPlateforme, v.IdUser });

            // Mapping explicite des colonnes : utile pour conserver la compatibilité
            // avec un schéma existant ou des conventions de nommage particulières.
            builder.Property(v => v.DateVote)
                    .HasColumnName("dateVote");

            // Clés étrangères (noms de colonnes explicites)
            builder.Property(v => v.IdJeu)
                   .HasColumnName("id_jeu");

            builder.Property(v => v.IdPlateforme)
                   .HasColumnName("id_plateforme");

            builder.Property(v => v.IdUser)
                   .HasColumnName("id_user");
        }
    }
}
