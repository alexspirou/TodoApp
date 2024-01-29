using Todo.Shared.Responses;

namespace Todo.Web.Services.Interfaces
{
    public interface ITodoEntriesService
    {
        public Task<List<CategoryResponseDto>> GetAllTodoEntriesAsync();
    }
}
