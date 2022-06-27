using SimonsVoss.LSM.Core.Entities;
using SimonsVoss.LSM.Core.Requests.GetLocks;

namespace SimonsVoss.LSM.Core.Abstractions;

public interface ILockRepository
{
    Task<GetLocksQueryResponse> GetAsync(GetLocksQuery query, CancellationToken cancellationToken);
}