using Vertr.Orders.Domain.Instruments;

namespace Vertr.Orders.Domain;

public class OrderRequest
{
    public Guid Id { get; set; }

    public Guid PortfolioId { get; set; }

    public string InstrumentId { get; set; } = string.Empty;

    public string ClassCode { get; set; } = string.Empty;

    public string Ticker { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public long Lots { get; set; }

    public DateTime Created { get; set; }

    public static OrderRequest Create(
        Guid portfolioId,
        Share share,
        decimal price,
        long lots)
        => new OrderRequest
        {
            Id = Guid.NewGuid(),
            Created = DateTime.UtcNow,
            PortfolioId = portfolioId,
            InstrumentId = share.Uid,
            ClassCode = share.ClassCode,
            Ticker = share.Ticker,
            Price = price,
            Lots = lots
        };
}
