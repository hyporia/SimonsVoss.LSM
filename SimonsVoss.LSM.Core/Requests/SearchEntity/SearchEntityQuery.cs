using MediatR;

namespace SimonsVoss.LSM.Core.Requests.SearchEntity;

public class SearchEntityQuery : IRequest<SearchEntityQueryResponse>
{
    public string Term { get; set; } = null!;
}