using Microsoft.AspNetCore.Components;
using ToDo.Shared.Responses;

namespace Todo.Web.Components.Pages
{
    public partial class Home : ComponentBase
    {
        private List<TodoEntryRequestDto>? _todoEntries { get; set; }



        protected override async Task OnInitializedAsync()
        {

            int a = 0;
        }

    }
}
