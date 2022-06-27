using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimonsVoss.LSM.Core.Entities.Dictionaries;

namespace SimonsVoss.LSM.DB.Configurations.Dictionaries;

public abstract class BaseDictionaryEntityConfiguration<TDictionaryEntity> : IEntityTypeConfiguration<TDictionaryEntity>
    where TDictionaryEntity : BaseDictionaryEntity
{
    public virtual void Configure(EntityTypeBuilder<TDictionaryEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Value)
            .IsRequired();
    }
}