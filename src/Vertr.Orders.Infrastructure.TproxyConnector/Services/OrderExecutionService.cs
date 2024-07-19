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

    public async Task<OrderResponse> ExecuteOrder(OrderRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Posting order. Id={request.Id}");

        var postOrderRequest = new PostOrderRequest(
            request.InstrumentId,
            request.Id,
            request.Lots,
            request.Price);

        var response = await _tproxyApi.PostOrder(postOrderRequest);

        var orderResponse = response.Convert();

        _logger.LogInformation($"Order response: {orderResponse}");

        return orderResponse;
    }
}
