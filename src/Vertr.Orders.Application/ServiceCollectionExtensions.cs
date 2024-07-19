using Microsoft.Extensions.DependencyInjection;
using Vertr.Orders.Application.Orders;

namespace Vertr.Orders.Application;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppMediator(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(PostOrderRequestHandler).Assembly);
        });

        return serviceCollection;
    }
}
