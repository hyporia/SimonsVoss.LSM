using SimonsVoss.LSM.Core.Abstractions;
using SimonsVoss.LSM.Core.DTO.Lock;
using SimonsVoss.LSM.Core.Entities;
using SimonsVoss.LSM.Core.Requests.GetSearchingWeights;

namespace SimonsVoss.LSM.Core.Services;

public class WeightsCalculator : IWeightsCalculator
{
    private readonly ISearchingWeightsRepository _searchingWeightsRepository;
    

    public WeightsCalculator(ISearchingWeightsRepository searchingWeightsRepository)
    {
        _searchingWeightsRepository = searchingWeightsRepository;
    }

    public async Task<List<WeightedLock>> GetWeightedLocksAsync(List<FilteredLock> filteredLocks,
        CancellationToken cancellationToken)
    {
        var weights = await _searchingWeightsRepository.GetAsync(new GetSearchingWeightsQuery
        {
            EntityName = nameof(Lock)
        }, cancellationToken);

        var nameWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Lock.Name));
        var descriptionWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Lock.Description));
        var typeWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Lock.LockType));
        var serialNumberWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Lock.SerialNumber));
        var floorWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Lock.Floor));
        var roomNumberWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Lock.RoomNumber));
        var buildingNameWeight = weights.FirstOrDefault(x =>
            x.PropertyName == nameof(Building.Name) && x.TransitiveEntityName == nameof(Building));
        var buildingNShortCutWeight = weights.FirstOrDefault(x =>
            x.PropertyName == nameof(Building.ShortCut) && x.TransitiveEntityName == nameof(Building));

        var weightedLocks = filteredLocks
            .Select(x => new WeightedLock
            {
                Weight = CalculateSinglePropertyWeight(x.DoesNameMatches, x.DoesNameContains, nameWeight) +
                         CalculateSinglePropertyWeight(x.DoesDescriptionMatches, x.DoesDescriptionContains, descriptionWeight) +
                         CalculateSinglePropertyWeight(x.DoesTypeMatches, x.DoesTypeContains, typeWeight) +
                         CalculateSinglePropertyWeight(x.DoesSerialNumberMatches, x.DoesSerialNumberContains, serialNumberWeight) +
                         CalculateSinglePropertyWeight(x.DoesFloorMatches, x.DoesFloorContains, floorWeight) +
                         CalculateSinglePropertyWeight(x.DoesRoomNumberMatches, x.DoesRoomNumberContains, roomNumberWeight) +
                         CalculateSinglePropertyWeight(x.DoesBuildingNameMatches, x.DoesBuildingNameContains, buildingNameWeight) +
                         CalculateSinglePropertyWeight(x.DoesBuildingShortCutMatches, x.DoesBuildingShortCutContains, buildingNShortCutWeight),
                Lock = x.Lock
            })
            .ToList();

        return weightedLocks;
    }

    private int CalculateSinglePropertyWeight(bool doesPropertyFullyMatch, bool doesPropertyContains, SearchingWeight searchingWeight)
    {
        if (searchingWeight == null) throw new ArgumentNullException(nameof(searchingWeight));

        return doesPropertyFullyMatch
            ? searchingWeight.Weight * searchingWeight.FullMatchMultiplier
            : doesPropertyContains
                ? searchingWeight.Weight
                : 0;
    }
}