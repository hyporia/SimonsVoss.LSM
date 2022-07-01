using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimonsVoss.LSM.Core.Requests.GetMedia;

namespace SimonsVoss.LSM.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class MediumController : ControllerBase
{
    private readonly ILogger<MediumController> _logger;
    private readonly IMediator _mediator;

    public MediumController(ILogger<MediumController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// Get media by search term
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<GetMediaQueryResponse> GetAsync([FromQuery] GetMediaQuery query)
    {
        var resp = await _mediator.Send(query);
        return resp;
    }
}