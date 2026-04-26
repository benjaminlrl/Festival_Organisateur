using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Metier.Data.Configurations
{
    /// <summary>
    /// Configuration Entity Framework Core pour l'entité Tournoi.
    /// Définit le mapping table/colonnes, 
    /// la clé primaire et la relation avec l'Espace associé />.
    /// </summary>
    public class TournoiConf : IEntityTypeConfiguration<Tournoi>
    {
        /// <summary>
        /// Configure les règles de mapping pour l'entité Tournoi.
        /// Utilisé par le DbContext lors de la construction du modèle.
        /// </summary>
        /// <param name="builder">Builder EF Core pour configurer l'entité.</param>
        public void Configure(EntityTypeBuilder<Tournoi> builder)
        {
            // Nom de la table dans la base de données
            builder.ToTable("Tournoi");

            // Déclaration de la clé primaire
            builder.HasKey(t => t.NumeroTournoi);

            // Mapping explicite des propriétés vers les colonnes.
            // Remarque : on précise le nom de colonne pour garder la cohérence
            // avec le schéma de la base ou des conventions existantes.

            builder.Property(t => t.NumeroTournoi)
                   .HasColumnName("numeroTournoi");

            builder.Property(t => t.DateHeure)
                   .HasColumnName("dateHeure");

            builder.Property(t => t.NbParticipants)
                   .HasColumnName("nbParticipants");

            builder.Property(t => t.DureePrevue)
                   .HasColumnName("dureePrevue");

            builder.Property(t => t.Nom)
                   .HasColumnName("nom");

            builder.Property(t => t.Statut)
                   .HasColumnName("statut");

            builder.Property(t => t.IdEspace)
                   .HasColumnName("id_espace");

            builder.Property(t => t.IdJeu)
                   .HasColumnName("id_jeu");


            // Configuration de la relation entre Tournoi et Espace :
            // - Un Tournoi possède une référence vers un Espace (IdEspace)
            // - Un Espace peut contenir plusieurs Tournois (collection Tournois)
            builder.HasOne(t => t.Espace)
                   .WithMany(e => e.Tournois)
                   .HasForeignKey(t => t.IdEspace);

            // Configuration de la relation entre Tournoi et Jeu :
            // - Un Tournoi possède une référence vers un Jeu (IdJeu)
            // - Un Jeu peut contenir plusieurs Tournois (collection Tournois)
            builder.HasOne(t => t.Jeu)
                   .WithMany(j => j.Tournois)
                   .HasForeignKey(t => t.IdJeu);
        }
    }
}