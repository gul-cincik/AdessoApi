using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AdessoApi.Entities;

namespace AdessoApi.Data.Mappings
{
    public class GroupMap : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group");

            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).HasMaxLength(10).IsRequired();

            builder.HasMany(g => g.Teams)
                   .WithOne(t => t.Group)
                   .HasForeignKey(t => t.GroupId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(g => g.Name).IsUnique();
        }
    }
}
