using Common.Application.Configuration;
using Common.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShahanStore.Infrastructure;
using System.Reflection;

namespace ShahanStore.Config;

public static class DependencyInjection
{
    public static IServiceCollection AddStoreDependency(this IServiceCollection services,Assembly assembly,IConfiguration configuration)
    {
        services.AddCommonApplication(assembly);
        services.AddCommonInfrastructure();
        services.AddInfrastructure(configuration);

        return services;
    }
}