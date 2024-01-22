using Todo.Models.Entities;
using ToDo.Shared.Common;
using ToDo.Shared.Data;
using ToDo.Shared.Requests.UpdateTodoEntry;

namespace Todo.Application.ExtensionMethods
{
    public static class CommentExtensions
    {
        #region CommentDtos 
        /// <summary>
        /// From Comment to CommentDto
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {   
                Content = comment.Content,
                Date = comment.Date,    
            };
        }
        /// <summary>
        /// From CommentList to CommentDtoList
        /// </summary>
        /// <param name="commentList"></param>
        /// <returns></returns>

        public static List<CommentDto> ToCommentDtoList(this IEnumerable<Comment> commentList)
        {
            return commentList?.Select(i => i.ToCommentDto()).ToList() ?? new List<CommentDto>();
        }
        /// <summary>
        /// From Comment to CommentUpdateDto
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        #endregion

        #region CommentUpdateDto
        public static CommentUpdateDto ToCommentUpdateDto(this Comment comment)
        {
            return new CommentUpdateDto
            {
                Content = comment.Content,
            };
        }
        /// <summary>
        /// From CommentList to CommentUpdateDtoList
        /// </summary>
        /// <param name="commentList"></param>
        /// <returns></returns>
        public static List<CommentUpdateDto> ToCommentUpdateDtoList(this IEnumerable<Comment> commentList)
        {
            return commentList?.Select(i => i.ToCommentUpdateDto()).ToList() ?? new List<CommentUpdateDto>();
        }


        #endregion

        #region Comments
        /// <summary>
        /// From CommentDto to Comment
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        public static Comment ToComment(this CommentDto itemDto)
        {
            return new Comment
            {
                Content = itemDto.Content,
                Date = itemDto.Date,
            };
        }
        /// <summary>
        /// From CommentDtoList to CommentList
        /// </summary>
        /// <param name="commentDtoList"></param>
        /// <returns></returns>
        public static List<Comment> ToCommentList(this IEnumerable<CommentDto> commentDtoList)
        {
            return commentDtoList?.Select(i => i.ToComment()).ToList() ?? new List<Comment>();
        }
        /// <summary>
        /// From CommentUpdateDto to Comment
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        public static Comment ToComment(this CommentUpdateDto itemDto)
        {
            return new Comment
            {
                Content = itemDto.Content,
            };
        }
        /// <summary>
        /// From CommentList to CommmentUpdateDto
        /// </summary>
        /// <param name="commentDtoList"></param>
        /// <returns></returns>
        public static List<Comment> ToCommentList(this IEnumerable<CommentUpdateDto> commentDtoList)
        {
            return commentDtoList?.Select(i => i.ToComment()).ToList() ?? new List<Comment>();
        }

        #endregion
    }
}
