using MediatR;
using Vertr.Orders.Domain.Services;

namespace Vertr.Orders.Application.Instruments;
internal sealed class SharesRequestHandler : IRequestHandler<SharesRequest, SharesResponse>
{
    private readonly IStaticDataService _staticDataService;

    public SharesRequestHandler(IStaticDataService marketDataService)
    {
        _staticDataService = marketDataService;
    }

    public async Task<SharesResponse> Handle(SharesRequest request, CancellationToken cancellationToken)
    {
        var shares = await _staticDataService.FindShares(request.Query);
        var res = new SharesResponse(shares);

        return res;
    }
}
