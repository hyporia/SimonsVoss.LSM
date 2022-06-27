using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimonsVoss.LSM.Core.Entities.Dictionaries;

namespace SimonsVoss.LSM.DB.Configurations.Dictionaries;

public class MediumTypeConfiguration : BaseDictionaryEntityConfiguration<MediumType>
{
    public override void Configure(EntityTypeBuilder<MediumType> builder) =>
        base.Configure(builder);
}