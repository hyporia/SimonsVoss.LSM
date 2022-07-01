using SimonsVoss.LSM.Core.DTO.Building;
using SimonsVoss.LSM.Core.DTO.Group;
using SimonsVoss.LSM.Core.DTO.Lock;
using SimonsVoss.LSM.Core.DTO.Medium;

namespace SimonsVoss.LSM.Core.Abstractions;

/// <summary>
/// Repository for calculating weights based on search results
/// </summary>
public interface IWeightsCalculator
{
    /// <summary>
    /// Get weighted search results for filtered locks
    /// </summary>
    /// <param name="filteredLocks">Filtered locks</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of weighted locks</returns>
    public Task<List<WeightedLock>> GetWeightedLocksAsync(List<FilteredLock> filteredLocks,
        CancellationToken cancellationToken);

    /// <summary>
    /// Get weighted search results for filtered buildings
    /// </summary>
    /// <param name="filteredBuildings">Filtered buildings</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of weighted buildings</returns>
    public Task<List<WeightedBuilding>> GetWeightedBuildingsAsync(List<FilteredBuilding> filteredBuildings,
        CancellationToken cancellationToken);

    /// <summary>
    /// Get weighted search results for filtered groups
    /// </summary>
    /// <param name="filteredGroups">Filtered groups</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of weighted groups</returns>
    public Task<List<WeightedGroup>> GetWeightedGroupsAsync(List<FilteredGroup> filteredGroups,
        CancellationToken cancellationToken);

    /// <summary>
    /// Get weighted search results for filtered media
    /// </summary>
    /// <param name="filteredMedia">Filtered media</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of weighted media</returns>
    public Task<List<WeightedMedium>> GetWeightedMediaAsync(List<FilteredMedium> filteredMedia,
        CancellationToken cancellationToken);
}