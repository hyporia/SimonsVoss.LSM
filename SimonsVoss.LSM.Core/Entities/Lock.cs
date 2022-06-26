using SimonsVoss.LSM.Core.Enums;

namespace SimonsVoss.LSM.Core.Entities;

public class Lock : BaseEntity
{
    public Guid BuildingId { get; set; }

    public LockType Type { get; set; }

    public string? Name { get; set; }

    public string? SerialNumber { get; set; }

    public string? Floor { get; set; }

    public string? RoomNumber { get; set; }
    

    #region navigation properties
    
    public Building? Building { get; set; }

    #endregion
}