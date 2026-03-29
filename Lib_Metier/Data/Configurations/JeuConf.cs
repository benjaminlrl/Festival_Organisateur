using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Metier.Data.Configurations
{
    public class JeuConf
    {
        /// <summary>
        /// Configure le mapping EF Core pour l'entité Plateforme>.
        /// Appelé par le DbContext lors de la construction du modèle.
        /// </summary>
        /// <param name="builder">Builder utilisé pour configurer l'entité.</param>
        public void Configure(EntityTypeBuilder<Jeu> builder)
        {
            // Nom explicite de la table en base de données
            builder.ToTable("Jeu");

            // Définition de la clé primaire
            builder.HasKey(j => j.IdJeu);

            // Mapping explicite des colonnes : utile pour conserver la compatibilité
            // avec un schéma existant ou des conventions de nommage particulières.
            builder.Property(j => j.IdJeu)
                   .HasColumnName("id_jeu");

            builder.Property(j => j.Titre)
                   .HasColumnName("titre");

            builder.Property(j => j.Editeur)
                   .HasColumnName("editeur");

            builder.Property(j => j.AnneeSortie)
                   .HasColumnName("anneeSortie");

            builder.Property(j => j.Description)
                   .HasColumnName("description");

            builder.Property(j => j.Pegi)
                   .HasColumnName("pegi");

            builder.Property(j => j.DateSortie)
                   .HasColumnName("dateSortie");
        }
    }
}
