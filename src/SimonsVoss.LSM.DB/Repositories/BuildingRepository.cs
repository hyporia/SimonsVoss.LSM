using System.Globalization;
using Microsoft.EntityFrameworkCore;
using SimonsVoss.LSM.Core.Abstractions;
using SimonsVoss.LSM.Core.DTO.Building;
using SimonsVoss.LSM.Core.Entities;
using SimonsVoss.LSM.Core.Extensions;

namespace SimonsVoss.LSM.DB.Repositories;

/// <inheritdoc/>
public class BuildingRepository : IBuildingRepository
{
    private readonly EfContext _context;

    public BuildingRepository(EfContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<List<FilteredBuilding>> GetAsync(string term, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(term)) throw new ArgumentNullException(nameof(term));

        term = term.ToLower(CultureInfo.InvariantCulture);
        var patternTerm = $"%{term}%";

        var filteredBuildings = await _context.Buildings
            .AsNoTracking()
            .Select(x => new
            {
                DoesNameContains = !string.IsNullOrEmpty(x.Name) && EF.Functions.Like(x.Name.ToLower(), patternTerm),
                DoesNameMatches = !string.IsNullOrEmpty(x.Name) && EF.Functions.Like(x.Name.ToLower(), term),
                DoesDescriptionContains = !string.IsNullOrEmpty(x.Description) &&
                                          EF.Functions.Like(x.Description.ToLower(), patternTerm),
                DoesDescriptionMatches = !string.IsNullOrEmpty(x.Description) &&
                                         EF.Functions.Like(x.Description.ToLower(), term),
                DoesShortCutContains = !string.IsNullOrEmpty(x.ShortCut) &&
                                       EF.Functions.Like(x.ShortCut.ToLower(), patternTerm),
                DoesShortCutMatches = !string.IsNullOrEmpty(x.ShortCut) &&
                                      EF.Functions.Like(x.ShortCut.ToLower(), term),
                Building = x
            })
            .Where(x => x.DoesDescriptionContains
                        || x.DoesNameContains || x.DoesShortCutContains
            )
            .ToListAsync(cancellationToken);

        return filteredBuildings
            .Select(x => x.ToType<FilteredBuilding>())
            .ToList();
    }

    /// <inheritdoc/>
    public async Task<List<Building>> GetAsync(CancellationToken cancellationToken) =>
        await _context.Buildings
            .AsNoTracking()
            .ToListAsync(cancellationToken);
}