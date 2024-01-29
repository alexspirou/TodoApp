using Todo.Shared.Responses;

namespace Todo.Web.Components.Pages
{
    public partial class MyTasksView
    {
        private List<CategoryResponseDto>? _toDoEntries;

        protected override async Task OnParametersSetAsync()
        {
            _toDoEntries = await TodoEntriesService.GetAllTodoEntriesAsync();
        }
    }
}