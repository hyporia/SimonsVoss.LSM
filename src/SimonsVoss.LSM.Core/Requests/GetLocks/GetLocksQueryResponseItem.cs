using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.Core.Requests.GetLocks;

/// <summary>
/// <see cref="Lock"/> model for <see cref="GetLocksQueryResponse"/>
/// </summary>
public class GetLocksQueryResponseItem
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