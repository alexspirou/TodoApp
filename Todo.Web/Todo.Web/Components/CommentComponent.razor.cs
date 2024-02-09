
using Microsoft.AspNetCore.Components;
using Todo.Shared.Requests;
using Todo.Shared.Responses;

namespace Todo.Web.Components
{
    public partial class CommentComponent
    {
        [Parameter]
        public List<CommentResponsetDto> Comments { get; set; } = null!;   

        [Parameter]
        public Guid TodoTaskId { get; set; }

        private bool _isEditing = false;
        private string _bindedCommend = string.Empty;
        private string _newComment = string.Empty;
        private Dictionary<Guid, string> _bindingCommentDict = new();
        protected override async Task OnInitializedAsync()
        {
            UpdateComments();
        }


        private void UpdateComments()
        {
            _bindingCommentDict.Clear();    
            foreach (var comment in Comments)
            {
                if (_bindingCommentDict.ContainsKey(comment.Id))
                {
                    continue;
                }
                _bindingCommentDict.Add(comment.Id, comment.Content);
            }

        }

        private void ToggleEdit(CommentResponsetDto comment)
        {
            _isEditing = true;
            _bindedCommend = comment.Content;
        }


        private async Task DeleteComment(Guid commentId, CancellationToken cancellationToken = default)
        {
            await TodoEntriesService.DeleteCommentAsync(commentId, cancellationToken);
            UpdateComments();
            Comments = await TodoEntriesService.GetCommentsByTodoTaskIdAsync(TodoTaskId, cancellationToken);
        }

        private async Task SaveEdit(Guid commentId, string content, CancellationToken cancellationToken = default)
        {
            await TodoEntriesService.UpdateComment(commentId, new CommentCreateOrUpdateDto(content), cancellationToken);

            _isEditing = false;
            Comments = await TodoEntriesService.GetCommentsByTodoTaskIdAsync(TodoTaskId, cancellationToken);

        }       
        
        private async Task Save(string content, CancellationToken cancellationToken = default)
        {
            await TodoEntriesService.AddNewCommentAsync(TodoTaskId, new CommentCreateOrUpdateDto(content), cancellationToken);
            Comments = await TodoEntriesService.GetCommentsByTodoTaskIdAsync(TodoTaskId, cancellationToken);
            _newComment  = string.Empty;    
            UpdateComments();
        }

        private async Task CancelEdit(CommentResponsetDto comment)
        {
            _isEditing = false;
        }
    }
}
