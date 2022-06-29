using SimonsVoss.LSM.Core.Entities;
using SimonsVoss.LSM.Core.Requests.GetSearchingWeights;

namespace SimonsVoss.LSM.Core.Abstractions;

public interface ISearchingWeightsRepository
{
    public Task<List<SearchingWeight>> GetAsync(GetSearchingWeightsQuery request, CancellationToken cancellationToken);
}