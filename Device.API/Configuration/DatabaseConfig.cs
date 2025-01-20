using Device.API.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Device.API.Configuration;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(services));

        services.AddDbContext<DevicesDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Devices")));
    }

    public static void InitializeDatebase(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(app));
    }
}