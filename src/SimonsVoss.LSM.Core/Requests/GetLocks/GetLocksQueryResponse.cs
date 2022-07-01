namespace SimonsVoss.LSM.Core.Requests.GetLocks;

/// <summary>
/// Response for <see cref="GetLocksQuery"/>
/// </summary>
public class GetLocksQueryResponse
{
    /// <summary>
    /// List of locks
    /// </summary>
    public List<GetLocksQueryResponseItem> Data { get; init; } = null!;
}