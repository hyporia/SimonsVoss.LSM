using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimonsVoss.LSM.Core.Requests.GetBuildings;

namespace SimonsVoss.LSM.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class BuildingController : ControllerBase
{
    private readonly ILogger<BuildingController> _logger;
    private readonly IMediator _mediator;

    public BuildingController(ILogger<BuildingController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<GetBuildingsQueryResponse> GetAsync([FromQuery] GetBuildingsQuery query)
    {
        var resp = await _mediator.Send(query);
        return resp;
    }
}