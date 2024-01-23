using Todo.EFCore.Repositories.Common;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {
        Task<Comment> CreateCommentAsync(uint commentId,Comment comment);
        Task<Comment> GetCommentById(uint id);
        Task<List<Comment>> GetAllComments();
    }
}
