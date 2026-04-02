using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Metier.Data.Configurations
{
    internal class ParticiperConf : IEntityTypeConfiguration<Participer>
    {
        public void Configure(EntityTypeBuilder<Participer> builder)
        {
            // Nom de la table en base de données
            builder.ToTable("Participer");

            // Définition de la clé primaire
            builder.HasKey(p =>
                new { p.IdUser, p.NumeroTournoi });

            // Mapping explicite des colonnes : utile pour conserver la compatibilité
            // avec un schéma existant ou des conventions de nommage particulières.
            builder.Property(p => p.Rang)
                    .HasColumnName("rang");

            // Clés étrangères (noms de colonnes explicites)
            builder.Property(p => p.Evaluation)
                   .HasColumnName("evaluation");

            builder.Property(p => p.Commentaire)
                   .HasColumnName("commentaire");

            builder.Property(p => p.DateHeureInscription)
                   .HasColumnName("dateHeureInscription");

            builder.Property(p => p.ScoreFinal)
                   .HasColumnName("scoreFinal");

            builder.Property(p => p.LotRemis)
                   .HasColumnName("lotRemis");
        }
    }
}
