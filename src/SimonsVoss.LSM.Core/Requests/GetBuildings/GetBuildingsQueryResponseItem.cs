using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.Core.Requests.GetBuildings;

/// <summary>
/// <see cref="Building"/> model for <see cref="GetBuildingsQueryResponse"/>
/// </summary>
public class GetBuildingsQueryResponseItem
{
    public Guid Id { get; set; }

    public string? Description { get; set; }
    
    public string? ShortCut { get; set; }

    public string? Name { get; set; }
}