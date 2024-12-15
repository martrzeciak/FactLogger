using FactLogger.Contracts;
using FactLogger.Models;

namespace FactLogger.Services;

public class CatFactService : ICatFactService
{
    private readonly ILogger<CatFactService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public CatFactService(ILogger<CatFactService> logger,
        IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }
    public async Task<CatFact?> GetCatFactAsync()
    {
        using var client = _httpClientFactory.CreateClient();

        try
        {
            _logger.LogInformation("Fetching cat fact from API.");
            return await client.GetFromJsonAsync<CatFact>("fact");
        }
        catch (Exception ex)
        {
            _logger.LogError("Error getting cat fact: {Error}", ex);
            throw;
        }
    }
}
