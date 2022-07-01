using SimonsVoss.LSM.Core.DTO.Medium;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.Core.Abstractions;

/// <summary>
/// Repository for <see cref="Medium"/> entity
/// </summary>
public interface IMediumRepository
{
    /// <summary>
    /// Get media filtered by term
    /// </summary>
    /// <param name="term"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<FilteredMedium>> GetAsync(string term, CancellationToken cancellationToken);

    /// <summary>
    /// Get all media
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of all media</returns>
    Task<List<Medium>> GetAsync(CancellationToken cancellationToken);
}