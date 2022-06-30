using MediatR;

namespace SimonsVoss.LSM.Core.Requests.GetMedia;

public class GetMediaQuery : IRequest<GetMediaQueryResponse>
{
    public string Term { get; set; } = null!;
}