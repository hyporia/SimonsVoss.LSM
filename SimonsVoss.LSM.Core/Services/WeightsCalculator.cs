using SimonsVoss.LSM.Core.Abstractions;
using SimonsVoss.LSM.Core.DTO.Lock;

namespace SimonsVoss.LSM.Core.Services;

public class WeightsCalculator : IWeightsCalculator
{
    public List<WeightedLock> GetWeightedLocks(List<FilteredLock> filteredLocks)
    {
        var weightedLocks = filteredLocks
            .Select(x => new WeightedLock
            {
                //TODO: move "magic numbers" to the weights table
                Weight = (x.DoesNameMatches ? 100 : x.DoesNameContains ? 10 : 0) +
                         (x.DoesDescriptionMatches ? 60 : x.DoesDescriptionContains ? 6 : 0) +
                         (x.DoesTypeContains ? 30 : x.DoesTypeMatches ? 3 : 0) +
                         (x.DoesSerialNumberMatches ? 80 : x.DoesSerialNumberContains ? 8 : 0) +
                         (x.DoesFloorMatches ? 60 : x.DoesFloorContains ? 6 : 0) +
                         (x.DoesRoomNumberMatches ? 60 : x.DoesRoomNumberContains ? 6 : 0) +
                         (x.DoesBuildingNameMatches ? 80 : x.DoesBuildingNameContains ? 8 : 0) +
                         (x.DoesBuildingShortCutMatches ? 50 : x.DoesBuildingShortCutContains ? 5 : 0),
                Lock = x.Lock
            })
            .OrderBy(x => x.Weight)
            .ToList();

        return weightedLocks;
    }
}