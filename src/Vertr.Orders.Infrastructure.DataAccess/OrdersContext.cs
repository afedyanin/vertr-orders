using Microsoft.EntityFrameworkCore;
using Vertr.Orders.Domain;

namespace Vertr.Orders.Infrastructure.DataAccess;
public class OrdersContext : DbContext
{
    public DbSet<OrderRequest> OrderRequests { get; set; }

    public DbSet<OrderResponse> OrderResponses { get; set; }

    public DbSet<OrderTrade> OrderTrades { get; set; }

    public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
        .UseNpgsql("Host=localhost;Port=5432;Database=vertr_orders;Username=postgres;Password=admin")
        .UseSnakeCaseNamingConvention();
}
