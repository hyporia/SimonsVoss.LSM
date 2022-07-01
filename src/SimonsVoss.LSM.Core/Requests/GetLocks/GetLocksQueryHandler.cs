using AutoMapper;
using MediatR;
using SimonsVoss.LSM.Core.Abstractions;

namespace SimonsVoss.LSM.Core.Requests.GetLocks;

/// <summary>
/// Handler for <see cref="GetLocksQuery"/>
/// </summary>
public class GetLocksQueryHandler : IRequestHandler<GetLocksQuery, GetLocksQueryResponse>
{
    private readonly ILockRepository _lockRepository;
    private readonly IWeightsCalculator _weightsCalculator;
    private readonly IMapper _mapper;

    public GetLocksQueryHandler(ILockRepository lockRepository, IWeightsCalculator weightsCalculator, IMapper mapper)
    {
        _lockRepository = lockRepository;
        _weightsCalculator = weightsCalculator;
        _mapper = mapper;
    }

    public async Task<GetLocksQueryResponse> Handle(GetLocksQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Term))
        {
            var resultList = await _lockRepository.GetAsync(cancellationToken);
            return new GetLocksQueryResponse()
                { Data = _mapper.Map<List<GetLocksQueryResponseItem>>(resultList) };
        }

        var filteredLocks = await _lockRepository.GetAsync(request.Term, cancellationToken);
        var weightedLocks = await _weightsCalculator.GetWeightedLocksAsync(filteredLocks, cancellationToken);
        var locks = weightedLocks
            .OrderByDescending(x => x.Weight)
            .Select(x => _mapper.Map<GetLocksQueryResponseItem>(x.Lock))
            .ToList();

        return new GetLocksQueryResponse { Data = locks };
    }
}