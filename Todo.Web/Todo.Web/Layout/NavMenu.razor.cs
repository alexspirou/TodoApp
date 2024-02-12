using Microsoft.AspNetCore.Components;
using Todo.Shared.Responses;
using Todo.Web.Common;
using Todo.Web.Services;

namespace Todo.Web.Layout
{
    public partial class NavMenu : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] 
        private AppState AppState { get; set; } = null!;

        // Gets a reference to the MainLayout component
        [CascadingParameter]
        public MainLayout Layout { get; set; }
        [Parameter]
        public EventCallback OnMenuOptionIsClicked { get; set; }
        private List<CategoryResponseDto>? _categories { get; set; }

        protected override async Task OnInitializedAsync()
        {
           await AppState.RefreshCategories();
            _categories = AppState.Categories;
            AppState.CategoryChangedEvent += async () => await OnCategoryHasChangedEventHandler();
        }

        protected void OnHomeIsClicked()
        {
            ShowContentHideMenu();
            NavigationManager.NavigateTo(NavigationRoutes.Home);

        }



        protected void OnMyTasksIsClicked()
        {
            ShowContentHideMenu();
            NavigationManager.NavigateTo(NavigationRoutes.MyCategories);

        }

        protected void OnCategorySubMenuClicked(CategoryResponseDto categoryResponseDto)
        {
            ShowContentHideMenu();
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

        private void ShowContentHideMenu()
        {
            Layout.LayoutVisibilitySettings.IsContentHidden = false;
            Layout.LayoutVisibilitySettings.IsSideBarShown = false;
            Layout.LayoutVisibilitySettings.IsToggleImageShown = false;

            OnMenuOptionIsClicked.InvokeAsync();
        }
    }
}
