using MediatR;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.Core.Requests.GetBuildings;

/// <summary>
/// Query for getting <see cref="Building"/>
/// </summary>
public class GetBuildingsQuery : IRequest<GetBuildingsQueryResponse>
{
    /// <summary>
    /// Searching term
    /// </summary>
    public string? Term { get; set; }
}