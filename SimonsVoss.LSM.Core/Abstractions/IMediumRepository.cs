using SimonsVoss.LSM.Core.DTO.Medium;

namespace SimonsVoss.LSM.Core.Abstractions;

public interface IMediumRepository
{
    Task<List<FilteredMedium>> GetAsync(string term, CancellationToken cancellationToken);
}