using Todo.EFCore.Repositories.Common;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories.Interfaces
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {
        Task<Comment> CreateCommentAsync(Comment comment);
        Task<Comment> GetCommentByIdAsync(Guid id);
        Task<List<Comment>> GetAllCommentsAsync();
    }
}
