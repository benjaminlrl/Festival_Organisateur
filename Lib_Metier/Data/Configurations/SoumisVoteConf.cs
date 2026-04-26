using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Metier.Data.Configurations
{
    public class SoumisVoteConf : IEntityTypeConfiguration<SoumisVote>
    {
        public void Configure(EntityTypeBuilder<SoumisVote> builder)
        {
            // Nom de la table en base de données
            builder.ToTable("SoumisVote");

            // Définition de la clé primaire
            builder.HasKey(s =>
                new { s.IdJeu, s.IdPlateforme});

            // Mapping explicite des colonnes : utile pour conserver la compatibilité
            // avec un schéma existant ou des conventions de nommage particulières.
            builder.Property(s => s.DateDebutVote)
                   .HasColumnName("dateDebutVote");

            builder.Property(s => s.DateFinVote)
                    .HasColumnName("dateFinVote");

            // Clés étrangères (noms de colonnes explicites)
            builder.Property(s => s.IdJeu)
                   .HasColumnName("id_jeu");

            builder.Property(s => s.IdPlateforme)
                   .HasColumnName("id_plateforme");

            builder.HasOne(s => s.Jeu)
                   .WithMany()
                   .HasForeignKey(s => s.IdJeu);

            builder.HasOne(s => s.Plateforme)
                   .WithMany()
                   .HasForeignKey(s => s.IdPlateforme);
        }
    }
}
