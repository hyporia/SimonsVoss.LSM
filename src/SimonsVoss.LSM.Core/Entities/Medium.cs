using System.Text.Json.Serialization;
using SimonsVoss.LSM.Core.Entities.Dictionaries;

namespace SimonsVoss.LSM.Core.Entities;

public class Medium : BaseEntity
{
    public Guid GroupId { get; set; }

    [JsonPropertyName("type")]
    public int MediumTypeId { get; set; }

    public string? Owner { get; set; }

    public string? SerialNumber { get; set; }


    #region navigation properties

    public Group? Group { get; set; }
    
    public MediumType? MediumType { get; set; }

    #endregion
}