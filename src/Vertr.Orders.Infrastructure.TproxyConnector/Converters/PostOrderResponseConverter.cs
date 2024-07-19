using Vertr.Orders.Domain;
using Vertr.Tproxy.Client.Orders;

namespace Vertr.Orders.Infrastructure.TproxyConnector.Converters;

internal static class PostOrderResponseConverter
{
    public static OrderResponse Convert(this PostOrderResponse response)
        => new OrderResponse
        {
            OrderId = response.OrderId,
            OrderRequestId = new Guid(response.OrderRequestId),
            Status = (Domain.OrderExecutionStatus)response.Status,
            LotsExecuted = response.LotsExecuted,
            LotsRequested = response.LotsRequested,
            CommissionValue = response.ExecutedCommission.Value,
            CommissionCurrency = response.ExecutedCommission.Currency,
            Message = response.Message,
        };
}
