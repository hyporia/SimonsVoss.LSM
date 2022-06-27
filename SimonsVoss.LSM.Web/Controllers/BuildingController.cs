using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimonsVoss.LSM.Core.Requests.SearchEntity;
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

    [HttpGet]
    public async Task<SearchEntityQueryResponse> GetAsync([FromQuery]SearchEntityQuery query)
    {
        EfContext.GetDataToSeed(out var buildings, out var locks, out var groups, out var media);
        var ids = media.Where(medium => !groups.Any(group => medium.GroupId == group.Id)).ToList();
        var resp = await _mediator.Send(query);
        return resp;
    }
}
