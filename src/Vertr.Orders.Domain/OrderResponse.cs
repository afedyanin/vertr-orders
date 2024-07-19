namespace Vertr.Orders.Domain;
public class OrderResponse
{
    public Guid OrderRequestId { get; set; }

    public string OrderId { get; set; } = string.Empty;

    public OrderExecutionStatus Status { get; set; }

    public long LotsRequested { get; set; }

    public long LotsExecuted { get; set; }

    public decimal CommissionValue { get; set; }

    public string CommissionCurrency { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
}
