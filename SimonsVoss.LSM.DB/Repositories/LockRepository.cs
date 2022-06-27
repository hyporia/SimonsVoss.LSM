using Microsoft.EntityFrameworkCore;
using SimonsVoss.LSM.Core.Abstractions;
using SimonsVoss.LSM.Core.Entities;
using SimonsVoss.LSM.Core.Requests.GetLocks;

namespace SimonsVoss.LSM.DB.Repositories;

public class LockRepository : ILockRepository
{
    private readonly EfContext _context;

    public LockRepository(EfContext context)
    {
        _context = context;
    }

    public async Task<GetLocksQueryResponse> GetAsync(GetLocksQuery query, CancellationToken cancellationToken)
    {
        var locks = await _context.Locks
            .AsNoTracking()
            .Select(x=> new
            {
                DoesContain = EF.Functions.ILike(x.Name, $"%{query.Term}%"),
                DoesFullyMatch = EF.Functions.ILike(x.Name, query.Term),
                DoesDescriptionContain = !string.IsNullOrEmpty(x.Description) && EF.Functions.ILike(x.Description, $"%{query.Term}%"),
                Lock = x
            })
            .Where(x=>x.DoesContain)
            .Select(x=>new
            {
                Lock = x.Lock,
                Weight = (x.DoesFullyMatch ? 100 : x.DoesContain ? 10 : 0) + (x.DoesDescriptionContain ? 6 : 0)
            })
            .OrderBy(x=>x.Weight)
            .Select(x=>x.Lock)
            .ToListAsync(cancellationToken);

        return new GetLocksQueryResponse
        {
            Data = locks.Select(x => new GetLocksQueryResponseItem()).ToList()
        };
    }
}