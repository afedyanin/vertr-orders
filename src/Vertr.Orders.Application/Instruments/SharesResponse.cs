using Vertr.Orders.Domain.Instruments;

namespace Vertr.Orders.Application.Instruments;
public record class SharesResponse(IEnumerable<Share> Shares);
