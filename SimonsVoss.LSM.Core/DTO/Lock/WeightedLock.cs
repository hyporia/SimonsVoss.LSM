namespace SimonsVoss.LSM.Core.DTO.Lock;

public class WeightedLock
{
    public int Weight { get; set; }
    public Entities.Lock Lock { get; init; }
}