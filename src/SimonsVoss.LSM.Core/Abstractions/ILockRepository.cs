using SimonsVoss.LSM.Core.DTO.Lock;

namespace SimonsVoss.LSM.Core.Abstractions;

public interface ILockRepository
{
    Task<List<FilteredLock>> GetAsync(string term, CancellationToken cancellationToken);
}