using Todo.Application.ExtensionMethods;
using Todo.Application.Services.Interfaces;
using Todo.EFCore.Repositories.Interfaces;
using Todo.Shared.Requests;
using Todo.Shared.Responses;

namespace Todo.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<CommentResponsetDto> CreateCommentAsync(Guid itemId,CommentCreateOrUpdateDto newComment)
        {
            if (newComment is null)
            {
                return new CommentResponsetDto();
            }

            var tempComment = newComment.ToComment();
            tempComment.ItemId = itemId;
            var comment = await _commentRepository.CreateCommentAsync(tempComment);

            return comment.ToCommentRequestDto();
        }

        public async Task<CommentResponsetDto> DeleteCommentAsync(Guid id)
        {
            var commentForDelete = await _commentRepository.GetCommentByIdAsync(id);

            if (commentForDelete == null)
            {
                return new CommentResponsetDto();
            }

            await _commentRepository.DeleteAsync(commentForDelete);

            return commentForDelete.ToCommentRequestDto();
        }

        public async Task<List<CommentResponsetDto>> GetAllCommentsAsync()
        {
            var comments = await _commentRepository.GetAllCommentsAsync();
            return comments.ToCommentRequestDtoList();
        }

        public async Task<CommentResponsetDto> GetCommentById(Guid id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            return comment.ToCommentRequestDto();
        }

        public async Task<CommentResponsetDto> UpdateCommentAsync(Guid id, CommentCreateOrUpdateDto updatedComment)
        {
            var commentForUpdate = await _commentRepository.GetCommentByIdAsync(id);

            if (commentForUpdate == null)
            {
                return new CommentResponsetDto();
            }
            // Update comment
            commentForUpdate.Content = updatedComment.Content;

            await _commentRepository.UpdateAsync(commentForUpdate);

            return commentForUpdate.ToCommentRequestDto();
        }
    }
}
