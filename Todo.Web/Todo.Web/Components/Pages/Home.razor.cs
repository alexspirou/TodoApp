using Microsoft.AspNetCore.Components;
using Todo.Shared.Responses;
using static QuoteService;

namespace Todo.Web.Components.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject] QuoteService QuoteService { get; set; } = null!;


        private Quote? randomQuotes { get; set; }



        protected override async Task OnInitializedAsync()
        {
            randomQuotes = await QuoteService.GetRandomQuoteAsync();
        }

    }
}
