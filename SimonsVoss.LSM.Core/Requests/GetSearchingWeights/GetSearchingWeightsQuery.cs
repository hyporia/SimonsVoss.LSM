using MediatR;

namespace SimonsVoss.LSM.Core.Requests.GetSearchingWeights;

public class GetSearchingWeightsQuery : IRequest<GetSearchingWeightsQueryResponse>
{
    public string? EntityName { get; set; }

    public string? PropertyName { get; set; }

    public string? TransitiveEntityName { get; set; }

    public int? Weight { get; set; }

    public int? FullMatchMultiplier { get; set; }
}