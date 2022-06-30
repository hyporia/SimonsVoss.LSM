using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimonsVoss.LSM.Core.Requests.GetGroups;
using SimonsVoss.LSM.Core.Requests.GetMedia;
using SimonsVoss.LSM.DB;

namespace SimonsVoss.LSM.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    private readonly ILogger<GroupController> _logger;
    private readonly IMediator _mediator;

    public GroupController(ILogger<GroupController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<GetGroupsQueryResponse> GetAsync([FromQuery] GetGroupsQuery query)
    {
        var resp = await _mediator.Send(query);
        return resp;
    }
}