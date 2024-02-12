using Todo.Shared.Requests;
using Todo.Shared.Responses;

namespace Todo.Web.Services.Interfaces
{
    public interface ITodoMangerService
    {
        #region Category
        public Task<List<CategoryResponseDto>> GetAllCategories(CancellationToken cancellationToken = default);
        public Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<CategoryResponseDto> GetCategoryByIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
        #endregion

        #region TodoTasks
        Task<List<TodoTaskResponseDto>> GetTodoTasksByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
        public Task DeleteTodoTaskAsync(TodoTaskResponseDto todoTask, CancellationToken cancellationToken = default);
        public Task<Guid> AddNewTodoTaskAsync(Guid categoryId, TodoTaskDtoCreateUpdateDto todoTask, CancellationToken cancellationToken = default);
        public Task MarkTodoTaskAsCompletedAsync(Guid todoTaskId, CancellationToken cancellationToken = default);
        public Task MarkTodoTaskAsInCompletedAsync(Guid todoTaskId, CancellationToken cancellationToken = default);
        #endregion

        #region Comments
        public Task AddNewCommentAsync(Guid todoTaskId, CommentCreateOrUpdateDto comment, CancellationToken cancellationToken = default);
        public Task UpdateComment(Guid commentId, CommentCreateOrUpdateDto comment, CancellationToken cancellationToken = default);
        public Task DeleteCommentAsync(Guid commentId, CancellationToken cancellationToken = default);
        public Task<List<CommentResponsetDto>> GetCommentsByTodoTaskIdAsync(Guid todoTaskId, CancellationToken cancellationToken = default);
        #endregion
    }
}
