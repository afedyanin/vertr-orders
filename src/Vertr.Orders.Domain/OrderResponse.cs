namespace Vertr.Orders.Domain;
public class OrderResponse
{
    public Guid Id { get; set; } // TrackingId

    public Guid OrderId { get; set; }

    public Guid OrderRequestId { get; set; }

    public OrderExecutionStatus Status { get; set; }

    public long LotsRequested { get; set; }

    public long LotsExecuted { get; set; }

    public decimal CommissionValue { get; set; }

    public string CommissionCurrency { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public DateTime ServerTime { get; set; }
}
