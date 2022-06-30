using SimonsVoss.LSM.Core.Entities;
using SimonsVoss.LSM.Core.Requests.GetBuildings;
using SimonsVoss.LSM.Core.Services;
using SimonsVoss.LSM.DB.Repositories;

namespace SimonsVoss.LSM.UnitTest.Requests.GetBuildings;

public class GetBuildingsQueryHandlerTest : UnitTestBase
{
    public GetBuildingsQueryHandlerTest() : base()
    {
    }

    [Fact]
    public async Task GetBuildings_ShouldReturn_BuildingsByFilter()
    {
        var buildingToFind = new Building
        {
            Id = Guid.NewGuid(),
            Name = "foo",
            Description = "awsome building"
        };
        var buildingToFind2 = new Building
        {
            Id = Guid.NewGuid(),
            Name = "bar",
            Description = "foo"
        };
        var buildingToMiss = new Building
        {
            Id = Guid.NewGuid(),
            Name = "bar2",
            Description = "awsome building 2"
        };

        var searchingWeights = new List<SearchingWeight>
        {
            new SearchingWeight(1, nameof(Building), nameof(Building.Name), 9),
            new SearchingWeight(2, nameof(Building), nameof(Building.ShortCut), 7),
            new SearchingWeight(3, nameof(Building), nameof(Building.Description), 5),
        };

        await using var context =
            CreateInMemoryContext(dbSeeder: x =>
            {
                x.AddRange(buildingToFind, buildingToFind2, buildingToMiss);
                x.AddRange(searchingWeights);
            });

        // TODO: this repositories/services should be tested separately
        var buildingRepository = new BuildingRepository(context);
        var searchingWeightRepository = new SearchingWeightsRepository(context);
        var weightsCalculator = new WeightsCalculator(searchingWeightRepository);
        var handler = new GetBuildingsQueryHandler(buildingRepository, weightsCalculator, Mapper);
        var result = handler.Handle(new GetBuildingsQuery { Term = "Foo" }, default).GetAwaiter().GetResult();
        Assert.NotNull(result?.Data);
        Assert.Equal(2, result!.Data.Count);
        Assert.True(result.Data[0].Id == buildingToFind.Id &&
                    result.Data[0].Description == buildingToFind.Description &&
                    result.Data[0].Name == buildingToFind.Name);
        Assert.True(result.Data[1].Id == buildingToFind2.Id &&
                    result.Data[1].Description == buildingToFind2.Description &&
                    result.Data[1].Name == buildingToFind2.Name);
        Assert.False(result.Data.Exists(x =>
            x.Id == buildingToMiss.Id || x.Description == buildingToMiss.Description ||
            x.Name == buildingToMiss.Name));
    }
}