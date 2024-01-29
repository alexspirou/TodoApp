using Todo.Shared.Responses;

namespace Todo.Application.Services.Interfaces
{
    public interface ITodoTaskService
    {
        Task<TodoTaskResponseDto> CreateTodoTaskAsync(Guid toEntryId, TodoTaskDtoCreateUpdateDto todoEntryDto);
        Task<List<TodoTaskResponseDto>> GetAllTodoTasksAsync();
        Task<TodoTaskResponseDto> GetTodoTaskByIdAsync(Guid id);
        Task<TodoTaskResponseDto> UpdateTodoTaskAsync(Guid id, TodoTaskDtoCreateUpdateDto todoEntryDto);
        Task<TodoTaskResponseDto> DeleteTodoTaskAsync(Guid id);
    }
}
