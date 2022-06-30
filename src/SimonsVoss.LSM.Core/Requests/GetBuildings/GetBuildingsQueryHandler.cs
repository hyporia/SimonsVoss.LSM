using AutoMapper;
using MediatR;
using SimonsVoss.LSM.Core.Abstractions;

namespace SimonsVoss.LSM.Core.Requests.GetBuildings;

public class GetBuildingsQueryHandler : IRequestHandler<GetBuildingsQuery, GetBuildingsQueryResponse>
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IWeightsCalculator _weightsCalculator;
    private readonly IMapper _mapper;

    public GetBuildingsQueryHandler(IBuildingRepository buildingRepository, IWeightsCalculator weightsCalculator, IMapper mapper)
    {
        _buildingRepository = buildingRepository;
        _weightsCalculator = weightsCalculator;
        _mapper = mapper;
    }

    public async Task<GetBuildingsQueryResponse> Handle(GetBuildingsQuery request, CancellationToken cancellationToken)
    {
        var filteredBuildings = await _buildingRepository.GetAsync(request.Term, cancellationToken);
        var weightedBuildings = await _weightsCalculator.GetWeightedBuildingsAsync(filteredBuildings, cancellationToken);
        var buildings = weightedBuildings
            .OrderByDescending(x => x.Weight)
            .Select(x => _mapper.Map<GetBuildingsQueryResponseItem>(x.Building))
            .ToList();

        return new GetBuildingsQueryResponse { Data = buildings };
    }
}