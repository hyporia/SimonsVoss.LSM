using AutoMapper;
using MediatR;
using SimonsVoss.LSM.Core.Abstractions;

namespace SimonsVoss.LSM.Core.Requests.GetGroups;

/// <summary>
/// Handler for <see cref="GetGroupsQuery"/>
/// </summary>
public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, GetGroupsQueryResponse>
{
    private readonly IGroupRepository _groupRepository;
    private readonly IWeightsCalculator _weightsCalculator;
    private readonly IMapper _mapper;

    public GetGroupsQueryHandler(IGroupRepository groupRepository, IWeightsCalculator weightsCalculator, IMapper mapper)
    {
        _groupRepository = groupRepository;
        _weightsCalculator = weightsCalculator;
        _mapper = mapper;
    }

    public async Task<GetGroupsQueryResponse> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Term))
        {
            var resultList = await _groupRepository.GetAsync(cancellationToken);
            return new GetGroupsQueryResponse()
                { Data = _mapper.Map<List<GetGroupsQueryResponseItem>>(resultList) };
        }

        var filteredGroups = await _groupRepository.GetAsync(request.Term, cancellationToken);
        var weightedGroups = await _weightsCalculator.GetWeightedGroupsAsync(filteredGroups, cancellationToken);
        var groups = weightedGroups
            .OrderByDescending(x => x.Weight)
            .Select(x => _mapper.Map<GetGroupsQueryResponseItem>(x.Group))
            .ToList();

        return new GetGroupsQueryResponse { Data = groups };
    }
}