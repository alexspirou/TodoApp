using Todo.EFCore.Repositories.Common;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories
{
    public interface ITodoTaskRepository : IRepositoryBase<TodoTask>
    {
        Task<TodoTask> CreateTodoTaskAsync(TodoTask comment);
        Task<TodoTask> GetTodoTaskByIdAsync(Guid id);
        Task<List<TodoTask>> GetAllTodoTasks();
    }
}
