using MediatR;

namespace Vertr.Orders.Application.Orders;
public record class PostOrderRequest(Guid portfolioId, string instrumentId, decimal price, decimal qty) : IRequest<PostOrderResponse>
{
}
