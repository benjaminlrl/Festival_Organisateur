using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Metier.Data.Configurations
{
    /// <summary>
    /// Configuration Entity Framework Core pour l'entité Lot.
    /// Définit le mapping table/colonnes, la clé primaire et le mapping des propriétés.
    /// Utilisé par le DbContext lors de la construction du modèle.
    /// </summary>
    public class LotConf : IEntityTypeConfiguration<Lot>
    {
        public void Configure(EntityTypeBuilder<Lot> builder)
        {
            // Nom de la table en base de données
            builder.ToTable("Lot");

            // Définition de la clé primaire
            builder.HasKey(e => e.Numero);

            // Mapping explicite des colonnes : utile pour conserver la compatibilité
            // avec un schéma existant ou des conventions de nommage particulières.
            builder.Property(e => e.Libelle)
                   .HasColumnName("libelle");

            builder.Property(e => e.ValeurTotale)
                   .HasColumnName("valeurTotale");

            builder.Property(e => e.RangAttribution)
                   .HasColumnName("rangAttribution");

            builder.Property(e => e.EstAttribue)
                   .HasColumnName("estAttribue");

            builder.Property(e => e.NumeroTournoi)
                   .HasColumnName("numeroTournoi");

            // Configuration de la relation entre Lot et Tournoi
            builder.HasOne(t => t.Tournoi)
                   .WithMany(e => e.Lot)
                   .HasForeignKey(t => t.NumeroTournoi);
        }
    }
}
