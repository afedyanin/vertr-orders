using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vertr.Orders.Application.Instruments;
using Vertr.Orders.Domain.Instruments;

namespace Vertr.Orders.Server.Controllers;
[Route("api/static-data")]
[ApiController]
public class StaticDataController : ControllerBase
{
    private readonly IMediator _mediator;

    public StaticDataController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("shares")]
    public async Task<ActionResult<Share?>> GetShares(string? query)
    {
        var request = new SharesRequest(query);
        var res = await _mediator.Send(request);
        var shares = res.Shares.ToArray();

        return Ok(shares);
    }
}
