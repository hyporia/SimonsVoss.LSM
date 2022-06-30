using MediatR;

namespace SimonsVoss.LSM.Core.Requests.GetGroups;

public class GetGroupsQuery : IRequest<GetGroupsQueryResponse>
{
    public string Term { get; set; } = null!;
}