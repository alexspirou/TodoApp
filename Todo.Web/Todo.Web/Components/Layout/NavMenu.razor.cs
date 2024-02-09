using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Todo.Shared.Responses;
using Todo.Web.Common;
using Todo.Web.State;

namespace Todo.Web.Components.Layout
{
    public partial class NavMenu : ComponentBase
    {
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private AppState AppState { get; set; } = null!;

        private List<CategoryResponseDto>? _categories { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await AppState.RefreshCategories();
            _categories = AppState.Categories;
            AppState.CategoryChangedEvent += async ()=> await OnCategoryHasChangedEventHandler();
        }

        protected void OnHomeIsClicked()
        {
            NavigationManager.NavigateTo(NavigationRoutes.Home);
        }

        protected void OnMyTasksIsClicked()
        {
            NavigationManager.NavigateTo(NavigationRoutes.MyCategories);
        }

        protected void OnCategorySubMenuClicked(CategoryResponseDto categoryResponseDto)
        {
            var url = $"category/{categoryResponseDto.Name.Trim()}/{categoryResponseDto.Id}";
            NavigationManager.NavigateTo(url);
        }

        protected void OnAddNewTaskIsClicked()
        {
            NavigationManager.NavigateTo(NavigationRoutes.AddNewTask);
        }

        private async Task OnCategoryHasChangedEventHandler()
        {
            _categories = AppState.Categories;

            StateHasChanged();
        }
    }
}
