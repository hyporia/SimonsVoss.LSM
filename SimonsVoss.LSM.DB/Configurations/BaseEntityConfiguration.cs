using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.DB.Configurations;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{
    private const string NewGuidSql = "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)";

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .IsRequired()
            .HasDefaultValueSql(NewGuidSql);

        builder.Property(x => x.Description);
    }
}