using Todo.EFCore.Repositories.Common;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories
{
    public interface IToDoEntryRepository : IRepositoryBase<TodoEntry>
    {
        Task<TodoEntry> CreateToDoEntryAsync(TodoEntry entry);
        Task<List<TodoEntry>> GetToDoEntries();
        Task<TodoEntry> GetTodoEntryByNameAndDate(string name, DateTime date);
    }
}
