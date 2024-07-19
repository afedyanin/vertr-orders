using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vertr.Orders.Domain.Repositories;
using Vertr.Orders.Infrastructure.DataAccess.Repositories;

namespace Vertr.Orders.Infrastructure.DataAccess;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection serviceCollection,
        Action<DbContextOptionsBuilder> options)
    {
        serviceCollection.AddDbContext<OrdersContext>(options);
        serviceCollection.AddScoped<IOrdersRepository, OrdersRepository>();

        return serviceCollection;
    }

}
