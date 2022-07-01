using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.Core.Requests.GetMedia;

/// <summary>
/// <see cref="Medium"/> model for <see cref="GetMediaQueryResponse"/>
/// </summary>
public class GetMediaQueryResponseItem
{
    public Guid Id { get; set; }

    public string? Description { get; set; }
    
    public Guid GroupId { get; set; }

    public string Type { get; set; } = null!;

    public string? Owner { get; set; }

    public string? SerialNumber { get; set; }
}