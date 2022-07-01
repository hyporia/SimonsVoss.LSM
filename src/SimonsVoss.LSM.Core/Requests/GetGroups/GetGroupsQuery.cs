using MediatR;
using SimonsVoss.LSM.Core.Entities;

namespace SimonsVoss.LSM.Core.Requests.GetGroups;

/// <summary>
/// Query for getting <see cref="Group"/>
/// </summary>
public class GetGroupsQuery : IRequest<GetGroupsQueryResponse>
{
    /// <summary>
    /// Searching term
    /// </summary>
    public string? Term { get; set; }
}