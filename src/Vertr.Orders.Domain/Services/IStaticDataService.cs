using Vertr.Orders.Domain.Instruments;

namespace Vertr.Orders.Domain.Services;

public interface IStaticDataService
{
    Task<IEnumerable<Share>> FindShares(string? keyword);
}
