using FactLogger.Models;

namespace FactLogger.Contracts;

public interface ITextFileService
{
    Task<bool> AppendFactToFileAsync(CatFact fact);
}
