using SimonsVoss.LSM.Core.DTO.Building;

namespace SimonsVoss.LSM.Core.Abstractions;

public interface IBuildingRepository
{
    Task<List<FilteredBuilding>> GetAsync(string term, CancellationToken cancellationToken);
}