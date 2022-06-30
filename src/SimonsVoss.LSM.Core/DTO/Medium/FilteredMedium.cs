namespace SimonsVoss.LSM.Core.DTO.Medium;

public class FilteredMedium
{
    public bool DoesDescriptionContains { get; init; }
    public bool DoesDescriptionMatches { get; init; }
    public bool DoesTypeContains { get; init; }
    public bool DoesTypeMatches { get; init; }
    public bool DoesSerialNumberContains { get; init; }
    public bool DoesSerialNumberMatches { get; init; }
    public bool DoesOwnerContains { get; init; }
    public bool DoesOwnerMatches { get; init; }
    public bool DoesGroupNameContains { get; init; }
    public bool DoesGroupNameMatches { get; init; }
    public Entities.Medium Medium { get; init; } = null!;
}