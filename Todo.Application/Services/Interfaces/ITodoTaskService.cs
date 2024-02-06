using Todo.Shared.Responses;

namespace Todo.Application.Services.Interfaces
{
    public interface ITodoTaskService
    {
        Task<TodoTaskResponseDto> CreateTodoTaskAsync(Guid toEntryId, TodoTaskDtoCreateUpdateDto todoEntryDto, CancellationToken cancellationToken = default);
        Task<List<TodoTaskResponseDto>> GetAllTodoTasksAsync(CancellationToken cancellationToken = default);
        Task<List<TodoTaskResponseDto>> GetTodoTasksByCategoryIdAsync(Guid categoryId,CancellationToken cancellationToken = default);
        Task<TodoTaskResponseDto> GetTodoTaskByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<TodoTaskResponseDto> UpdateTodoTaskAsync(Guid id, TodoTaskDtoCreateUpdateDto todoEntryDto, CancellationToken cancellationToken = default);
        Task<TodoTaskResponseDto> DeleteTodoTaskAsync(Guid id, CancellationToken cancellationToken = default);
        Task MarkTodoTaskAsCompletedAsync(Guid id, CancellationToken cancellationToken = default);
        Task MarkTodoTaskAsInCompletedAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
