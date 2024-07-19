namespace Vertr.Orders.Domain.Instruments;
public interface IStaticDataItem
{
    string Uid { get; }
    string Ticker { get; }
    string ClassCode { get; }
    string Isin { get; }
}
