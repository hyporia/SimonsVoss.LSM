using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.DB.Configurations;

public class SearchingWeightConfiguration : IEntityTypeConfiguration<SearchingWeight>
{
    public void Configure(EntityTypeBuilder<SearchingWeight> builder)
    {
        builder.ToTable("searching_weight");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.EntityName).IsRequired();
        
        builder.Property(x => x.PropertyName).IsRequired();
        
        builder.Property(x => x.TransitiveEntityName);
        
        builder.Property(x => x.Weight);
        
        builder.Property(x => x.FullMatchMultiplier).HasDefaultValue(10);
    }
}