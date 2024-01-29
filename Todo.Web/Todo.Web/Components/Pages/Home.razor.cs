using Microsoft.AspNetCore.Components;
using Todo.Shared.Responses;

namespace Todo.Web.Components.Pages
{
    public partial class Home : ComponentBase
    {
        private List<CategoryResponseDto>? _todoEntries { get; set; }



        protected override async Task OnInitializedAsync()
        {

            int a = 0;
        }

    }
}
