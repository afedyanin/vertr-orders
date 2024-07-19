namespace Vertr.Orders.Domain.Services;
public interface IOrderExecutionService
{
    Task<ExecuteOrderResult> ExecuteOrder(ExecuteOrderCommand command, CancellationToken cancellationToken);
}
