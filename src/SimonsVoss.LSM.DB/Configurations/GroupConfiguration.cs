using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.DB.Configurations;

public class GroupConfiguration : BaseEntityConfiguration<Group>
{
    public override void Configure(EntityTypeBuilder<Group> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name);
    }
}