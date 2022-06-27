using SimonsVoss.LSM.Core.Enums;

namespace SimonsVoss.LSM.Core.Entities;

public class Medium : BaseEntity
{
    public Guid GroupId { get; set; }

    public MediumType Type { get; set; }

    public string? Owner { get; set; }

    public string? SerialNumber { get; set; }


    #region navigation properties

    public Group? Group { get; set; }

    #endregion
}