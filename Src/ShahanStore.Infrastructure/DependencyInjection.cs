using Common.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShahanStore.Application;
using ShahanStore.Domain.Brands;
using ShahanStore.Domain.Categories;
using ShahanStore.Infrastructure.BackgroundJobs;
using ShahanStore.Infrastructure.Data;
using ShahanStore.Infrastructure.Repositories;

namespace ShahanStore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        //Connect IApplicationDbContext To AppDbContext For Querying
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<AppDbContext>());

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();

        services.AddHostedService<ProcessOutboxMessagesJob>();
        return services;
    }
}