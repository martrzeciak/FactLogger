using FactLogger.Contracts;
using FactLogger.Models;

namespace FactLogger.Services;

/// <summary>
/// Service for fetching cat facts from an external API.
/// </summary>
public class CatFactService : ICatFactService
{
    /// <summary>
    /// Logger for logging messages related to the cat fact service.
    /// </summary>
    private readonly ILogger<CatFactService> _logger;
    /// <summary>
    /// Factory for creating HTTP client instances for making API calls.
    /// </summary>
    private readonly IHttpClientFactory _httpClientFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="CatFactService"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="httpClientFactory">The HTTP client factory.</param>
    public CatFactService(ILogger<CatFactService> logger,
        IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// Fetches a random cat fact asynchronously.
    /// </summary>
    /// <returns>A <see cref="CatFact"/> object if successful, or null otherwise.</returns>
    public async Task<CatFact?> GetCatFactAsync()
    {
        using var client = _httpClientFactory.CreateClient("catFactsApi");

        try
        {
            _logger.LogInformation("Fetching cat fact from API.");
            return await client.GetFromJsonAsync<CatFact>("fact");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting cat fact.");
            throw;
        }
    }
}
