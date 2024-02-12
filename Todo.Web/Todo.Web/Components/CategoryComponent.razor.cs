using Microsoft.AspNetCore.Components;
using Todo.Shared.Requests;
using Todo.Shared.Responses;
using Todo.Web.Layout;

namespace Todo.Web.Components
{
    public partial class CategoryComponent
    {
        [Parameter]
        public CategoryResponseDto Category { get; set; } = null!;
        [Parameter]
        public EventCallback OnDeleteCategoryClicked { get; set; }

        // Gets a reference to the MainLayout component
        [CascadingParameter]
        public MainLayout Layout { get; set; }

        private List<TodoTaskResponseDto>? _todoTasks { get; set; }
        private Dictionary<Guid, bool> IsRowExpandedDict = new();
        private string? _newTaskName { get; set; }
        private string? _newTaskComment { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await UpdateTodoTasks();
        }

        private async Task OnArrowDownIsClickedAsync(TodoTaskResponseDto todoTask)
        {
            IsRowExpandedDict[todoTask.Id] = !IsRowExpandedDict[todoTask.Id];
            await UpdateTodoTasks();
        }

        private async Task DeleteTodoTaskAsync(TodoTaskResponseDto todoTask)
        {
            await TodoEntriesService.DeleteTodoTaskAsync(todoTask);

            if (IsRowExpandedDict.ContainsKey(todoTask.Id))
            {
                IsRowExpandedDict.Remove(todoTask.Id);
            }
            await UpdateTodoTasks();

        }

        private async Task DeleteCategoryAsync(CategoryResponseDto category)
        {
            await TodoEntriesService.DeleteCategoryAsync(category.Id);
            AppState.RemoveCategory(category.Id);
            AppState.RaiseCategoryChangedEvent();
            await UpdateTodoTasks();
        }

        private async Task UpdateStatusAsync(TodoTaskResponseDto todoTask)
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

            var toDoTaskId = await TodoEntriesService.AddNewTodoTaskAsync(categoryId, tempTaks, cancellationToken);
            if (comment is not null)
            {
                await TodoEntriesService.AddNewCommentAsync(toDoTaskId, new CommentCreateOrUpdateDto(comment), cancellationToken);
            }
            await UpdateTodoTasks();

        }

        private async Task UpdateTodoTasks()
        {
            if (Category is null)
            {
                throw new Exception("Category must not be null");
            }
            _todoTasks = await TodoEntriesService.GetTodoTasksByCategoryIdAsync(Category.Id);


            foreach (var todoTask in _todoTasks)
            {
                if (IsRowExpandedDict.ContainsKey(todoTask.Id))
                {
                    continue;
                }
                IsRowExpandedDict.Add(todoTask.Id, false);
            }
        }

    }
}
