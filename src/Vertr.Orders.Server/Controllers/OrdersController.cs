using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vertr.Orders.Application.Orders;
using Vertr.Orders.Client;

namespace Vertr.Orders.Server.Controllers;
[Route("api/orders")]
[ApiController]

public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{portfolioId:guid}/{instrumentId}")]
    public async Task<ActionResult<OrderResponse>> Post(
        Guid portfolioId,
        string instrumentId,
        decimal price,
        decimal qty,
        CancellationToken cancellationToken = default)
    {
        var orderRequest = new PostOrderRequest(portfolioId, instrumentId, price, qty);

        var response = await _mediator.Send(orderRequest, cancellationToken);

        return Ok(response);
    }
}
