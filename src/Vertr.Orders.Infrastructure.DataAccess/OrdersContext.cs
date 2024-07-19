using Microsoft.EntityFrameworkCore;
using Vertr.Orders.Domain;

namespace Vertr.Orders.Infrastructure.DataAccess;
public class OrdersContext : DbContext
{
    public DbSet<OrderRequest> OrderRequests { get; set; }

    public DbSet<OrderResponse> OrderResponses { get; set; }
}
