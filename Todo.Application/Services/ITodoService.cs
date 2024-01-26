using ToDo.Shared.Requests;
using ToDo.Shared.Responses;

namespace Todo.Application.Services
{
    public interface ITodoService
    {
        Task<TodoEntryResponseDto> CreateTodoEntryAsync(TodoEntryCreateOrUpdateDto todoEntryDto);
        Task<List<TodoEntryResponseDto>> GetAllTodoEntriesAsync();
        Task<TodoEntryResponseDto> GetTodoEntryById(uint id);
        Task<TodoEntryResponseDto> UpdateTodoEntryAsync(string name, DateTime dateTime, TodoEntryCreateOrUpdateDto todoEntryDto);
        Task<TodoEntryResponseDto> DeleteTodoEntryAsync(string name, DateTime dateTime);
        Task<TodoEntryResponseDto> DeleteTodoEntryAsync(uint id);
    }
}
