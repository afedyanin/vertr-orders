namespace Vertr.Orders.Domain.Instruments;
public record class Share(
    string Ticker,
    string ClassCode,
    string Isin,
    string Uid,
    string Name,
    string Sector,
    int Lot,
    string Currency) : IStaticDataItem
{
    public string ClassCodeTicker => $"{ClassCode}.{Ticker}";
}
