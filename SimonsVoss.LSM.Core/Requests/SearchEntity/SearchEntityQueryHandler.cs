using MediatR;

namespace SimonsVoss.LSM.Core.Requests.SearchEntity;

public class SearchEntityQueryHandler : IRequestHandler<SearchEntityQuery, SearchEntityQueryResponse>
{
    public Task<SearchEntityQueryResponse> Handle(SearchEntityQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}