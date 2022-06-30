namespace SimonsVoss.LSM.Core.DTO.Group;

public class WeightedGroup
{
    public int Weight { get; set; }
    public Entities.Group Group { get; init; } = null!;
}