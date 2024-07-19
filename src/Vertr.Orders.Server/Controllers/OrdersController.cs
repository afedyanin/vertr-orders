using System.ComponentModel.DataAnnotations;
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

    [HttpPost("{portfolioId:guid}")]
    public async Task<ActionResult<OrderResponse>> Post(
        [Required] Guid portfolioId,
        [Required] string classcodeTicker,
        decimal price = 0M,
        long lots = 1,
        CancellationToken cancellationToken = default)
    {
        var orderRequest = new PostOrderRequest(portfolioId, classcodeTicker, price, lots);
        var result = await _mediator.Send(orderRequest, cancellationToken);
        var orderResponse = result.Response;

        return Ok(orderResponse);
    }
}
