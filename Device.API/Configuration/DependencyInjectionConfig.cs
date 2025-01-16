using Device.API.Repositories.V1;
using Device.API.Services.V1.Devices;

namespace Device.API.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(services));

        services.AddScoped<IDevicesService, DevicesService>();
        services.AddScoped<IDevicesRepository, DevicesRepository>();
    }
}
