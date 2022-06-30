using SimonsVoss.LSM.Core.DTO.Group;

namespace SimonsVoss.LSM.Core.Abstractions;

public interface IGroupRepository
{
    Task<List<FilteredGroup>> GetAsync(string term, CancellationToken cancellationToken);
}