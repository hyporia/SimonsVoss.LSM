namespace SimonsVoss.LSM.Core.DTO.Medium;

public class WeightedMedium
{
    public int Weight { get; set; }
    public Entities.Medium Medium { get; init; } = null!;
}