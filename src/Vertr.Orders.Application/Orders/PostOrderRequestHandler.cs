using MediatR;
using Microsoft.Extensions.Logging;
using Vertr.Orders.Domain;
using Vertr.Orders.Domain.Services;

namespace Vertr.Orders.Application.Orders;

public class PostOrderRequestHandler : IRequestHandler<PostOrderRequest, PostOrderResponse>
{
    private readonly IOrderExecutionService _orderExecutionService;
    private readonly ILogger<PostOrderRequestHandler> _logger;

    public PostOrderRequestHandler(
        IOrderExecutionService orderExecutionService,
        ILogger<PostOrderRequestHandler> logger)
    {
        _orderExecutionService = orderExecutionService;
        _logger = logger;
    }

    public async Task<PostOrderResponse> Handle(PostOrderRequest request, CancellationToken cancellationToken)
    {
        _logger.LogDebug($"Start executing order request: {request}");

        var orderId = Guid.NewGuid();
        var instrumentId = Guid.NewGuid().ToString();

        var command = new ExecuteOrderCommand(orderId, instrumentId, request.price, request.qty);

        // TODO: save request

        var commandResult = await _orderExecutionService.ExecuteOrder(command, cancellationToken);

        // TODO: Save response

        var response = new PostOrderResponse();

        _logger.LogDebug($"End executing order request. Response: {response}");

        return response;
    }
}
