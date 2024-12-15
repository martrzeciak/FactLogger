using FactLogger.Contracts;
using Microsoft.AspNetCore.Components;

namespace FactLogger.Components.Pages
{
    /// <summary>
    /// Home component that displays a random cat fact and provides functionality to fetch new facts.
    /// </summary>
    public partial class Home
    {
        [Inject]
        private ICatFactService CatFactService { get; set; } = default!;

        [Inject]
        private ITextFileService FileService { get; set; } = default!;

        private string? _catFact;

        /// <summary>
        /// Fetches a new cat fact and updates the display. Logs the fact to a file if successful.
        /// </summary>
        private async Task GetNewCatFact()
        {

            try
            {
                var fact = await CatFactService.GetCatFactAsync();
                if (fact != null)
                {
                    _catFact = fact.Fact;
                    await FileService.AppendFactToFileAsync(fact);
                }
                else
                {
                    _catFact = "Failed to fetch a new fact. Please try again later.";
                }
            }
            catch (Exception)
            {
                _catFact = "An error occurred. Please try again later.";
            }
        }
    }
}