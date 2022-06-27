using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.DB.Configurations;

public class MediumConfiguration : BaseEntityConfiguration<Medium>
{
    public override void Configure(EntityTypeBuilder<Medium> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Owner);
        
        builder.Property(x => x.SerialNumber);

        builder.HasOne(x => x.Group)
            .WithMany(x => x.Media)
            .HasPrincipalKey(x => x.Id)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.MediumType)
            .WithMany(x => x.Media)
            .HasPrincipalKey(x => x.Id)
            .HasForeignKey(x => x.MediumTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}