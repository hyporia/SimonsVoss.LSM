using MediatR;
using SimonsVoss.LSM.Core.Abstractions;

namespace SimonsVoss.LSM.Core.Requests.GetLocks;

public class GetLocksQueryHandler : IRequestHandler<GetLocksQuery, GetLocksQueryResponse>
{
    private readonly ILockRepository _lockRepository;

    public GetLocksQueryHandler(ILockRepository lockRepository)
    {
        _lockRepository = lockRepository;
    }

    public async Task<GetLocksQueryResponse> Handle(GetLocksQuery request, CancellationToken cancellationToken)
    {
        return await _lockRepository.GetAsync(request, cancellationToken);
    }
}