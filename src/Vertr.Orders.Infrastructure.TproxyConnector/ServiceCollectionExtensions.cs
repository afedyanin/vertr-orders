using Microsoft.Extensions.DependencyInjection;
using Refit;
using Vertr.Orders.Domain.Services;
using Vertr.Orders.Infrastructure.TproxyConnector.Services;
using Vertr.Tproxy.Client;

namespace Vertr.Orders.Infrastructure.TproxyConnector;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTpoxy(this IServiceCollection serviceCollection, Uri baseAddress)
    {
        serviceCollection.AddTransient<IOrderExecutionService, OrderExecutionService>();
        serviceCollection.AddSingleton<IStaticDataService, StaticDataService>();

        serviceCollection.AddRefitClient<ITproxyApi>()
            .ConfigureHttpClient(c => c.BaseAddress = baseAddress);

        return serviceCollection;
    }
}
