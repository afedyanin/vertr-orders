using MediatR;
using Microsoft.Extensions.Logging;
using Vertr.Orders.Domain;
using Vertr.Orders.Domain.Instruments;
using Vertr.Orders.Domain.Services;

namespace Vertr.Orders.Application.Orders;

public class PostOrderRequestHandler : IRequestHandler<PostOrderRequest, PostOrderResponse>
{
    private readonly IOrderExecutionService _orderExecutionService;
    private readonly IStaticDataService _staticDataService;

    private readonly ILogger<PostOrderRequestHandler> _logger;

    public PostOrderRequestHandler(
        IOrderExecutionService orderExecutionService,
        IStaticDataService staticDataService,
        ILogger<PostOrderRequestHandler> logger)
    {
        _orderExecutionService = orderExecutionService;
        _staticDataService = staticDataService;
        _logger = logger;
    }

    public async Task<PostOrderResponse> Handle(PostOrderRequest request, CancellationToken cancellationToken)
    {
        var orderId = Guid.NewGuid();
        var share = await GetShare(request.ClasscodeTicker);

        var command = new ExecuteOrderCommand(orderId, share.Uid, request.Price, request.Lots);
        // TODO: save command
        var result = await _orderExecutionService.ExecuteOrder(command, cancellationToken);
        // TODO: save response

        var response = new PostOrderResponse(result);
        return response;
    }

    private async Task<Share> GetShare(string classcodeTicker)
    {
        try
        {
            var shares = await _staticDataService.FindShares(classcodeTicker);
            return shares.Single();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Cannot find single share by {classcodeTicker}");
            throw;
        }
    }
}
