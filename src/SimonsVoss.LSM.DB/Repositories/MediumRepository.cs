using Microsoft.EntityFrameworkCore;
using SimonsVoss.LSM.Core.Abstractions;
using SimonsVoss.LSM.Core.DTO.Medium;
using SimonsVoss.LSM.Core.Entities;
using SimonsVoss.LSM.Core.Extensions;

namespace SimonsVoss.LSM.DB.Repositories;

/// <inheritdoc/>
public class MediumRepository : IMediumRepository
{
    private readonly EfContext _context;

    public MediumRepository(EfContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<List<FilteredMedium>> GetAsync(string term, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(term)) throw new ArgumentNullException(nameof(term));

        term = term.ToLower();
        var patternTerm = $"%{term}%";

        var mediumTypes = await _context.MediumTypes
            .AsNoTracking()
            .Where(x => EF.Functions.ILike(x.Value, patternTerm))
            .ToListAsync(cancellationToken);

        var typeIdsOfPartialMatch = mediumTypes.Select(x => x.Id).ToList();
        var typeIdsOfFullMatch = mediumTypes
            .Where(x => x.Value.Equals(term, StringComparison.InvariantCultureIgnoreCase))
            .Select(x => x.Id)
            .ToList();

        var filteredMedia = await _context.Media
            .AsNoTracking()
            .Include(x => x.MediumType)
            .Include(x => x.Group)
            .Select(x => new
            {
                DoesDescriptionContains = !string.IsNullOrEmpty(x.Description) &&
                                          EF.Functions.Like(x.Description.ToLower(), patternTerm),
                DoesDescriptionMatches = !string.IsNullOrEmpty(x.Description) &&
                                         EF.Functions.Like(x.Description.ToLower(), term),
                DoesTypeContains = typeIdsOfPartialMatch.Contains(x.MediumTypeId),
                DoesTypeMatches = typeIdsOfFullMatch.Contains(x.MediumTypeId),
                DoesSerialNumberContains = !string.IsNullOrEmpty(x.SerialNumber) &&
                                           EF.Functions.Like(x.SerialNumber.ToLower(), patternTerm),
                DoesSerialNumberMatches = !string.IsNullOrEmpty(x.SerialNumber) &&
                                          EF.Functions.Like(x.SerialNumber.ToLower(), term),
                DoesOwnerContains = !string.IsNullOrEmpty(x.Owner) && EF.Functions.Like(x.Owner.ToLower(), patternTerm),
                DoesOwnerMatches = !string.IsNullOrEmpty(x.Owner) && EF.Functions.Like(x.Owner.ToLower(), term),
                DoesGroupNameContains = !string.IsNullOrEmpty(x.Group.Name) &&
                                        EF.Functions.Like(x.Group.Name.ToLower(), patternTerm),
                DoesGroupNameMatches = !string.IsNullOrEmpty(x.Group.Name) &&
                                       EF.Functions.Like(x.Group.Name.ToLower(), term),
                Medium = x
            })
            .Where(x => x.DoesDescriptionContains || x.DoesTypeContains
                                                  || x.DoesSerialNumberContains || x.DoesOwnerContains ||
                                                  x.DoesGroupNameContains)
            .ToListAsync(cancellationToken);

        return filteredMedia
            .Select(x => x.ToType<FilteredMedium>())
            .ToList();
    }

    /// <inheritdoc/>
    public async Task<List<Medium>> GetAsync(CancellationToken cancellationToken) =>
        await _context.Media
            .AsNoTracking()
            .ToListAsync(cancellationToken);
}