using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimonsVoss.LSM.DB;

namespace SimonsVoss.LSM.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class BuildingController : ControllerBase
{
    private readonly ILogger<BuildingController> _logger;
    private readonly IMediator _mediator;
    private readonly EfContext _context;

    public BuildingController(ILogger<BuildingController> logger, IMediator mediator, EfContext context)
    {
        _logger = logger;
        _mediator = mediator;
        _context = context;
    }

    // [HttpGet]
    // public async Task<SearchEntityQueryResponse> GetAsync([FromQuery] SearchEntityQuery query)
    // {
    //     var resp = await _mediator.Send(query);
    //     return resp;
    // }
}