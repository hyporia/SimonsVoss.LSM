namespace SimonsVoss.LSM.Core.Requests.GetBuildings;

/// <summary>
/// Response for <see cref="GetBuildingsQuery"/>
/// </summary>
public class GetBuildingsQueryResponse
{
    /// <summary>
    /// List of buildings
    /// </summary>
    public List<GetBuildingsQueryResponseItem> Data { get; init; } = null!;
}