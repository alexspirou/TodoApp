using ToDo.Shared.Common;
using ToDo.Shared.Requests.UpdateTodoEntry;

namespace Todo.Application.Services
{
    public interface ITodoManager
    {
        Task<TodoEntryDto> CreateTodoEntryAsync(TodoEntryDto todoEntryDto);
        Task<List<TodoEntryDto>> GetAllEntriesAsync();
        Task<TodoEntryDto> UpdateEntry(string name, DateTime dateTime, TodoEntryUpdateDto todoEntryDto);
        Task<TodoEntryDto> DeleteEntry(TodoEntryDto todoEntryDto);
    }
}
