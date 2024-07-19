namespace Vertr.Orders.Domain.Repositories;

public interface IOrdersRepository
{
    Task SaveOrderRequest(OrderRequest orderRequest);

    Task SaveOrderResponse(OrderResponse orderResponse);
}
