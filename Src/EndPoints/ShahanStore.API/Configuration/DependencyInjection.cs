using Mapster;
using MapsterMapper;
using ShahanStore.API.Common.FileUtil.Interfaces;
using ShahanStore.API.Common.FileUtil.Services;
using ShahanStore.Application.CQRS.Categories.Commands.Create;
using ShahanStore.Config;

namespace ShahanStore.API.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddAPIDependency(this IServiceCollection services, IConfiguration configuration)
    {
        var apiAssembly = typeof(Program).Assembly;
        var applicationAssembly = typeof(CreateCategoryCommand).Assembly;

        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(apiAssembly);
        typeAdapterConfig.Scan(applicationAssembly);
        services.AddSingleton(typeAdapterConfig);
        services.AddScoped<IMapper, ServiceMapper>();

        services.AddStoreDependency(applicationAssembly, configuration);

        services.AddScoped<ILocalFileService, LocalFileService>();

        return services;
    }
}