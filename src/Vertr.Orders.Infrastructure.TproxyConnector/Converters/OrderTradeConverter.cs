using Vertr.Orders.Domain;

namespace Vertr.Orders.Infrastructure.TproxyConnector.Converters;

internal static class OrderTradeConverter
{
    public static OrderTrade Convert(this Tproxy.Client.Orders.OrderTrade orderTrade)
        => new OrderTrade
        {
            Id = new Guid(orderTrade.TradeId),
            OrderId = new Guid(orderTrade.OrderId),
            Price = orderTrade.Price,
            Qty = orderTrade.Qty,
            Timestamp = orderTrade.Timestamp,
        };
}
