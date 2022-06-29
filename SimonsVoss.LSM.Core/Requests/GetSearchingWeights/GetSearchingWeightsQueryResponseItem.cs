namespace SimonsVoss.LSM.Core.Requests.GetSearchingWeights;

public class GetSearchingWeightsQueryResponseItem
{
    public Guid Id { get; set; }

    public string? Description { get; set; }
    
    public Guid BuildingId { get; set; }

    public string Type { get; set; } = null!;

    public string? Name { get; set; }

    public string? SerialNumber { get; set; }

    public string? Floor { get; set; }

    public string? RoomNumber { get; set; }
}