using ToDo.Shared.Requests;
using ToDo.Shared.Responses;

namespace Todo.Application.Services
{
    public interface ITodoService
    {
        Task<TodoEntryRequestDto> CreateTodoEntryAsync(TodoEntryCreateOrUpdateDto todoEntryDto);
        Task<List<TodoEntryRequestDto>> GetAllTodoEntriesAsync();
        Task<TodoEntryRequestDto> GetTodoEntryById(uint id);
        Task<TodoEntryRequestDto> UpdateTodoEntryAsync(string name, DateTime dateTime, TodoEntryCreateOrUpdateDto todoEntryDto);
        Task<TodoEntryRequestDto> DeleteTodoEntryAsync(string name, DateTime dateTime);
        Task<TodoEntryRequestDto> DeleteTodoEntryAsync(uint id);
    }
}
