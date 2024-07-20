using MediatR;
using Microsoft.Extensions.Logging;
using Vertr.Orders.Domain.Repositories;

namespace Vertr.Orders.Application.Orders;

internal sealed class ConsumeTradeRequestHandler : IRequestHandler<ConsumeTradeRequest>
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

    public async Task Handle(ConsumeTradeRequest request, CancellationToken cancellationToken)
    {
        await _ordersRepository.SaveOrderTrade(request.Trade);
        // TODO: send notification to portfolio

        _logger.LogDebug($"Order trade saved. Id={request.Trade.Id}");
    }
}
