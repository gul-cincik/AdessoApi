using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AdessoApi.Data.Mappings
{
    public abstract class BaseEntityMap<T> : IEntityTypeConfiguration<T> where T : class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property("IsDeleted").HasDefaultValue(false);
            builder.Property("CreatedAt").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property("UpdatedAt").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property("CreatedBy").HasMaxLength(100).IsRequired(true);
            builder.Property("UpdatedBy").HasMaxLength(100).IsRequired(true);
        }
    }
}
