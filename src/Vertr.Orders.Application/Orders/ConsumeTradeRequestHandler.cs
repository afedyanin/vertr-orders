using MediatR;
using Microsoft.Extensions.Logging;
using Vertr.Orders.Domain.Repositories;

namespace Vertr.Orders.Application.Orders;

internal sealed class ConsumeTradeRequestHandler : IRequestHandler<ConsumeTradeRequest, ConsumeTradeResponse>
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly ILogger<ConsumeTradeRequestHandler> _logger;

    public ConsumeTradeRequestHandler(
        IOrdersRepository ordersRepository,
        ILogger<ConsumeTradeRequestHandler> logger
        )
    {
        _ordersRepository = ordersRepository;
        _logger = logger;
    }

    public async Task<ConsumeTradeResponse> Handle(ConsumeTradeRequest request, CancellationToken cancellationToken)
    {
        // TODO: send notification to portfolio
        var trade = request.OrderTrade!;
        await _ordersRepository.SaveOrderTrade(trade);

        _logger.LogDebug($"Order trade saved. Id={trade.Id}");

        return new ConsumeTradeResponse();
    }
}
