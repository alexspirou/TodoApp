using Todo.Application.ExtensionMethods;
using Todo.EFCore.Repositories;
using ToDo.Shared.Requests;
using ToDo.Shared.Responses;

namespace Todo.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<CommentRequestDto> CreateCommentAsync(uint itemId,CommentCreateOrUpdateDto newComment)
        {
            if (newComment is null)
            {
                return new CommentRequestDto();
            }

            var tempComment = newComment.ToComment();
            tempComment.Date = DateTime.Now;
            tempComment.ItemId = itemId;
            var comment = await _commentRepository.CreateCommentAsync(itemId, tempComment);

            return comment.ToCommentRequestDto();
        }

        public async Task<CommentRequestDto> DeleteCommentAsync(uint id)
        {
            var commentForDelete = await _commentRepository.GetCommentByIdAsync(id);

            if (commentForDelete == null)
            {
                return new CommentRequestDto();
            }

            await _commentRepository.DeleteAsync(commentForDelete);

            return commentForDelete.ToCommentRequestDto();
        }

        public async Task<List<CommentRequestDto>> GetAllCommentsAsync()
        {
            var comments = await _commentRepository.GetAllCommentsAsync();
            return comments.ToCommentRequestDtoList();
        }

        public async Task<CommentRequestDto> GetCommentById(uint id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            return comment.ToCommentRequestDto();
        }

        public async Task<CommentRequestDto> UpdateCommentAsync(uint id, CommentCreateOrUpdateDto updatedComment)
        {
            var commentForUpdate = await _commentRepository.GetCommentByIdAsync(id);

            if (commentForUpdate == null)
            {
                return new CommentRequestDto();
            }
            // Update comment
            commentForUpdate.Content = updatedComment.Content;

            await _commentRepository.UpdateAsync(commentForUpdate);

            return commentForUpdate.ToCommentRequestDto();
        }
    }
}
