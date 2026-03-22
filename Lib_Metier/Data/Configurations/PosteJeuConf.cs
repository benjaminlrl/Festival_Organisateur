using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Metier.Data.Configurations
{
    /// <summary>
    /// Configuration EF Core pour l'entité PosteJeu/>.
    /// Définit le mapping table/colonnes, la clé primaire, les conversions et les relations.
    /// </summary>
    public class PosteJeuConf : IEntityTypeConfiguration<PosteJeu>
    {
        /// <summary>
        /// Configure le modèle EF Core pour PosteJeu.
        /// Appelé par le DbContext lors de la construction du modèle.
        /// </summary>
        /// <param name="builder">Builder EF Core pour configurer l'entité.</param>
        public void Configure(EntityTypeBuilder<PosteJeu> builder)
        {
            // Nom de la table en base
            builder.ToTable("Poste_Jeu");

            // Déclaration de la clé primaire
            builder.HasKey(p => p.NumeroPoste);

            // Mapping explicite des colonnes
            builder.Property(p => p.NumeroPoste)
                   .HasColumnName("numero_poste");

            builder.Property(p => p.Reference)
                   .HasColumnName("reference");

            // Conversion personnalisée pour la propriété booléenne :
            // - En base : "O" (oui) ou "N" (non)
            // - En CLR : true / false
            // Utile si le schéma existant stocke des flags 'O'/'N' au lieu de bit/bool.
            builder.Property(p => p.Fonctionnel)
                   .HasColumnName("fonctionnel")
                   .HasConversion(
                        v => v ? "O" : "N",    // CLR -> DB
                        v => v == "O"          // DB  -> CLR
                    );

            // Clés étrangères (noms de colonnes explicites)
            builder.Property(p => p.IdPlateforme)
                   .HasColumnName("id_plateforme");

            builder.Property(p => p.IdEspace)
                   .HasColumnName("id_espace");

            // Relation vers Plateforme : une plateforme possède plusieurs postes
            builder.HasOne(p => p.Plateforme)
                   .WithMany(pl => pl.PostesJeu)
                   .HasForeignKey(p => p.IdPlateforme);

            // Relation vers Espace : un espace contient plusieurs postes
            builder.HasOne(p => p.Espace)
                   .WithMany(e => e.PostesJeu)
                   .HasForeignKey(p => p.IdEspace);
        }
    }
    }