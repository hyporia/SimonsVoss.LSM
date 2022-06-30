namespace SimonsVoss.LSM.Core.DTO.Lock;

public class FilteredLock
{
    public bool DoesNameContains { get; init; }
    public bool DoesNameMatches { get; init; }
    public bool DoesDescriptionContains { get; init; }
    public bool DoesDescriptionMatches { get; init; }
    public bool DoesTypeContains { get; init; }
    public bool DoesTypeMatches { get; init; }
    public bool DoesSerialNumberContains { get; init; }
    public bool DoesSerialNumberMatches { get; init; }
    public bool DoesFloorContains { get; init; }
    public bool DoesFloorMatches { get; init; }
    public bool DoesRoomNumberContains { get; init; }
    public bool DoesRoomNumberMatches { get; init; }
    public bool DoesBuildingNameContains { get; init; }
    public bool DoesBuildingNameMatches { get; init; }
    public bool DoesBuildingShortCutContains { get; init; }
    public bool DoesBuildingShortCutMatches { get; init; }
    public Entities.Lock Lock { get; init; }
}