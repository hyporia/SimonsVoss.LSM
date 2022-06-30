using SimonsVoss.LSM.Core.Abstractions;
using SimonsVoss.LSM.Core.DTO.Building;
using SimonsVoss.LSM.Core.DTO.Group;
using SimonsVoss.LSM.Core.DTO.Lock;
using SimonsVoss.LSM.Core.DTO.Medium;
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
        var buildingShortCutWeight = weights.FirstOrDefault(x =>
            x.PropertyName == nameof(Building.ShortCut) && x.TransitiveEntityName == nameof(Building));

        var weightedLocks = filteredLocks
            .Select(x => new WeightedLock
            {
                Weight = CalculateSinglePropertyWeight(x.DoesNameMatches, x.DoesNameContains, nameWeight) +
                         CalculateSinglePropertyWeight(x.DoesDescriptionMatches, x.DoesDescriptionContains,
                             descriptionWeight) +
                         CalculateSinglePropertyWeight(x.DoesTypeMatches, x.DoesTypeContains, typeWeight) +
                         CalculateSinglePropertyWeight(x.DoesSerialNumberMatches, x.DoesSerialNumberContains,
                             serialNumberWeight) +
                         CalculateSinglePropertyWeight(x.DoesFloorMatches, x.DoesFloorContains, floorWeight) +
                         CalculateSinglePropertyWeight(x.DoesRoomNumberMatches, x.DoesRoomNumberContains,
                             roomNumberWeight) +
                         CalculateSinglePropertyWeight(x.DoesBuildingNameMatches, x.DoesBuildingNameContains,
                             buildingNameWeight) +
                         CalculateSinglePropertyWeight(x.DoesBuildingShortCutMatches, x.DoesBuildingShortCutContains,
                             buildingShortCutWeight),
                Lock = x.Lock
            })
            .ToList();

        return weightedLocks;
    }

    public async Task<List<WeightedBuilding>> GetWeightedBuildingsAsync(List<FilteredBuilding> filteredBuildings,
        CancellationToken cancellationToken)
    {
        var weights = await _searchingWeightsRepository.GetAsync(new GetSearchingWeightsQuery
        {
            EntityName = nameof(Building)
        }, cancellationToken);

        var nameWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Building.Name));
        var descriptionWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Building.Description));
        var shortCutWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Building.ShortCut));

        var weightedBuildings = filteredBuildings
            .Select(x => new WeightedBuilding
            {
                Weight = CalculateSinglePropertyWeight(x.DoesNameMatches, x.DoesNameContains, nameWeight) +
                         CalculateSinglePropertyWeight(x.DoesDescriptionMatches, x.DoesDescriptionContains,
                             descriptionWeight) +
                         CalculateSinglePropertyWeight(x.DoesShortCutMatches, x.DoesShortCutContains, shortCutWeight),
                Building = x.Building
            })
            .ToList();

        return weightedBuildings;
    }

    public async Task<List<WeightedGroup>> GetWeightedGroupsAsync(List<FilteredGroup> filteredGroups,
        CancellationToken cancellationToken)
    {
        var weights = await _searchingWeightsRepository.GetAsync(new GetSearchingWeightsQuery
        {
            EntityName = nameof(Group)
        }, cancellationToken);

        var nameWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Group.Name));
        var descriptionWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Group.Description));

        var weightedGroups = filteredGroups
            .Select(x => new WeightedGroup
            {
                Weight = CalculateSinglePropertyWeight(x.DoesNameMatches, x.DoesNameContains, nameWeight) +
                         CalculateSinglePropertyWeight(x.DoesDescriptionMatches, x.DoesDescriptionContains,
                             descriptionWeight),
                Group = x.Group
            })
            .ToList();

        return weightedGroups;
    }

    public async Task<List<WeightedMedium>> GetWeightedMediaAsync(List<FilteredMedium> filteredMedia,
        CancellationToken cancellationToken)
    {
        var weights = await _searchingWeightsRepository.GetAsync(new GetSearchingWeightsQuery
        {
            EntityName = nameof(Medium)
        }, cancellationToken);

        var descriptionWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Medium.Description));
        var typeWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Medium.MediumType));
        var serialNumberWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Medium.SerialNumber));
        var ownerWeight = weights.FirstOrDefault(x => x.PropertyName == nameof(Medium.Owner));
        var groupNameWeight = weights.FirstOrDefault(x =>
            x.PropertyName == nameof(Group.Name) && x.TransitiveEntityName == nameof(Group));

        var weightedLocks = filteredMedia
            .Select(x => new WeightedMedium
            {
                Weight = CalculateSinglePropertyWeight(x.DoesDescriptionMatches, x.DoesDescriptionContains,
                             descriptionWeight) +
                         CalculateSinglePropertyWeight(x.DoesTypeMatches, x.DoesTypeContains, typeWeight) +
                         CalculateSinglePropertyWeight(x.DoesSerialNumberMatches, x.DoesSerialNumberContains,
                             serialNumberWeight) +
                         CalculateSinglePropertyWeight(x.DoesOwnerMatches, x.DoesOwnerContains, ownerWeight) +
                         CalculateSinglePropertyWeight(x.DoesGroupNameMatches, x.DoesGroupNameContains,
                             groupNameWeight),
                Medium = x.Medium
            })
            .ToList();

        return weightedLocks;
    }

    private int CalculateSinglePropertyWeight(bool doesPropertyFullyMatch, bool doesPropertyContains,
        SearchingWeight searchingWeight)
    {
        if (searchingWeight == null) throw new ArgumentNullException(nameof(searchingWeight));

        return doesPropertyFullyMatch
            ? searchingWeight.Weight * searchingWeight.FullMatchMultiplier
            : doesPropertyContains
                ? searchingWeight.Weight
                : 0;
    }
}