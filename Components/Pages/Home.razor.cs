using FactLogger.Contracts;
using Microsoft.AspNetCore.Components;

namespace FactLogger.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private ICatFactService CatFactService { get; set; } = default!;

        [Inject]
        private ITextFileService FileService { get; set; } = default!;

        private string? _catFact;

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