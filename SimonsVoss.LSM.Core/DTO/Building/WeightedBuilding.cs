namespace SimonsVoss.LSM.Core.DTO.Building;

public class WeightedBuilding
{
    public int Weight { get; set; }
    public Entities.Building Building { get; init; } = null!;
}