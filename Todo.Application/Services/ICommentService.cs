using ToDo.Shared.Requests;
using ToDo.Shared.Responses;

namespace Todo.Application.Services
{
    public interface ICommentService
    {
        Task<CommentRequestDto> CreateCommentAsync(uint itemId, CommentCreateOrUpdateDto newComment);
        Task<List<CommentRequestDto>> GetAllCommentsAsync();
        Task<CommentRequestDto> GetCommentById(uint id);
        Task<CommentRequestDto> UpdateCommentAsync(uint id, CommentCreateOrUpdateDto updatedComment);
        Task<CommentRequestDto> DeleteCommentAsync(uint id);
    }
}
