using Vertr.Orders.Domain;
using Vertr.Tproxy.Client.Orders;

namespace Vertr.Orders.Infrastructure.TproxyConnector.Converters;

internal static class PostOrderResponseConverter
{
    public static ExecuteOrderResult Convert(this PostOrderResponse response)
        => new ExecuteOrderResult(
            response.OrderRequestId,
            response.OrderId,
            response.InstrumentUid,
            (Domain.OrderExecutionStatus)response.Status,
            response.LotsRequested,
            response.LotsExecuted,
            response.ExecutedCommission.Value,
            response.ExecutedCommission.Currency,
            response.Message
            );
}
