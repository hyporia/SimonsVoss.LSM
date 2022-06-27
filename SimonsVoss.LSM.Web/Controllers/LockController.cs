using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimonsVoss.LSM.Core.Requests.GetLocks;
using SimonsVoss.LSM.DB;

namespace SimonsVoss.LSM.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class LockController : ControllerBase
{
    private readonly ILogger<LockController> _logger;
    private readonly IMediator _mediator;

    public LockController(ILogger<LockController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<GetLocksQueryResponse> GetAsync([FromQuery] GetLocksQuery query)
    {
        var resp = await _mediator.Send(query);
        return resp;
    }
}