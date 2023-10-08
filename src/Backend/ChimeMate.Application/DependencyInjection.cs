using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChimeMate.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Transient);

        return serviceCollection;
    }
}
