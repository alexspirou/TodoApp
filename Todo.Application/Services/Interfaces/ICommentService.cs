using Todo.Shared.Requests;
using Todo.Shared.Responses;

namespace Todo.Application.Services.Interfaces
{
    public interface ICommentService
    {
        Task<CommentResponsetDto> CreateCommentAsync(Guid itemId, CommentCreateOrUpdateDto newComment, CancellationToken cancellationToken);
        Task<List<CommentResponsetDto>> GetAllCommentsByTodoTaskIdAsync(Guid todotTaskId, CancellationToken cancellationToken);
        Task<CommentResponsetDto> GetCommentById(Guid id, CancellationToken cancellationToken);
        Task<CommentResponsetDto> UpdateCommentAsync(Guid id, CommentCreateOrUpdateDto updatedComment, CancellationToken cancellationToken);
        Task<CommentResponsetDto> DeleteCommentAsync(Guid id, CancellationToken cancellationToken);
    }
}
