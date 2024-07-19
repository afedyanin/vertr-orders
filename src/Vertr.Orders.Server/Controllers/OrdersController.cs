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

    [HttpPost("{portfolioId:guid}/{classcodeTicker}")]
    public async Task<ActionResult<OrderResponse>> Post(
        Guid portfolioId,
        string classcodeTicker,
        decimal price,
        long lots,
        CancellationToken cancellationToken = default)
    {
        var orderRequest = new PostOrderRequest(portfolioId, classcodeTicker, price, lots);

        var response = await _mediator.Send(orderRequest, cancellationToken);

        return Ok(response);
    }
}
