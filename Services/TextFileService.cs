using FactLogger.Contracts;
using FactLogger.Models;
using System.Text.Json;

namespace FactLogger.Services;

/// <summary>
/// Service for handling text file operations related to text file.
/// </summary>
public class TextFileService : ITextFileService
{
    private const string _filePath = "cat_facts.txt";
    private readonly ILogger<TextFileService> _logger;

    public TextFileService(ILogger<TextFileService> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Appends a cat fact to a text file asynchronously. Creates the file if it does not exist.
    /// </summary>
    /// <param name="fact">The cat fact to append.</param>
    public async Task AppendFactToFileAsync(CatFact fact)
    {
        try
        {
            _logger.LogInformation("Checking if file exists.");
            if (!File.Exists(_filePath))
            {
                _logger.LogInformation("File does not exist. Creating new file.");
                using (File.Create(_filePath)) 
                {
                    _logger.LogInformation("File has been created.");
                }
            }

            var factJson = JsonSerializer.Serialize(fact);

            _logger.LogInformation("Appending fact to file.");
            await File.AppendAllTextAsync(_filePath, factJson + Environment.NewLine);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while writing to the file.");
            throw;
        }
    }
}
