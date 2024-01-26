using ToDo.Shared.Requests;
using ToDo.Shared.Responses;

namespace Todo.Web.Services.Interfaces
{
    public interface ITodoEntriesService
    {
        public Task<List<TodoEntryRequestDto>> GetAllTodoEntriesAsync();
    }
}
