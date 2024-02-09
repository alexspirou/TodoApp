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
        public async Task<CommentResponsetDto> CreateCommentAsync(Guid itemId,CommentCreateOrUpdateDto newComment, CancellationToken cancellationToken)
        {
            if (newComment is null)
            {
                throw new ArgumentNullException(nameof(newComment));
            }

            var tempComment = newComment.ToComment();
            tempComment.ItemId = itemId;
            var comment = await _commentRepository.CreateCommentAsync(tempComment, cancellationToken);

            return comment.ToCommentRequestDto();
        }

        public async Task<CommentResponsetDto> DeleteCommentAsync(Guid id, CancellationToken cancellationToken)
        {
            var commentForDelete = await _commentRepository.GetCommentByIdAsync(id,cancellationToken);

            if (commentForDelete == null)
            {
                throw new NullReferenceException(nameof(commentForDelete));
            }

            await _commentRepository.DeleteAsync(commentForDelete, cancellationToken);

            return commentForDelete.ToCommentRequestDto();
        }

        public async Task<List<CommentResponsetDto>> GetAllCommentsByTodoTaskIdAsync(Guid todotTaskId, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAllCommentsByTodoTaskIdAsync(todotTaskId, cancellationToken);
            return comments.ToCommentRequestDtoList();
        }

        public async Task<CommentResponsetDto> GetCommentById(Guid id, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id, cancellationToken);
            return comment.ToCommentRequestDto();
        }

        public async Task<CommentResponsetDto> UpdateCommentAsync(Guid id, CommentCreateOrUpdateDto updatedComment, CancellationToken cancellationToken)
        {
            if (updatedComment is null)
            {
                throw new ArgumentNullException($"{nameof(updatedComment)}");
            }

            var commentForUpdate = await _commentRepository.GetCommentByIdAsync(id,cancellationToken);
            if (commentForUpdate == null)
            {
                throw new NullReferenceException($"{nameof(commentForUpdate)}");    
            }

            // Update comment
            commentForUpdate.Content = updatedComment.Content;

            await _commentRepository.UpdateAsync(commentForUpdate, cancellationToken);

            return commentForUpdate.ToCommentRequestDto();
        }
    }
}
