using SimonsVoss.LSM.Core.DTO.Lock;

namespace SimonsVoss.LSM.Core.Abstractions;

public interface IWeightsCalculator
{
    public List<WeightedLock> GetWeightedLocks(List<FilteredLock> filteredLocks);
}