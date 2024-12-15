using FactLogger.Models;

namespace FactLogger.Contracts;

public interface ITextFileService
{
    Task AppendFactToFileAsync(CatFact fact);
}
