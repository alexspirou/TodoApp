using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Todo.Shared.Responses;
using Todo.Web.Common;

namespace Todo.Web.Components.Layout
{
    public partial class NavMenu : ComponentBase
    {
        private List<CategoryResponseDto>? _categories;

        protected override async Task OnInitializedAsync()
        {
            _categories = await TodoEntriesService.GetAllTodoEntriesAsync();
        }

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        protected void OnHomeIsClicked()
        {
            NavigationManager.NavigateTo(NavigationRoutes.Home);
        }

        protected void OnMyTasksIsClicked()
        {
            NavigationManager.NavigateTo(NavigationRoutes.MyTasks);
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
    }
}
