using SimonsVoss.LSM.Core.DTO.Lock;

namespace SimonsVoss.LSM.Core.Abstractions;

public interface IWeightsCalculator
{
    public Task<List<WeightedLock>> GetWeightedLocksAsync(List<FilteredLock> filteredLocks,
        CancellationToken cancellationToken);
}