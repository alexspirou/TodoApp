using Microsoft.EntityFrameworkCore;
using Todo.EFCore.Context;
using Todo.EFCore.Repositories.Common;
using Todo.EFCore.Repositories.Interfaces;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(ToDoAppDbContext todoAppContext) : base(todoAppContext)
        {
        }

        public async Task<Comment> CreateCommentAsync(Comment comment, CancellationToken cancellationToken)
        {
            Context.Comment.Add(comment);
            await SaveAsync(cancellationToken);
            return comment;
        }

        public async Task<List<Comment>> GetAllCommentsByTodoTaskIdAsync(Guid todotTaskId, CancellationToken cancellationToken)
        {
            var result = await Context.Comment
                .AsNoTracking()
                .Where(c => c.ItemId == todotTaskId)
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Comment> GetCommentByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = 
                await Context.Comment
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync(cancellationToken);

            return result ?? new Comment();
        }
    }
}
