using Vertr.Orders.Domain;
using Vertr.Orders.Domain.Repositories;

namespace Vertr.Orders.Infrastructure.DataAccess.Repositories;

internal sealed class OrdersRepository : IOrdersRepository
{
    private readonly OrdersContext _context;

    public OrdersRepository(OrdersContext context)
    {
        _context = context;
    }

    public async Task SaveOrderRequest(OrderRequest orderRequest)
    {
        _context.OrderRequests.Add(orderRequest);
        await _context.SaveChangesAsync();
    }

    public async Task SaveOrderResponse(OrderResponse orderResponse)
    {
        _context.OrderResponses.Add(orderResponse);
        await _context.SaveChangesAsync();
    }

    public async Task SaveOrderTrade(OrderTrade orderTrade)
    {
        try
        {
            await _context.OrderTrades.AddAsync(orderTrade);
            await _context.SaveChangesAsync();
        }
        // Check PK constrain exception. log exception
        catch (Exception)
        {

        }
    }
}
