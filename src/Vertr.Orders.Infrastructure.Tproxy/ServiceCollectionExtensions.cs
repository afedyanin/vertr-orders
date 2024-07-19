using Microsoft.Extensions.DependencyInjection;
using Vertr.Orders.Domain.Services;
using Vertr.Orders.Infrastructure.Tproxy.Services;

namespace Vertr.Orders.Infrastructure.Tproxy;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTpoxy(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IOrderExecutionService, OrderExecutionService>();

        return serviceCollection;
    }
}
