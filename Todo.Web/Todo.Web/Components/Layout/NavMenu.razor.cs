using Microsoft.AspNetCore.Components;
using Todo.Web.Common;

namespace Todo.Web.Components.Layout
{
    public partial class NavMenu : ComponentBase
    {

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        protected void OnHomeIsClicked()
        {
            NavigationManager.NavigateTo(NavigationRoutes.Home);
        }
        protected void OnMyTasksIsClicked()
        {
            NavigationManager.NavigateTo(NavigationRoutes.MyTasks);
        }         
        
        protected void OnAddNewTaskIsClicked()
        {
            NavigationManager.NavigateTo(NavigationRoutes.AddNewTask);
        }        
        
 
    }
}
