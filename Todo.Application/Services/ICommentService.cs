using ToDo.Shared.Requests;
using ToDo.Shared.Responses;

namespace Todo.Application.Services
{
    public interface ICommentService
    {
        Task<CommentRequestDto> CreateCommentAsync(uint itemId, CommentCreateOrUpdateDto newComment);
        Task<List<CommentRequestDto>> GetAllComments();
        Task<CommentRequestDto> GetCommentById(uint id);
        Task<CommentRequestDto> UpdateComment(uint id, CommentCreateOrUpdateDto updatedComment);
        Task<CommentRequestDto> DeleteComment(uint id);
    }
}
