using Todo.Application.ExtensionMethods;
using Todo.Application.Services.Interfaces;
using Todo.EFCore.Repositories;
using Todo.Shared.Responses;

namespace Todo.Application.Services
{
    internal class TodoTaskService : ITodoTaskService
    {
        private readonly ITodoTaskRepository _itemRepository;

        public TodoTaskService(ITodoTaskRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<TodoTaskResponseDto> CreateTodoTaskAsync(Guid toEntryId,TodoTaskDtoCreateUpdateDto newItemRequest)
        {
            if (newItemRequest is null)
            {
                return new TodoTaskResponseDto();
            }

            var tempItem = newItemRequest.ToTodoTask();
            tempItem.CategoryId = toEntryId;
            var newItem = await _itemRepository.CreateTodoTaskAsync(tempItem);

            return newItem.ToTodoTasksResponseDto();
        }

        public async Task<TodoTaskResponseDto> DeleteTodoTaskAsync(Guid id)
        {
            var itemToDelete = await _itemRepository.GetTodoTaskByIdAsync(id);

            if (itemToDelete == null)
            {
                return new TodoTaskResponseDto();
            }

            await _itemRepository.DeleteAsync(itemToDelete);

            return itemToDelete.ToTodoTasksResponseDto();
        }

        public async Task<List<TodoTaskResponseDto>> GetAllTodoTasksAsync()
        {
            var items = await _itemRepository.GetAllTodoTasks();
            return items.ToTodoTaskResponseDtoList();
        }

        public async Task<TodoTaskResponseDto> GetTodoTaskByIdAsync(Guid id)
        {
            var item = await _itemRepository.GetTodoTaskByIdAsync(id);

            return item.ToTodoTasksResponseDto();
        }

        public async Task<TodoTaskResponseDto> UpdateTodoTaskAsync(Guid id, TodoTaskDtoCreateUpdateDto newItemRequest)
        {
            var itemToUpdate = await _itemRepository.GetTodoTaskByIdAsync(id);

            if (itemToUpdate == null)
            {
                return new TodoTaskResponseDto();
            }
            // Update item
            itemToUpdate.Title = newItemRequest.Title;
            itemToUpdate.IsDone = newItemRequest.IsDone;

            await _itemRepository.UpdateAsync(itemToUpdate);

            return itemToUpdate.ToTodoTasksResponseDto();
        }
    }
}
