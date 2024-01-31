using Todo.EFCore.Repositories.Common;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories
{
    public interface ITodoTaskRepository : IRepositoryBase<TodoTask>
    {
        Task<TodoTask> CreateTodoTaskAsync(TodoTask comment, CancellationToken cancellationToken = default);
        Task<TodoTask> GetTodoTaskByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<TodoTask>> GetAllTodoTasks(CancellationToken cancellationToken = default);
    }
}
