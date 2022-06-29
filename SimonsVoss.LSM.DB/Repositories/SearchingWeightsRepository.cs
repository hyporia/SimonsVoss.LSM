using Microsoft.EntityFrameworkCore;
using SimonsVoss.LSM.Core.Abstractions;
using SimonsVoss.LSM.Core.Entities;
using SimonsVoss.LSM.Core.Requests.GetSearchingWeights;

namespace SimonsVoss.LSM.DB.Repositories;

public class SearchingWeightsRepository : ISearchingWeightsRepository
{
    private readonly EfContext _context;

    public SearchingWeightsRepository(EfContext context)
    {
        _context = context;
    }

    public async Task<List<SearchingWeight>> GetAsync(GetSearchingWeightsQuery request, CancellationToken cancellationToken) =>
        await _context.SearchingWeights
            .AsNoTracking()
            .Where(x => string.IsNullOrEmpty(request.EntityName) ||
                        x.EntityName.ToLower().Contains(request.EntityName.ToLower()))
            .Where(x => string.IsNullOrEmpty(request.PropertyName) ||
                        x.PropertyName.ToLower().Contains(request.PropertyName.ToLower()))
            .Where(x => string.IsNullOrEmpty(request.TransitiveEntityName) ||
                        (!string.IsNullOrEmpty(x.TransitiveEntityName) &&
                         x.TransitiveEntityName.ToLower().Contains(request.TransitiveEntityName.ToLower())))
            .Where(x => !request.Weight.HasValue || x.Weight == request.Weight)
            .Where(x => !request.FullMatchMultiplier.HasValue || x.FullMatchMultiplier == request.FullMatchMultiplier)
            .ToListAsync(cancellationToken);
    
}