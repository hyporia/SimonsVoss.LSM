using AutoMapper;
using MediatR;
using SimonsVoss.LSM.Core.Abstractions;

namespace SimonsVoss.LSM.Core.Requests.GetSearchingWeights;

public class
    GetSearchingWeightsQueryHandler : IRequestHandler<GetSearchingWeightsQuery, GetSearchingWeightsQueryResponse>
{
    private readonly ISearchingWeightsRepository _searchingWeightsRepository;
    private readonly IMapper _mapper;

    public GetSearchingWeightsQueryHandler(ISearchingWeightsRepository searchingWeightsRepository, IMapper mapper)
    {
        _searchingWeightsRepository = searchingWeightsRepository;
        _mapper = mapper;
    }

    public async Task<GetSearchingWeightsQueryResponse> Handle(GetSearchingWeightsQuery request,
        CancellationToken cancellationToken)
    {
        var searchingWeights = await _searchingWeightsRepository.GetAsync(request, cancellationToken);

        return new GetSearchingWeightsQueryResponse
        {
            Data = _mapper.Map<List<GetSearchingWeightsQueryResponseItem>>(searchingWeights)
        };
    }
}