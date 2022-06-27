using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.DB.Configurations;

public class BuildingConfiguration : BaseEntityConfiguration<Building>
{
    public override void Configure(EntityTypeBuilder<Building> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name);
        
        builder.Property(x => x.ShortCut);
    }
}