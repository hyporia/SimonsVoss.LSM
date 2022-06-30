using MediatR;

namespace SimonsVoss.LSM.Core.Requests.GetBuildings;

public class GetBuildingsQuery : IRequest<GetBuildingsQueryResponse>
{
    public string Term { get; set; } = null!;
}