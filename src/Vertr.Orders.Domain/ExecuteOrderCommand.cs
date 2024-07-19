namespace Vertr.Orders.Domain;

public record class ExecuteOrderCommand(Guid OrderId, string InstrumentId, decimal Price, long Lots);
