using Todo.Models.Entities;
using Todo.Shared.Responses;

namespace Todo.Application.ExtensionMethods
{
    public static class TodoTaskExtensions
    {

        public static TodoTaskResponseDto ToTodoTasksResponseDto(this TodoTask todoTask)
        {
            return new TodoTaskResponseDto( todoTask.Id,
                                            todoTask.Title, 
                                            todoTask.IsDone, 
                                            todoTask.Date, 
                                            todoTask?.Comment?.ToCommentRequestDtoList());
        }

        public static List<TodoTaskResponseDto> ToTodoTaskResponseDtoList(this IEnumerable<TodoTask> todoTaskList)
        {
            return todoTaskList?.Select(i => i.ToTodoTasksResponseDto()).ToList() ?? new List<TodoTaskResponseDto>();
        }


        public static TodoTask ToTodoTask(this TodoTaskDtoCreateUpdateDto todoTaskDtoCreateUpdateDto)
        {
            return new TodoTask(todoTaskDtoCreateUpdateDto.Title)
            {
                IsDone = todoTaskDtoCreateUpdateDto.IsDone,
            };
        }

        public static List<TodoTask> ToTodoTaskList(this IEnumerable<TodoTaskDtoCreateUpdateDto> todoTaskDtoCreateUpdateDtoList)
        {
            return todoTaskDtoCreateUpdateDtoList?.Select(i => i.ToTodoTask()).ToList() ?? new List<TodoTask>();
        }



    }
}
