using SimonsVoss.LSM.Core.DTO.Group;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.Core.Abstractions;

/// <summary>
/// Repository for <see cref="Group"/> entity
/// </summary>
public interface IGroupRepository
{
    /// <summary>
    /// Get groups filtered by term
    /// </summary>
    /// <param name="term"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<FilteredGroup>> GetAsync(string term, CancellationToken cancellationToken);

    /// <summary>
    /// Get all groups
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of all groups</returns>
    Task<List<Group>> GetAsync(CancellationToken cancellationToken);
}