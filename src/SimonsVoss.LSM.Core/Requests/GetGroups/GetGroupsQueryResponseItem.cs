using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.Core.Requests.GetGroups;

/// <summary>
/// <see cref="Group"/> model for <see cref="GetGroupsQueryResponse"/>
/// </summary>
public class GetGroupsQueryResponseItem
{
    public Guid Id { get; set; }

    public string? Description { get; set; }

    public string? Name { get; set; }
}