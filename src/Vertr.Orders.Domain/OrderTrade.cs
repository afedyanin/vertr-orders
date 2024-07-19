namespace Vertr.Orders.Domain;
public class OrderTrade
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public DateTime Timestamp { get; set; }

    public decimal Price { get; set; }

    public long Qty { get; set; }
}
