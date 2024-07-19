using Vertr.Orders.Domain.Instruments;

namespace Vertr.Orders.Infrastructure.TproxyConnector.Converters;
internal static class ShareConverter
{
    public static IEnumerable<Share> Convert(this IEnumerable<Tproxy.Client.Instruments.Share> shares)
        => shares.Select(Convert);

    public static Share Convert(this Tproxy.Client.Instruments.Share share)
        => new Share(
            share.Ticker,
            share.ClassCode,
            share.Isin,
            share.Uid,
            share.Name,
            share.Sector,
            share.Lot,
            share.Currency);
}
