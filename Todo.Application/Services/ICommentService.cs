using ToDo.Shared.Requests;
using ToDo.Shared.Responses;

namespace Todo.Application.Services
{
    public interface ICommentService
    {
        Task<CommentResponsetDto> CreateCommentAsync(uint itemId, CommentCreateOrUpdateDto newComment);
        Task<List<CommentResponsetDto>> GetAllCommentsAsync();
        Task<CommentResponsetDto> GetCommentById(uint id);
        Task<CommentResponsetDto> UpdateCommentAsync(uint id, CommentCreateOrUpdateDto updatedComment);
        Task<CommentResponsetDto> DeleteCommentAsync(uint id);
    }
}
