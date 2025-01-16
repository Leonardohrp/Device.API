using Microsoft.OpenApi.Models;

namespace Device.API.Configuration;

/// <summary>
/// 
/// </summary>
public static class SwaggerConfig
{
    /// <summary>
    /// 
    /// </summary>
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(services));

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "Version .NET 9.0",
                Title = "Devices API",
                Description = "Dedicated endpoints to Devices Domain",
                Contact = new OpenApiContact
                {
                    Name = "Leonardo Pinheiro",
                    Email = "leonardohrp@hotmail.com"
                }
            });

            foreach (var name in Directory.GetFiles(AppContext.BaseDirectory, "*.XML", SearchOption.TopDirectoryOnly))
            {
                c.IncludeXmlComments(filePath: name);
            }
        });
    }

    /// <summary>
    /// 
    /// </summary>
    public static void UseSwaggerSetup(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(app));

        app.UseSwagger();
        app.UseSwaggerUI(config =>
        {
            config.SwaggerEndpoint("/swagger/v1/swagger.json", "Devices V1");
            config.RoutePrefix = string.Empty;
        });
    }
}