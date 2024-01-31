using Todo.Application.ExtensionMethods;
using Todo.Application.Services.Interfaces;
using Todo.EFCore.Repositories;
using Todo.Shared.Exceptions;
using Todo.Shared.Responses;

namespace Todo.Application.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public TodoTaskService(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public async Task MarkTodoTaskAsCompleted(Guid id, CancellationToken cancellationToken = default)
        {
            var todoTaskForStatusUpdate = await _todoTaskRepository.GetTodoTaskByIdAsync(id, cancellationToken);

            if (todoTaskForStatusUpdate == null)
            {
                throw new NullReferenceException(nameof(todoTaskForStatusUpdate));
            }    
            if(todoTaskForStatusUpdate.IsDone is true)
            {
                throw new TodoTaskException($"Cannot update status for task {todoTaskForStatusUpdate.Title} (ID: {todoTaskForStatusUpdate.Id}) as it is already marked as completed.");
            }

            todoTaskForStatusUpdate.IsDone = true;

            await _todoTaskRepository.UpdateAsync(todoTaskForStatusUpdate, cancellationToken);


        }

        public async Task<TodoTaskResponseDto> CreateTodoTaskAsync(Guid toEntryId,TodoTaskDtoCreateUpdateDto newTodoTaskRequest, CancellationToken cancellationToken = default)
        {
            if (newTodoTaskRequest is null)
            {
                throw new NullReferenceException(nameof(newTodoTaskRequest));   
            }

            var tempTodoTask = newTodoTaskRequest.ToTodoTask();
            tempTodoTask.CategoryId = toEntryId;
            var newTodoTask = await _todoTaskRepository.CreateTodoTaskAsync(tempTodoTask, cancellationToken);

            return newTodoTask.ToTodoTasksResponseDto();
        }

        public async Task<TodoTaskResponseDto> DeleteTodoTaskAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoTaskToDelete = await _todoTaskRepository.GetTodoTaskByIdAsync(id,cancellationToken);

            if (todoTaskToDelete == null)
            {
                throw new NullReferenceException(nameof(todoTaskToDelete));
            }

            await _todoTaskRepository.DeleteAsync(todoTaskToDelete, cancellationToken);

            return todoTaskToDelete.ToTodoTasksResponseDto();
        }

        public async Task<List<TodoTaskResponseDto>> GetAllTodoTasksAsync(CancellationToken cancellationToken = default)
        {
            var todoTasks = await _todoTaskRepository.GetAllTodoTasks(cancellationToken);
            return todoTasks.ToTodoTaskResponseDtoList();
        }

        public async Task<TodoTaskResponseDto> GetTodoTaskByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoTask = await _todoTaskRepository.GetTodoTaskByIdAsync(id, cancellationToken);

            return todoTask.ToTodoTasksResponseDto();
        }

        public async Task<TodoTaskResponseDto> UpdateTodoTaskAsync(Guid id, TodoTaskDtoCreateUpdateDto newTodoTaskRequest, CancellationToken cancellationToken = default)
        {

            if(newTodoTaskRequest is null)
            {
                throw new ArgumentNullException(nameof(newTodoTaskRequest));
            }
            var todoTaskForUpdate = await _todoTaskRepository.GetTodoTaskByIdAsync(id,cancellationToken);

            if (todoTaskForUpdate == null)
            {
                throw new NullReferenceException(nameof(todoTaskForUpdate));
            }
            // Update item
            todoTaskForUpdate.Title = newTodoTaskRequest.Title;
            todoTaskForUpdate.IsDone = newTodoTaskRequest.IsDone;

            await _todoTaskRepository.UpdateAsync(todoTaskForUpdate, cancellationToken);

            return todoTaskForUpdate.ToTodoTasksResponseDto();
        }
    }
}
