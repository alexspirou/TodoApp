using Todo.EFCore.Context;
using Todo.EFCore.Repositories.Common;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(ToDoAppDbContext todoAppContext) : base(todoAppContext)
        {
        }

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            Context.Comment.Add(comment);
            await SaveAsync();
            return comment;
        }

  
    }
}
