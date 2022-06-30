using System.Text.Json.Serialization;
using SimonsVoss.LSM.Core.Entities.Dictionaries;

namespace SimonsVoss.LSM.Core.Entities;

public class Lock : BaseEntity
{
    public Guid BuildingId { get; set; }

    [JsonPropertyName("type")]
    public int LockTypeId { get; set; }

    public string? Name { get; set; }

    public string? SerialNumber { get; set; }

    public string? Floor { get; set; }

    public string? RoomNumber { get; set; }
    

    #region navigation properties
    
    public Building? Building { get; set; }
    
    public LockType? LockType { get; set; }

    #endregion
}