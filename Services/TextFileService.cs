using FactLogger.Contracts;
using FactLogger.Models;
using System.Text.Json;

namespace FactLogger.Services;

public class TextFileService : ITextFileService
{
    private const string FilePath = "cat_facts.txt";
    private readonly ILogger<TextFileService> _logger;

    public TextFileService(ILogger<TextFileService> logger)
    {
        _logger = logger;
    }

    public async Task<bool> AppendFactToFileAsync(CatFact fact)
    {
        try
        {
            _logger.LogInformation("Checking if file exists.");
            if (!File.Exists(FilePath))
            {
                _logger.LogInformation("File does not exist. Creating new file.");
                using (File.Create(FilePath)) { }
            }

            var factJson = JsonSerializer.Serialize(fact);

            _logger.LogInformation("Appending fact to file.");
            await File.AppendAllTextAsync(FilePath, factJson + Environment.NewLine);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while writing to the file.");
            return false;
        }
    }
}
