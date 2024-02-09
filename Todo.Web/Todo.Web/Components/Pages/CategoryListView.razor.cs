using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Todo.Shared.Requests;
using Todo.Shared.Responses;
using Todo.Web.Common;
using Todo.Web.State;

namespace Todo.Web.Components.Pages
{
    public partial class CategoryListView
    {
        private List<CategoryResponseDto>? _categories;

        protected override async Task OnInitializedAsync()
        {
            await AppState.RefreshCategories();
            _categories = AppState.Categories;
            AppState.CategoryChangedEvent += UpdateCategoriesList;
        }
        public void UpdateCategoriesList()
        {
            _categories = AppState.Categories;
            StateHasChanged();
        }


    }
}