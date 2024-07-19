using Microsoft.Extensions.DependencyInjection;
using Vertr.Orders.Domain.Repositories;
using Vertr.Orders.Infrastructure.DataAccess.Repositories;

namespace Vertr.Orders.Infrastructure.DataAccess;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<OrdersContext>();

        serviceCollection.AddScoped<IOrdersRepository, OrdersRepository>();

        return serviceCollection;
    }

}
