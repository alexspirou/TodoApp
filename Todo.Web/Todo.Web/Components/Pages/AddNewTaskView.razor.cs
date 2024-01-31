using Todo.Shared.Requests;

namespace Todo.Web.Components.Pages
{
    public partial class AddNewTaskView 
    {
        private CreateTodoTaskWithCommentsAndItems? _todoTask;


        protected override void OnInitialized()
        {
            _todoTask = new CreateTodoTaskWithCommentsAndItems(
                new CategoryCreateOrUpdateDto(string.Empty),
                new CommentCreateOrUpdateDto(string.Empty),
                new TodoTaskDtoCreateUpdateDto(string.Empty, false)
            );



        }
        private Task AddTask(EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
