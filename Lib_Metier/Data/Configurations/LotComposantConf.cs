using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Metier.Data.Configurations
{
    /// <summary>
    /// Configuration Entity Framework Core pour l'entité LotComposant.
    /// Définit le mapping table/colonnes, la clé primaire et le mapping des propriétés.
    /// Utilisé par le DbContext lors de la construction du modèle.
    /// </summary>
    public class LotComposantConf : IEntityTypeConfiguration<LotComposant>
    {
        public void Configure(EntityTypeBuilder<LotComposant> builder)
        {
            // Nom de la table en base de données
            builder.ToTable("LotComposant");

            // Définition de la clé primaire
            builder.HasKey(e => e.Numero);

            // Mapping explicite des colonnes : utile pour conserver la compatibilité
            // avec un schéma existant ou des conventions de nommage particulières.
            builder.Property(e => e.Libelle)
                   .HasColumnName("libelle");

            builder.Property(e => e.Description)
                   .HasColumnName("description");

            builder.Property(e => e.Valeur)
                   .HasColumnName("valeur");

            builder.Property(e => e.NumeroLot)
                   .HasColumnName("numero_lot");

            // Configuration de la relation entre LotComposant et Lot
            builder.HasOne(t => t.Lot)
                   .WithMany(e => e.LotComposant)
                   .HasForeignKey(t => t.NumeroLot); 
        }
    }
}
