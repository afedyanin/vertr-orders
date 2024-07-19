using MediatR;

namespace Vertr.Orders.Application.Orders;
public record class PostOrderRequest(Guid PortfolioId, string ClasscodeTicker, decimal Price, long Lots) : IRequest<PostOrderResponse>
{
}
