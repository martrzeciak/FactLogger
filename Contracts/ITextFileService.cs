using FactLogger.Models;

namespace FactLogger.Contracts;

/// <summary>
/// Interface for handling file operations related to cat facts.
/// </summary>
public interface ITextFileService
{
    Task AppendFactToFileAsync(CatFact fact);
}
