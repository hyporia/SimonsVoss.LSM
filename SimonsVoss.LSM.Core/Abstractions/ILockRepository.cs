using SimonsVoss.LSM.Core.DTO.Lock;
using SimonsVoss.LSM.Core.Requests.GetLocks;

namespace SimonsVoss.LSM.Core.Abstractions;

public interface ILockRepository
{
    Task<List<FilteredLock>> GetAsync(string term, CancellationToken cancellationToken);
}