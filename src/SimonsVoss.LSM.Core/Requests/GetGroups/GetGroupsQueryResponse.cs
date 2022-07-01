namespace SimonsVoss.LSM.Core.Requests.GetGroups;

/// <summary>
/// Response for <see cref="GetGroupsQuery"/>
/// </summary>
public class GetGroupsQueryResponse
{
    /// <summary>
    /// List of groups
    /// </summary>
    public List<GetGroupsQueryResponseItem> Data { get; init; } = null!;
}