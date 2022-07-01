using SimonsVoss.LSM.Core.DTO.Lock;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.Core.Abstractions;

/// <summary>
/// Repository for <see cref="Lock"/> entity
/// </summary>
public interface ILockRepository
{
    /// <summary>
    /// Get locks filtered by term
    /// </summary>
    /// <param name="term"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<FilteredLock>> GetAsync(string term, CancellationToken cancellationToken);

    /// <summary>
    /// Get all locks
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of all locks</returns>
    Task<List<Lock>> GetAsync(CancellationToken cancellationToken);
}