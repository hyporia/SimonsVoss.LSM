using System.Globalization;
using Microsoft.EntityFrameworkCore;
using SimonsVoss.LSM.Core.Abstractions;
using SimonsVoss.LSM.Core.DTO.Group;
using SimonsVoss.LSM.Core.Entities;
using SimonsVoss.LSM.Core.Extensions;

namespace SimonsVoss.LSM.DB.Repositories;

/// <inheritdoc/>
public class GroupRepository : IGroupRepository
{
    private readonly EfContext _context;

    public GroupRepository(EfContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<List<FilteredGroup>> GetAsync(string term, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(term)) throw new ArgumentNullException(nameof(term));

        term = term.ToLower(CultureInfo.InvariantCulture);
        var patternTerm = $"%{term}%";

        var filteredGroups = await _context.Groups
            .AsNoTracking()
            .Select(x => new
            {
                DoesNameContains = !string.IsNullOrEmpty(x.Name) && EF.Functions.Like(x.Name.ToLower(CultureInfo.InvariantCulture), patternTerm),
                DoesNameMatches = !string.IsNullOrEmpty(x.Name) && EF.Functions.Like(x.Name.ToLower(CultureInfo.InvariantCulture), term),
                DoesDescriptionContains = !string.IsNullOrEmpty(x.Description) &&
                                          EF.Functions.Like(x.Description.ToLower(CultureInfo.InvariantCulture), patternTerm),
                DoesDescriptionMatches = !string.IsNullOrEmpty(x.Description) &&
                                         EF.Functions.Like(x.Description.ToLower(CultureInfo.InvariantCulture), term),
                Group = x
            })
            .Where(x => x.DoesDescriptionContains || x.DoesNameContains)
            .ToListAsync(cancellationToken);

        return filteredGroups
            .Select(x => x.ToType<FilteredGroup>())
            .ToList();
    }

    /// <inheritdoc/>
    public async Task<List<Group>> GetAsync(CancellationToken cancellationToken) =>
        await _context.Groups
            .AsNoTracking()
            .ToListAsync(cancellationToken);
}