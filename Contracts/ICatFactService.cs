using FactLogger.Models;

namespace FactLogger.Contracts;

/// <summary>
/// Interface for fetching cat facts.
/// </summary>
public interface ICatFactService
{
    Task<CatFact?> GetCatFactAsync();
}
