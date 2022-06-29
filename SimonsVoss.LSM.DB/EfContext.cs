using System.Reflection;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
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
    public DbSet<LockType> LockTypes { get; set; }
    public DbSet<MediumType> MediumTypes { get; set; }
    public DbSet<SearchingWeight> SearchingWeights { get; set; }

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
            out var media,
            out var searchingWeights
        );

        modelBuilder.Entity<MediumType>().HasData(mediumTypes);
        modelBuilder.Entity<LockType>().HasData(lockTypes);
        modelBuilder.Entity<Building>().HasData(buildings);
        modelBuilder.Entity<Lock>().HasData(locks);
        modelBuilder.Entity<Group>().HasData(groups);
        modelBuilder.Entity<Medium>().HasData(media);
        modelBuilder.Entity<SearchingWeight>().HasData(searchingWeights);
    }

    private static void GetDataToSeed(
        out List<LockType> lockTypes,
        out List<MediumType> mediumTypes,
        out List<Building> buildings,
        out List<Lock> locks,
        out List<Group> groups,
        out List<Medium> media,
        out List<SearchingWeight> searchingWeights)
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

        var i = 1;
        searchingWeights = new List<SearchingWeight>
        {
            new SearchingWeight(i++, nameof(Lock), nameof(Lock.Name), 10),
            new SearchingWeight(i++, nameof(Lock), nameof(Lock.LockType), 3),
            new SearchingWeight(i++, nameof(Lock), nameof(Lock.SerialNumber), 8),
            new SearchingWeight(i++, nameof(Lock), nameof(Lock.Floor), 6),
            new SearchingWeight(i++, nameof(Lock), nameof(Lock.RoomNumber), 6),
            new SearchingWeight(i++, nameof(Lock), nameof(Lock.Description), 6),
            new SearchingWeight(i++, nameof(Lock), nameof(Building.Name), 8, nameof(Building)),
            new SearchingWeight(i++, nameof(Lock), nameof(Building.ShortCut), 5, nameof(Building)),
            new SearchingWeight(i++, nameof(Medium), nameof(Medium.MediumType), 3),
            new SearchingWeight(i++, nameof(Medium), nameof(Medium.Owner), 10),
            new SearchingWeight(i++, nameof(Medium), nameof(Medium.SerialNumber), 8),
            new SearchingWeight(i++, nameof(Medium), nameof(Medium.Description), 6),
            new SearchingWeight(i++, nameof(Medium), nameof(Group.Name), 8, nameof(Group)),
            new SearchingWeight(i++, nameof(Building), nameof(Building.Name), 9),
            new SearchingWeight(i++, nameof(Building), nameof(Building.ShortCut), 7),
            new SearchingWeight(i++, nameof(Building), nameof(Building.Description), 5),
            new SearchingWeight(i++, nameof(Group), nameof(Group.Name), 9),
            new SearchingWeight(i++, nameof(Group), nameof(Group.Description), 5),
        };
    }
}