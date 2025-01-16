namespace Device.API.Configuration;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(services));
    }
}