using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Todo.Shared.Requests;
using Todo.Shared.Responses;
using Todo.Web.Common;

namespace Todo.Web.Components.Pages
{
    public partial class CatergoriesTaskView
    {
        private List<CategoryResponseDto>? _categories;

        protected override async Task OnInitializedAsync()
        {
            await UpdateCategoriesList();
        }
        public async Task UpdateCategoriesList()
        {
            _categories = await TodoEntriesService.GetAllTodoEntriesAsync();
        }
    }
}