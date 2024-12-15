namespace FactLogger.Models;

/// <summary>
/// Represents a cat fact.
/// </summary>
public class CatFact
{
    /// <summary>
    /// The text of the cat fact.
    /// </summary>
    public string Fact { get; set; } = default!;
    /// <summary>
    /// The length of the cat fact.
    /// </summary>
    public int Length { get; set; }
}
