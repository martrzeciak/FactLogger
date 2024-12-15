using FactLogger.Configuration;
using FactLogger.Contracts;
using FactLogger.Services;
using Microsoft.Extensions.Options;

namespace FactLogger.Extensions;

/// <summary>
/// Extension methods for configuring application services.
/// </summary>
public static class ApplicationServiceExtensions
{
    /// <summary>
    /// Adds application services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
        IConfiguration configuration)
    {

        services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));

        services.AddHttpClient("catFactsApi", (serviceProvider, client) =>
        {
            var settings = serviceProvider.GetRequiredService<IOptions<ApiSettings>>().Value;
            client.BaseAddress = new Uri(settings.BaseUrl);
        });
        services.AddScoped<ICatFactService, CatFactService>();
        services.AddScoped<ITextFileService, TextFileService>();

        return services;
    }
}