using System.Globalization;
using Microsoft.EntityFrameworkCore;
using SimonsVoss.LSM.Core.Abstractions;
using SimonsVoss.LSM.Core.DTO.Lock;
using SimonsVoss.LSM.Core.Entities;
using SimonsVoss.LSM.Core.Extensions;

namespace SimonsVoss.LSM.DB.Repositories;

/// <inheritdoc/>
public class LockRepository : ILockRepository
{
    private readonly EfContext _context;

    public LockRepository(EfContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<List<FilteredLock>> GetAsync(string term, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(term)) throw new ArgumentNullException(nameof(term));

        term = term.ToLower(CultureInfo.InvariantCulture);
        var patternTerm = $"%{term}%";

        var lockTypes = await _context.LockTypes
            .AsNoTracking()
            .Where(x => EF.Functions.ILike(x.Value, patternTerm))
            .ToListAsync(cancellationToken);

        var typeIdsOfPartialMatch = lockTypes.Select(x => x.Id).ToList();
        var typeIdsOfFullMatch = lockTypes
            .Where(x => x.Value.Equals(term, StringComparison.InvariantCultureIgnoreCase))
            .Select(x => x.Id)
            .ToList();

        var filteredLocks = await _context.Locks
            .AsNoTracking()
            .Include(x => x.LockType)
            .Include(x => x.Building)
            .Select(x => new
            {
                DoesNameContains = !string.IsNullOrEmpty(x.Name) && EF.Functions.Like(x.Name.ToLower(), patternTerm),
                DoesNameMatches = !string.IsNullOrEmpty(x.Name) && EF.Functions.Like(x.Name.ToLower(), term),
                DoesDescriptionContains = !string.IsNullOrEmpty(x.Description) &&
                                          EF.Functions.Like(x.Description.ToLower(), patternTerm),
                DoesDescriptionMatches = !string.IsNullOrEmpty(x.Description) &&
                                         EF.Functions.Like(x.Description.ToLower(), term),
                DoesTypeContains = typeIdsOfPartialMatch.Contains(x.LockTypeId),
                DoesTypeMatches = typeIdsOfFullMatch.Contains(x.LockTypeId),
                DoesSerialNumberContains = !string.IsNullOrEmpty(x.SerialNumber) &&
                                           EF.Functions.Like(x.SerialNumber.ToLower(), patternTerm),
                DoesSerialNumberMatches = !string.IsNullOrEmpty(x.SerialNumber) &&
                                          EF.Functions.Like(x.SerialNumber.ToLower(), term),
                DoesFloorContains = !string.IsNullOrEmpty(x.Floor) && EF.Functions.Like(x.Floor.ToLower(), patternTerm),
                DoesFloorMatches = !string.IsNullOrEmpty(x.Floor) && EF.Functions.Like(x.Floor.ToLower(), term),
                DoesRoomNumberContains = !string.IsNullOrEmpty(x.RoomNumber) &&
                                         EF.Functions.Like(x.RoomNumber.ToLower(), patternTerm),
                DoesRoomNumberMatches = !string.IsNullOrEmpty(x.RoomNumber) &&
                                        EF.Functions.Like(x.RoomNumber.ToLower(), term),
                DoesBuildingNameContains = !string.IsNullOrEmpty(x.Building!.Name) &&
                                           EF.Functions.Like(x.Building.Name.ToLower(), patternTerm),
                DoesBuildingNameMatches = !string.IsNullOrEmpty(x.Building!.Name) &&
                                          EF.Functions.Like(x.Building.Name.ToLower(), term),
                DoesBuildingShortCutContains = !string.IsNullOrEmpty(x.Building.ShortCut) &&
                                               EF.Functions.Like(x.Building.ShortCut.ToLower(), patternTerm),
                DoesBuildingShortCutMatches = !string.IsNullOrEmpty(x.Building.ShortCut) &&
                                              EF.Functions.Like(x.Building.ShortCut.ToLower(), term),
                Lock = x
            })
            .Where(x => x.DoesDescriptionContains || x.DoesNameContains || x.DoesTypeContains
                        || x.DoesSerialNumberContains || x.DoesFloorContains || x.DoesRoomNumberContains ||
                        x.DoesBuildingNameContains || x.DoesBuildingShortCutContains)
            .ToListAsync(cancellationToken);

        return filteredLocks
            .Select(x => x.ToType<FilteredLock>())
            .ToList();
    }
    
    /// <inheritdoc/>
    public async Task<List<Lock>> GetAsync(CancellationToken cancellationToken) =>
        await _context.Locks
            .AsNoTracking()
            .ToListAsync(cancellationToken);
}