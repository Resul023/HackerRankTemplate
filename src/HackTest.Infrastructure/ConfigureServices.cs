using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HackTest.Infrastructure.Persistence;
using HackTest.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HackTest.Infrastructure;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("Default"),
            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        //services.AddScoped<ApplicationDbContextInitialiser>();
        return services;
    }
}
