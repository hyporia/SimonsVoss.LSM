using AutoMapper;
using MediatR;
using SimonsVoss.LSM.Core.Abstractions;

namespace SimonsVoss.LSM.Core.Requests.GetMedia;

/// <summary>
/// Handler for <see cref="GetMediaQuery"/>
/// </summary>
public class GetMediaQueryHandler : IRequestHandler<GetMediaQuery, GetMediaQueryResponse>
{
    private readonly IMediumRepository _mediumRepository;
    private readonly IWeightsCalculator _weightsCalculator;
    private readonly IMapper _mapper;

    public GetMediaQueryHandler(IMediumRepository mediumRepository, IWeightsCalculator weightsCalculator,
        IMapper mapper)
    {
        _mediumRepository = mediumRepository;
        _weightsCalculator = weightsCalculator;
        _mapper = mapper;
    }

    public async Task<GetMediaQueryResponse> Handle(GetMediaQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Term))
        {
            var resultList = await _mediumRepository.GetAsync(cancellationToken);
            return new GetMediaQueryResponse()
                { Data = _mapper.Map<List<GetMediaQueryResponseItem>>(resultList) };
        }

        var filteredMedia = await _mediumRepository.GetAsync(request.Term, cancellationToken);
        var weightedLocks = await _weightsCalculator.GetWeightedMediaAsync(filteredMedia, cancellationToken);
        var media = weightedLocks
            .OrderByDescending(x => x.Weight)
            .Select(x => _mapper.Map<GetMediaQueryResponseItem>(x.Medium))
            .ToList();

        return new GetMediaQueryResponse { Data = media };
    }
}