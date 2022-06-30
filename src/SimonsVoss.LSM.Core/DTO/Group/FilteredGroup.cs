namespace SimonsVoss.LSM.Core.DTO.Group;

public class FilteredGroup
{
    public bool DoesNameContains { get; init; }
    public bool DoesNameMatches { get; init; }
    public bool DoesDescriptionContains { get; init; }
    public bool DoesDescriptionMatches { get; init; }
    public Entities.Group Group { get; init; } = null!;
}