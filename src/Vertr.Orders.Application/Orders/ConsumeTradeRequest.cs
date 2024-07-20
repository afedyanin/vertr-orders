using MediatR;
using Vertr.Orders.Domain;

namespace Vertr.Orders.Application.Orders;

public record class ConsumeTradeRequest(OrderTrade Trade) : IRequest
{
}
