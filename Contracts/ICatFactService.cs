using FactLogger.Models;

namespace FactLogger.Contracts;

/// <summary>
/// Interface for fetching cat facts.
/// </summary>
public interface ICatFactService
{
    /// <summary>
    /// Fetches a random cat fact asynchronously.
    /// </summary>
    /// <returns>A <see cref="CatFact"/> object if successful, or null otherwise.</returns>
    Task<CatFact?> GetCatFactAsync();
}
