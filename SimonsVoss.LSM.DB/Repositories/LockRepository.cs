using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimonsVoss.LSM.Core.Abstractions;
using SimonsVoss.LSM.Core.Requests.GetLocks;

namespace SimonsVoss.LSM.DB.Repositories;

public class LockRepository : ILockRepository
{
    private readonly EfContext _context;
    private readonly IMapper _mapper;

    public LockRepository(EfContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetLocksQueryResponse> GetAsync(GetLocksQuery query, CancellationToken cancellationToken)
    {
        var term = query.Term.ToLower();
        var patternTerm = $"%{term}%";
        var lockTypes = await _context.LockTypes
            .AsNoTracking()
            .Where(x => EF.Functions.ILike(x.Value, patternTerm))
            .ToListAsync(cancellationToken);

        var idsOfPartialMatch = lockTypes.Select(x => x.Id).ToList();
        var idsOfFullMatch = lockTypes
            .Where(x => x.Value.Equals(query.Term, StringComparison.InvariantCultureIgnoreCase))
            .Select(x => x.Id)
            .ToList();

        var filteredLocks = await _context.Locks
            .AsNoTracking()
            .Include(x => x.LockType)
            .Select(x => new
            {
                DoesNameContains = !string.IsNullOrEmpty(x.Name) && EF.Functions.Like(x.Name.ToLower(), patternTerm),
                DoesDescriptionContains = !string.IsNullOrEmpty(x.Description) &&
                                          EF.Functions.Like(x.Description.ToLower(), patternTerm),
                DoesTypeContains = idsOfPartialMatch.Contains(x.LockTypeId),
                DoesSerialNumberContains = !string.IsNullOrEmpty(x.SerialNumber) &&
                                           EF.Functions.Like(x.SerialNumber.ToLower(), patternTerm),
                DoesFloorContains = !string.IsNullOrEmpty(x.Floor) && EF.Functions.Like(x.Floor.ToLower(), patternTerm),
                DoesRoomNumberContains = !string.IsNullOrEmpty(x.RoomNumber) &&
                                         EF.Functions.Like(x.RoomNumber.ToLower(), patternTerm),
                DoesBuildingNameContains = !string.IsNullOrEmpty(x.Building!.Name) &&
                                           EF.Functions.Like(x.Building.Name.ToLower(), patternTerm),
                DoesBuildingShortCutContains = !string.IsNullOrEmpty(x.Building.ShortCut) &&
                                               EF.Functions.Like(x.Building.ShortCut.ToLower(), patternTerm),
                Lock = x
            })
            .Where(x => x.DoesDescriptionContains || x.DoesNameContains || x.DoesTypeContains
                        || x.DoesSerialNumberContains || x.DoesFloorContains || x.DoesRoomNumberContains)
            .ToListAsync(cancellationToken);

        var orderedLocks = filteredLocks
            .Select(x => new
            {
                DoesNameContains = x.DoesNameContains,
                DoesNameMatches = x.DoesNameContains && x.Lock!.Name!.ToLower() == term,
                DoesDescriptionContains = x.DoesDescriptionContains,
                DoesDescriptionMatches = x.DoesDescriptionContains && x.Lock!.Description!.ToLower() == term,
                DoesTypeContains = x.DoesTypeContains,
                DoesTypeMatches = x.DoesTypeContains && idsOfFullMatch.Contains(x.Lock.LockTypeId),
                DoesSerialNumberContains = x.DoesSerialNumberContains,
                DoesSerialNumberMatches = x.DoesSerialNumberContains && x.Lock!.SerialNumber!.ToLower() == term,
                DoesFloorContains = x.DoesFloorContains,
                DoesFloorMatches = x.DoesFloorContains && x.Lock!.Floor!.ToLower() == term,
                DoesRoomNumberContains = x.DoesRoomNumberContains,
                DoesRoomNumberMatches = x.DoesRoomNumberContains && x.Lock!.RoomNumber!.ToLower() == term,
                Lock = x.Lock,
            })
            .Select(x => new
            {
                //TODO: move "magic numbers" to the weights table
                Weight = (x.DoesNameMatches ? 100 : x.DoesNameContains ? 10 : 0) +
                         (x.DoesDescriptionMatches ? 60 : x.DoesDescriptionContains ? 6 : 0) +
                         (x.DoesTypeContains ? 30 : x.DoesTypeMatches ? 3 : 0) +
                         (x.DoesSerialNumberMatches ? 80 : x.DoesSerialNumberContains ? 8 : 0) +
                         (x.DoesFloorMatches ? 60 : x.DoesFloorContains ? 6 : 0) +
                         (x.DoesRoomNumberMatches ? 60 : x.DoesRoomNumberContains ? 6 : 0),
                Lock = x.Lock
            })
            .OrderBy(x => x.Weight)
            .Select(x => x.Lock)
            .ToList();

        return new GetLocksQueryResponse
        {
            Data = _mapper.Map<List<GetLocksQueryResponseItem>>(orderedLocks)
        };
    }
}