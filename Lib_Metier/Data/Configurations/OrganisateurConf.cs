using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Metier.Data.Configurations
{
    /// <summary>
    /// Configuration Entity Framework Core pour l'entité Organisateur.
    /// Définit le mapping table/colonnes, la clé primaire et le mapping des propriétés.
    /// Utilisé par le DbContext lors de la construction du modèle.
    /// </summary>
    public class OrganisateurConf : IEntityTypeConfiguration<Organisateur>
    {
        public void Configure(EntityTypeBuilder<Organisateur> builder)
        {
            // Nom de la table en base de données
            builder.ToTable("Organisateur");

            // Définition de la clé primaire
            builder.HasKey(e => e.Login);

            // Mapping explicite des colonnes : utile pour conserver la compatibilité
            // avec un schéma existant ou des conventions de nommage particulières.
            builder.Property(e => e.Login)
                   .HasColumnName("login");

            builder.Property(e => e.Mail)
                   .HasColumnName("mail");

            builder.Property(e => e.motPasse)
                   .HasColumnName("motPasse");

            builder.Property(e => e.IdRole)
                   .HasColumnName("id_role");

            // Clés étrangères (noms de colonnes explicites)
            builder.Property(p => p.IdRole)
                   .HasColumnName("id_role");

            // Configuration de la relation entre Organisateur et Rôle
            builder.HasOne(t => t.Role)
                   .WithMany(e => e.Organisateurs)
                   .HasForeignKey(t => t.IdRole);
        }
    }
}
