using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Todo.Shared.Requests;
using Todo.Shared.Responses;
using Microsoft.JSInterop;

namespace Todo.Web.Components
{
    public partial class CategoryComponent
    {
        [Parameter]
        public CategoryResponseDto Category { get; set; }
        [Parameter]
        public EventCallback OnDeleteCategoryClicked { get; set; }
        private List<TodoTaskResponseDto>? _todoTasks { get; set; }


        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private IJSRuntime JavaScriptProperty { get; set; } = null!;


        private Dictionary<Guid, bool> IsRowExpandedDickt = new();
        private bool _isRowExpanded = false;
        private string? NewTaskName { get; set; }
        private string? Comment { get; set; }


        protected async Task OnPropertyClicked(TodoTaskResponseDto todoTask)
        {

            IsRowExpandedDickt[todoTask.Id] = !IsRowExpandedDickt[todoTask.Id];

            await UpdateTodoTasks();


        }

        protected override async Task OnInitializedAsync()
        {
            await UpdateTodoTasks();
        }
        protected async Task DeleteTodoTaskAsync(TodoTaskResponseDto todoTask)
        {
            await TodoEntriesService.DeleteTodoTaskAsync(todoTask);

            if (IsRowExpandedDickt.ContainsKey(todoTask.Id))
            {
                IsRowExpandedDickt.Remove(todoTask.Id);
            }
            await UpdateTodoTasks();

        }

        private async Task UpdateTodoTasks()
        {
            if (Category is null)
            {
                return;
            }
            _todoTasks = await TodoEntriesService.GetTodoTasksByCategoryIdAsync(Category.Id);


            foreach (var todoTask in _todoTasks)
            {
                if (IsRowExpandedDickt.ContainsKey(todoTask.Id))
                {
                    continue;
                }
                IsRowExpandedDickt.Add(todoTask.Id, false);
            }
        }

        protected async Task DeleteCategoryAsync(Guid id)
        {
            await TodoEntriesService.DeleteCategoryAsync(id);
            await OnDeleteCategoryClicked.InvokeAsync();

            await UpdateTodoTasks();
        }


        protected void OnPropertiesClick(TodoTaskResponseDto todoTask)
        {
            var url = $"todo-task-properties/todo-task/{todoTask?.Title.Trim()}/{JsonSerializer.Serialize(todoTask)}";
            NavigationManager.NavigateTo(url);
        }

        protected async Task UpdateStatus(TodoTaskResponseDto todoTask)
        {
            if (todoTask.IsDone)
            {
                await TodoEntriesService.MarkTodoTaskAsInCompletedAsync(todoTask.Id);
            }
            else
            {

                await TodoEntriesService.MarkTodoTaskAsCompletedAsync(todoTask.Id);
            }
            await UpdateTodoTasks();

        }


        private async Task AddNewTaskAsync(Guid categoryId, string taskName, string? comment, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(taskName))
            {
                return;
            }
            var tempTaks = new TodoTaskDtoCreateUpdateDto(taskName, false);

            var toDoTaskId = await TodoEntriesService.AddNewTaskAsync(categoryId, tempTaks, cancellationToken);
            if (comment is not null)
            {
                await TodoEntriesService.AddNewCommentAsync(toDoTaskId, new CommentCreateOrUpdateDto(comment), cancellationToken);
            }
            await UpdateTodoTasks();

        }
    }
}
