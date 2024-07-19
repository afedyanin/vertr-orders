namespace Vertr.Orders.Client;

public record class OrderRequest(Guid OrderId, Guid PortfolioId, string InstrumentId, decimal Price, decimal Qty);
