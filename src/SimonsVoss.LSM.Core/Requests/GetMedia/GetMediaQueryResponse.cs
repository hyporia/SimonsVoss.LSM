namespace SimonsVoss.LSM.Core.Requests.GetMedia;

/// <summary>
/// Response for <see cref="GetMediaQuery"/>
/// </summary>
public class GetMediaQueryResponse
{
    /// <summary>
    /// List of media
    /// </summary>
    public List<GetMediaQueryResponseItem> Data { get; init; } = null!;
}