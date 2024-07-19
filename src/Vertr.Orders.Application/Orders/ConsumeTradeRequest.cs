using MediatR;
using Vertr.Orders.Domain;

namespace Vertr.Orders.Application.Orders;

public class ConsumeTradeRequest : IRequest<ConsumeTradeResponse>
{
    public OrderTrade? OrderTrade { get; set; }
}
