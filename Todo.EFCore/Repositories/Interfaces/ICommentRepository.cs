using Todo.EFCore.Repositories.Common;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories.Interfaces
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {
        Task<Comment> CreateCommentAsync(Comment comment, CancellationToken cancellationToken);
        Task<Comment> GetCommentByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Comment>> GetAllCommentsByTodoTaskIdAsync(Guid todoTaskId,CancellationToken cancellationToken);
    }
}
