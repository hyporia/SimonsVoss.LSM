using Microsoft.EntityFrameworkCore;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.DB;

public class AppContext : DbContext
{
    private const string DefaultSchema = "public";
    
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public AppContext(DbContextOptions<AppContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(DefaultSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
    }

    public DbSet<Building> Buildings { get; set; }
    public DbSet<Lock> Locks { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Medium> Media { get; set; }
}