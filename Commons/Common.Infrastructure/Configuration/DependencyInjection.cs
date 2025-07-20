using Common.Infrastructure.MediatR;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Common.Infrastructure.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddCommonInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<SyncContinueOnExceptionPublisher>();
        services.AddScoped<SyncStopOnExceptionPublisher>();
        services.AddScoped<AsyncPublisher>();
        services.AddScoped<ParallelNoWaitPublisher>();
        services.AddScoped<ParallelWhenAllPublisher>();
        services.AddScoped<ParallelWhenAnyPublisher>();

        return services;
    }
}