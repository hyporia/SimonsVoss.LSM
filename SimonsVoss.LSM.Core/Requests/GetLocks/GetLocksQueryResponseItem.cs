namespace SimonsVoss.LSM.Core.Requests.GetLocks;

public class GetLocksQueryResponseItem
{
    public Guid BuildingId { get; set; }

    public string Type { get; set; } = null!;

    public string? Name { get; set; }

    public string? SerialNumber { get; set; }

    public string? Floor { get; set; }

    public string? RoomNumber { get; set; }
}