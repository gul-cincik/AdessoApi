using AdessoApi.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AdessoApi.Data.Mappings
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();

            builder.HasMany(c => c.Teams)
                   .WithOne(t => t.Country)
                   .HasForeignKey(t => t.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(c => c.Name).IsUnique();
            builder.HasIndex(c => c.Code).IsUnique();
        }
    }
}
