using Todo.Shared.Requests;
using Todo.Shared.Responses;

namespace Todo.Web.Services.Interfaces
{
    public interface ITodoEntriesService
    {
        public Task<List<CategoryResponseDto>> GetAllTodoEntriesAsync(CancellationToken cancellationToken = default);
        Task<List<TodoTaskResponseDto>> GetTodoTasksByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
        public Task DeleteTodoTaskAsync(TodoTaskResponseDto todoTask, CancellationToken cancellationToken = default);
        public Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<CategoryResponseDto> GetCategoryByIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
        public Task<Guid> AddNewTaskAsync(Guid categoryId, TodoTaskDtoCreateUpdateDto todoTask, CancellationToken cancellationToken = default);
        public Task AddNewCommentAsync(Guid todoTaskId, CommentCreateOrUpdateDto comment, CancellationToken cancellationToken = default);
        public Task MarkTodoTaskAsCompletedAsync(Guid todoTaskId, CancellationToken cancellationToken = default);
        public Task MarkTodoTaskAsInCompletedAsync(Guid todoTaskId, CancellationToken cancellationToken = default);
    }
}
