using ChimeMate.Application.Features.Persistence;
using ChimeMate.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChimeMate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AppDbContext");

        serviceCollection.AddDbContext<IDbContext, AppDbContext>(
            options => options.UseSqlServer(connectionString)
        );

        return serviceCollection;
    }
}
