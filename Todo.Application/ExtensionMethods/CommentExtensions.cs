using Todo.Models.Entities;
using Todo.Shared.Requests;
using Todo.Shared.Responses;

namespace Todo.Application.ExtensionMethods
{
    public static class CommentExtensions
    {
        #region CommentRequestDtos 
        /// <summary>
        /// From Comment to CommentRequestDto
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static CommentResponsetDto ToCommentRequestDto(this Comment comment)
        {
            return new CommentResponsetDto
            {   
                Content = comment.Content,
                Date = comment.Date,  
                Id = comment.Id,
            };
        }
        /// <summary>
        /// From CommentList to CommentRequestDtoList
        /// </summary>
        /// <param name="commentList"></param>
        /// <returns></returns>
        public static List<CommentResponsetDto> ToCommentRequestDtoList(this IEnumerable<Comment> commentList)
        {
            return commentList?.Select(i => i.ToCommentRequestDto()).ToList() ?? new List<CommentResponsetDto>();
        }
        #endregion

        #region Comments
        /// <summary>
        /// From CommentUpdateOrCreateDto to Comment
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        public static Comment ToComment(this CommentCreateOrUpdateDto itemDto)
        {
            return new Comment
            {
                Content = itemDto.Content,
            };
        }
        /// <summary>
        /// From CommmentUpdateDtoList to CommmentList
        /// </summary>
        /// <param name="commentDtoList"></param>
        /// <returns></returns>
        public static List<Comment> ToCommentList(this IEnumerable<CommentCreateOrUpdateDto> commentDtoList)
        {
            return commentDtoList?.Select(i => i.ToComment()).ToList() ?? new List<Comment>();
        }

        #endregion
    }
}
