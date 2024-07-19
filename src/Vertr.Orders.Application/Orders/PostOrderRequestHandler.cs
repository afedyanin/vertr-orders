using MediatR;
using Microsoft.Extensions.Logging;
using Vertr.Orders.Domain;
using Vertr.Orders.Domain.Instruments;
using Vertr.Orders.Domain.Repositories;
using Vertr.Orders.Domain.Services;

namespace Vertr.Orders.Application.Orders;

public class PostOrderRequestHandler : IRequestHandler<PostOrderRequest, PostOrderResponse>
{
    private readonly IOrderExecutionService _orderExecutionService;
    private readonly IStaticDataService _staticDataService;
    private readonly IOrdersRepository _ordersRepository;

    private readonly ILogger<PostOrderRequestHandler> _logger;

    public PostOrderRequestHandler(
        IOrderExecutionService orderExecutionService,
        IStaticDataService staticDataService,
        IOrdersRepository ordersRepository,
        ILogger<PostOrderRequestHandler> logger)
    {
        _orderExecutionService = orderExecutionService;
        _staticDataService = staticDataService;
        _ordersRepository = ordersRepository;
        _logger = logger;
    }

    public async Task<PostOrderResponse> Handle(PostOrderRequest request, CancellationToken cancellationToken)
    {
        var share = await GetShare(request.ClasscodeTicker);

        var orderRequest = OrderRequest.Create(
            request.PortfolioId,
            share,
            request.Price,
            request.Lots);

        await _ordersRepository.SaveOrderRequest(orderRequest);
        var result = await _orderExecutionService.ExecuteOrder(orderRequest, cancellationToken);
        await _ordersRepository.SaveOrderResponse(result);

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
