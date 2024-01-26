using Microsoft.EntityFrameworkCore;
using Todo.EFCore.Context;
using Todo.EFCore.Repositories.Common;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories
{
    public class ToDoEntryRepository : RepositoryBase<TodoEntry>, IToDoEntryRepository
    {
        public ToDoEntryRepository(ToDoAppDbContext todoAppContext) : base(todoAppContext)
        {
        }

        public async Task<TodoEntry> CreateToDoEntryAsync(TodoEntry entry)
        {
            Context.TodoEntry.Add(entry);
            await SaveAsync();
            return entry;
        }

        public async Task<List<TodoEntry>> GetToDoEntriesAsync()
        {
            var result = await Context.TodoEntry
                .AsNoTracking()
                .Include(t => t.Item).ThenInclude(i => i.Comment)
                .ToListAsync();

            return result;
        }       
        
        public async Task<TodoEntry> GetTodoEntryByNameAndDateAsync(string name, DateTime date)
        {
            var result = await Context.TodoEntry
                .Include(t => t.Item).ThenInclude(i => i.Comment)
                .Where(t => t.Name.Equals(name) && t.Date == date)
                .SingleOrDefaultAsync();

            return result ?? new TodoEntry();
        }

    }
}

