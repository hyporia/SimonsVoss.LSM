using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimonsVoss.LSM.Core.Entities.Dictionaries;

namespace SimonsVoss.LSM.DB.Configurations.Dictionaries;

public class LockTypeConfiguration : BaseDictionaryEntityConfiguration<LockType>
{
    public override void Configure(EntityTypeBuilder<LockType> builder)
    {
        builder.ToTable("lock_type");
        base.Configure(builder);
    }
}