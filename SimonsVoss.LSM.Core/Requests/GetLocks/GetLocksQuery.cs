using MediatR;

namespace SimonsVoss.LSM.Core.Requests.GetLocks;

public class GetLocksQuery : IRequest<GetLocksQueryResponse>
{
    public string Term { get; set; } = null!;
}