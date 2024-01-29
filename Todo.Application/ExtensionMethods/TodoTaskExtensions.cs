using Todo.Models.Entities;
using Todo.Shared.Responses;

namespace Todo.Application.ExtensionMethods
{
    public static class TodoTaskExtensions
    {

        public static TodoTaskResponseDto ToTodoTasksResponseDto(this TodoTask todoTask)
        {
            return new TodoTaskResponseDto
            {
                Id = todoTask.Id,   
                Date = todoTask.Date,
                IsDone = todoTask.IsDone,
                Title = todoTask.Title,
                Comment = todoTask?.Comment?.ToCommentRequestDtoList()
            };
        }

        public static List<TodoTaskResponseDto> ToTodoTaskResponseDtoList(this IEnumerable<TodoTask> todoTaskList)
        {
            return todoTaskList?.Select(i => i.ToTodoTasksResponseDto()).ToList() ?? new List<TodoTaskResponseDto>();
        }


        public static TodoTask ToTodoTask(this TodoTaskDtoCreateUpdateDto todoTaskDtoCreateUpdateDto)
        {
            return new TodoTask
            {
                Title = todoTaskDtoCreateUpdateDto.Title,
                IsDone = todoTaskDtoCreateUpdateDto.IsDone,
            };
        }

        public static List<TodoTask> ToTodoTaskList(this IEnumerable<TodoTaskDtoCreateUpdateDto> todoTaskDtoCreateUpdateDtoList)
        {
            return todoTaskDtoCreateUpdateDtoList?.Select(i => i.ToTodoTask()).ToList() ?? new List<TodoTask>();
        }

    }
}
