using MediatR;

namespace Vertr.Orders.Application.Instruments;
public record class SharesRequest(string? Query = null) : IRequest<SharesResponse>
{
}
