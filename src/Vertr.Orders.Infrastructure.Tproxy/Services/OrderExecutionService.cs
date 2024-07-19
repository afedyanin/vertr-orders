using Microsoft.Extensions.Logging;
using Vertr.Orders.Domain;
using Vertr.Orders.Domain.Services;

namespace Vertr.Orders.Infrastructure.Tproxy.Services;

internal sealed class OrderExecutionService : IOrderExecutionService
{
    private readonly ILogger<OrderExecutionService> _logger;

    public OrderExecutionService(ILogger<OrderExecutionService> logger)
    {
        _logger = logger;
    }

    public Task<ExecuteOrderResult> ExecuteOrder(ExecuteOrderCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start executing order. OrderId={command.OrderId}");

        // TODO: Call tproxy client
        var res = new ExecuteOrderResult();

        _logger.LogInformation($"End executing order. OrderId={command.OrderId}");

        return Task.FromResult(res);
    }
}
