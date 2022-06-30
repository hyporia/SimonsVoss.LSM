using SimonsVoss.LSM.Core.DTO.Building;
using SimonsVoss.LSM.Core.DTO.Group;
using SimonsVoss.LSM.Core.DTO.Lock;
using SimonsVoss.LSM.Core.DTO.Medium;

namespace SimonsVoss.LSM.Core.Abstractions;

public interface IWeightsCalculator
{
    public Task<List<WeightedLock>> GetWeightedLocksAsync(List<FilteredLock> filteredLocks,
        CancellationToken cancellationToken);

    public Task<List<WeightedBuilding>> GetWeightedBuildingsAsync(List<FilteredBuilding> filteredBuildings,
        CancellationToken cancellationToken);

    public Task<List<WeightedGroup>> GetWeightedGroupsAsync(List<FilteredGroup> filteredGroups,
        CancellationToken cancellationToken);

    public Task<List<WeightedMedium>> GetWeightedMediaAsync(List<FilteredMedium> filteredMedia,
        CancellationToken cancellationToken);
}