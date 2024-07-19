
using Microsoft.Extensions.Logging;
using Vertr.Orders.Domain.Instruments;
using Vertr.Orders.Domain.Services;
using Vertr.Orders.Infrastructure.TproxyConnector.Converters;
using Vertr.Tproxy.Client;

namespace Vertr.Orders.Infrastructure.TproxyConnector.Services;

internal sealed class StaticDataService : IStaticDataService
{
    private readonly ITproxyApi _tproxyApi;
    private readonly ILogger<StaticDataService> _logger;

    private Share[] _shares = [];

    public StaticDataService(
        ITproxyApi tproxyApi,
        ILogger<StaticDataService> logger)
    {
        _tproxyApi = tproxyApi;
        _logger = logger;
    }

    public async Task<IEnumerable<Share>> FindShares(string? keyword)
    {
        if (_shares.Length == 0)
        {
            _shares = await GetAllShares();
        }

        if (string.IsNullOrEmpty(keyword))
        {
            return _shares;
        }

        var res = _shares.Where(
            s => s.Isin.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
            || s.ClassCodeTicker.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
            || s.Ticker.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
            || s.ClassCode.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
            || s.Uid.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
            || s.Name.Contains(keyword, StringComparison.CurrentCultureIgnoreCase));

        return res.ToArray();
    }

    private async Task<Share[]> GetAllShares()
    {
        _logger.LogInformation("Fetching all shares from TProxy...");
        var items = await _tproxyApi.GetShares();
        var shares = items.Convert().ToArray();
        _logger.LogInformation($"{shares.Length} shares received.");

        return shares;
    }
}
