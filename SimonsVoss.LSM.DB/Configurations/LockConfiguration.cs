using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.DB.Configurations;

public class LockConfiguration : BaseEntityConfiguration<Lock>
{
    public override void Configure(EntityTypeBuilder<Lock> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Floor);
        
        builder.Property(x => x.Name);
        
        builder.Property(x => x.Type);
        
        builder.Property(x => x.RoomNumber);
        
        builder.Property(x => x.SerialNumber);

        builder.HasOne(x => x.Building)
            .WithMany(x => x.Locks)
            .HasPrincipalKey(x => x.Id)
            .HasForeignKey(x => x.BuildingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}