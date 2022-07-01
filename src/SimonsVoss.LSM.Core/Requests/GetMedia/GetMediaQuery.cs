using MediatR;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.Core.Requests.GetMedia;

/// <summary>
/// Query for getting <see cref="Medium"/>
/// </summary>
public class GetMediaQuery : IRequest<GetMediaQueryResponse>
{
    /// <summary>
    /// Searching term
    /// </summary>
    public string? Term { get; set; }
}