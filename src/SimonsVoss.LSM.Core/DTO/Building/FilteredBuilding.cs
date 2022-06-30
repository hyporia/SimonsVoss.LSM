namespace SimonsVoss.LSM.Core.DTO.Building;

public class FilteredBuilding
{
    public bool DoesNameContains { get; init; }
    public bool DoesNameMatches { get; init; }
    public bool DoesDescriptionContains { get; init; }
    public bool DoesDescriptionMatches { get; init; }
    public bool DoesShortCutContains { get; init; }
    public bool DoesShortCutMatches { get; init; }
    public Entities.Building Building { get; init; } = null!;
}