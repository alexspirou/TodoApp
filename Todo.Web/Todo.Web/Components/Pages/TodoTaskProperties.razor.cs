using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Todo.Shared.Responses;

namespace Todo.Web.Components.Pages
{
    public partial class TodoTaskProperties
    {
        [Parameter] public TodoTaskResponseDto TodoTask { get; set; } = default!;
        [Parameter] public string? TodoTaskJson { get; set; } 
        [Parameter] public string TodoTaskTitle { get; set; } = default!;



        protected override void OnInitialized()
        {

            if(!string.IsNullOrEmpty(TodoTaskJson))
            {
                TodoTask = JsonSerializer.Deserialize<TodoTaskResponseDto>(TodoTaskJson);
            }



        }

    }
}
