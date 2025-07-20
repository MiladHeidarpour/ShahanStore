using Common.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShahanStore.Domain.Categories;
using ShahanStore.Infrastructure.BackgroundJobs;
using ShahanStore.Infrastructure.Data;
using ShahanStore.Infrastructure.Repositories;

namespace ShahanStore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddHostedService<ProcessOutboxMessagesJob>();
        return services;
    }
}