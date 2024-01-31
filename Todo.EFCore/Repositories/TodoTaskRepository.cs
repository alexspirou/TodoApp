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

        public async Task<TodoTask> CreateTodoTaskAsync(TodoTask item, CancellationToken cancellationToken)
        {
            Context.TodoTask.Add(item);
            await SaveAsync(cancellationToken);
            return item;
        }

        public async Task<List<TodoTask>> GetAllTodoTasks(CancellationToken cancellationToken)
        {
            var result =
                await Context.TodoTask
                    .AsNoTracking()
                    .Include(i => i.Comment)
                    .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<TodoTask> GetTodoTaskByIdAsync(Guid id,CancellationToken cancellationToken)
        {
            var result =
               await Context.TodoTask
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync(cancellationToken);

            return result ?? new TodoTask(string.Empty) ;
        }
    }
}
