using Todo.Shared.Requests;
using Todo.Shared.Responses;

namespace Todo.Application.Services.Interfaces
{
    public interface ICommentService
    {
        Task<CommentResponsetDto> CreateCommentAsync(Guid itemId, CommentCreateOrUpdateDto newComment);
        Task<List<CommentResponsetDto>> GetAllCommentsAsync();
        Task<CommentResponsetDto> GetCommentById(Guid id);
        Task<CommentResponsetDto> UpdateCommentAsync(Guid id, CommentCreateOrUpdateDto updatedComment);
        Task<CommentResponsetDto> DeleteCommentAsync(Guid id);
    }
}
