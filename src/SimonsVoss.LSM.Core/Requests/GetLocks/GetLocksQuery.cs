using MediatR;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.Core.Requests.GetLocks;

/// <summary>
/// Query for getting <see cref="Lock"/>
/// </summary>
public class GetLocksQuery : IRequest<GetLocksQueryResponse>
{
    /// <summary>
    /// Searching term
    /// </summary>
    public string? Term { get; set; }
}