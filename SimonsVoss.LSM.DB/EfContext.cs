using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimonsVoss.LSM.Core;
using SimonsVoss.LSM.Core.Entities;
using SimonsVoss.LSM.Core.Entities.Dictionaries;

namespace SimonsVoss.LSM.DB;

public class EfContext : DbContext
{
    private const string DefaultSchema = "public";

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public EfContext(DbContextOptions<EfContext> options) : base(options)
    {
    }

    public DbSet<Building> Buildings { get; set; }
    public DbSet<Lock> Locks { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Medium> Media { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(DefaultSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfContext).Assembly);

        GetDataToSeed(
            out var lockTypes,
            out var mediumTypes,
            out var buildings,
            out var locks,
            out var groups,
            out var media
        );
        
        modelBuilder.Entity<MediumType>().HasData(mediumTypes);
        modelBuilder.Entity<LockType>().HasData(lockTypes);
        modelBuilder.Entity<Building>().HasData(buildings);
        modelBuilder.Entity<Lock>().HasData(locks);
        modelBuilder.Entity<Group>().HasData(groups);
        modelBuilder.Entity<Medium>().HasData(media);
    }

    private static void GetDataToSeed(
        out List<LockType> lockTypes,
        out List<MediumType> mediumTypes,
        out List<Building> buildings,
        out List<Lock> locks,
        out List<Group> groups,
        out List<Medium> media)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var manifestStream = assembly.GetManifestResourceStream("SimonsVoss.LSM.DB.sv_lsm_data.json")!;
        using var streamReader = new StreamReader(manifestStream);
        var json = streamReader.ReadToEnd();
        var jsonDoc = JsonDocument.Parse(json);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        lockTypes = jsonDoc.RootElement.GetProperty("lockTypes").Deserialize<List<LockType>>(options)!;
        mediumTypes = jsonDoc.RootElement.GetProperty("mediumTypes").Deserialize<List<MediumType>>(options)!;
        buildings = jsonDoc.RootElement.GetProperty("buildings").Deserialize<List<Building>>(options)!;
        locks = jsonDoc.RootElement.GetProperty("locks").Deserialize<List<Lock>>(options)!;
        groups = jsonDoc.RootElement.GetProperty("groups").Deserialize<List<Group>>(options)!;
        media = jsonDoc.RootElement.GetProperty("media").Deserialize<List<Medium>>(options)!;
    }
}