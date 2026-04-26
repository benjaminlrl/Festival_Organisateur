using Lib_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lib_Metier.Data.Configurations
{
    internal class JoueurConf : IEntityTypeConfiguration<Joueur>
    {
        public void Configure(EntityTypeBuilder<Joueur> builder)
        {
            builder.ToTable("Joueur");

            // Clé primaire sans autoincrement pour imposer nos propres IDs
            builder.HasKey(j => j.IdUser);
            builder.Property(j => j.IdUser)
                   .ValueGeneratedNever();

            // Relation Joueur → Participer
            builder.HasMany(j => j.Participations)
                   .WithOne()
                   .HasForeignKey(p => p.IdUser)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relation Joueur → Voter
            builder.HasMany(j => j.Votes)
                   .WithOne()
                   .HasForeignKey(v => v.IdUser)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}