using Microsoft.AspNetCore.Components;
using ToDo.Shared.Requests;

namespace Todo.Web.Components.Pages
{
    public partial class AddNewTaskView 
    {
        private CreateDtoWithCommentsAndItems? _todoEntry;


        protected override void OnInitialized()
        {
            _todoEntry = new CreateDtoWithCommentsAndItems(
                new TodoEntryCreateOrUpdateDto
                {
                    Name = string.Empty,
                },
                new CommentCreateOrUpdateDto
                {
                    Content = string.Empty,
                },
                new ItemDtoCreateUpdateDto
                {
                    Title = string.Empty,
                    IsDone = false 
                }
            );



        }
        private Task AddTask(EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
