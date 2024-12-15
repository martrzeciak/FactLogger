using FactLogger.Models;

namespace FactLogger.Contracts;

/// <summary>
/// Interface for handling file operations related to cat facts.
/// </summary>
public interface ITextFileService
{
    /// <summary>
    /// Appends a cat fact to a text file asynchronously.
    /// </summary>
    /// <param name="fact">The cat fact to append.</param>
    Task AppendFactToFileAsync(CatFact fact);
}
