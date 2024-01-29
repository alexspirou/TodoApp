using Microsoft.EntityFrameworkCore;
using Todo.EFCore.Context;
using Todo.EFCore.Repositories.Common;
using Todo.EFCore.Repositories.Interfaces;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories
{
    public class TodoTaskRepository : RepositoryBase<TodoTask>, ITodoTaskRepository
    {
        public TodoTaskRepository(ToDoAppDbContext todoAppContext) : base(todoAppContext)
        {
        }

        public async Task<TodoTask> CreateTodoTaskAsync(TodoTask item)
        {
            Context.Item.Add(item);
            await SaveAsync();
            return item;
        }

        public async Task<List<TodoTask>> GetAllTodoTasks()
        {
            var result =
                await Context.Item
                    .AsNoTracking()
                    .Include(i => i.Comment)
                    .ToListAsync();

            return result;
        }

        public async Task<TodoTask> GetTodoTaskByIdAsync(Guid id)
        {
            var result =
               await Context.Item
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return result ?? new TodoTask();
        }
    }
}
