namespace Vertr.Orders.Domain.Services;
public interface IOrderExecutionService
{
    Task<OrderResponse> ExecuteOrder(OrderRequest request, CancellationToken cancellationToken);
}
