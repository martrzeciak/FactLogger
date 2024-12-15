using FactLogger.Configuration;
using FactLogger.Contracts;
using FactLogger.Services;
using Microsoft.Extensions.Options;

namespace FactLogger.Extensions;

public static class ApplicationServiceExtensions
{
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