using Vertr.Orders.Domain;
using Vertr.Orders.Domain.Repositories;

namespace Vertr.Orders.Infrastructure.DataAccess.Repositories;

internal sealed class OrdersRepository : IOrdersRepository
{
    public Task SaveOrderRequest(OrderRequest orderRequest)
    {
        throw new NotImplementedException();
    }

    public Task SaveOrderResponse(OrderResponse orderResponse)
    {
        throw new NotImplementedException();
    }
}
