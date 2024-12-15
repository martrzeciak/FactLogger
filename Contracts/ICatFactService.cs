using FactLogger.Models;

namespace FactLogger.Contracts;

public interface ICatFactService
{
    Task<CatFact> GetCatFactAsync();
}
