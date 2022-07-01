using SimonsVoss.LSM.Core.DTO.Building;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.Core.Abstractions;

/// <summary>
/// Repository for <see cref="Building"/> entity
/// </summary>
public interface IBuildingRepository
{
    /// <summary>
    /// Get buildings filtered by term
    /// </summary>
    /// <param name="term">term</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>List of buildings filtered by search term</returns>
    Task<List<FilteredBuilding>> GetAsync(string term, CancellationToken cancellationToken);

    /// <summary>
    /// Get all buildings
    /// </summary>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>List all of buildings</returns>
    Task<List<Building>> GetAsync(CancellationToken cancellationToken);
}