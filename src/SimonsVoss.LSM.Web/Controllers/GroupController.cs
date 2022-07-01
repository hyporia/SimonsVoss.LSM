using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimonsVoss.LSM.Core.Requests.GetGroups;

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

    /// <summary>
    /// Get groups by search term
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<GetGroupsQueryResponse> GetAsync([FromQuery] GetGroupsQuery query)
    {
        var resp = await _mediator.Send(query);
        return resp;
    }
}