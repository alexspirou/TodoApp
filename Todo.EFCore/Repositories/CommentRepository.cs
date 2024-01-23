using Microsoft.EntityFrameworkCore;
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

        public async Task<Comment> CreateCommentAsync(uint commentId, Comment comment)
        {
            Context.Comment.Add(comment);
            await SaveAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllComments()
        {
            var result = await Context.Comment.ToListAsync();

            return result;
        }

        public async Task<Comment> GetCommentById(uint id)
        {
            var result = 
                await Context.Comment
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();

            return result ?? new Comment();
        }
    }
}
