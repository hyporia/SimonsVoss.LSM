using SimonsVoss.LSM.Core.Entities;
using SimonsVoss.LSM.Core.Requests.GetSearchingWeights;

namespace SimonsVoss.LSM.Core.Abstractions;

/// <summary>
/// Repository for <see cref="SearchingWeight"/> entity
/// </summary>
public interface ISearchingWeightsRepository
{
    /// <summary>
    /// Get searching weights filtered by query parameters
    /// </summary>
    /// <param name="request">query</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of searching weights filtered by query parameters</returns>
    public Task<List<SearchingWeight>> GetAsync(GetSearchingWeightsQuery request, CancellationToken cancellationToken);
}