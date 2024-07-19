using Microsoft.Extensions.Logging;
using Vertr.Orders.Domain;
using Vertr.Orders.Domain.Services;
using Vertr.Orders.Infrastructure.TproxyConnector.Converters;
using Vertr.Tproxy.Client;
using Vertr.Tproxy.Client.Orders;

namespace Vertr.Orders.Infrastructure.TproxyConnector.Services;

internal sealed class OrderExecutionService : IOrderExecutionService
{
    private readonly ITproxyApi _tproxyApi;

    private readonly ILogger<OrderExecutionService> _logger;

    public OrderExecutionService(
        ITproxyApi tproxyApi,
        ILogger<OrderExecutionService> logger)
    {
        _tproxyApi = tproxyApi;
        _logger = logger;
    }

    public async Task<ExecuteOrderResult> ExecuteOrder(ExecuteOrderCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start executing order. OrderId={command.OrderId}");

        var request = new PostOrderRequest(command.InstrumentId, command.OrderId, command.Lots, command.Price);

        var response = await _tproxyApi.PostOrder(request);

        var result = response.Convert();

        _logger.LogInformation($"Execute order result: {result}");

        return result;
    }
}
