namespace Device.API.Configuration;

/// <summary>
/// 
/// </summary>
public static class DatabaseConfig
{
    /// <summary>
    /// 
    /// </summary>
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(services));
    }
}