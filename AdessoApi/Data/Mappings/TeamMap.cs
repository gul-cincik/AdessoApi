using AdessoApi.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AdessoApi.Data.Mappings
{
    public class TeamMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Team");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Code).HasMaxLength(50).IsRequired();
            builder.Property(t => t.DrawnBy).HasMaxLength(100);

            builder.HasOne(t => t.Country)
                   .WithMany(c => c.Teams)
                   .HasForeignKey(t => t.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Group)
                   .WithMany(g => g.Teams)
                   .HasForeignKey(t => t.GroupId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(t => t.Name).IsUnique();
            builder.HasIndex(t=> t.Code).IsUnique();
        }
    }
}
