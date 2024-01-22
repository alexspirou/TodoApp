using Todo.Application.ExtensionMethods;
using Todo.EFCore.Repositories;
using Todo.Models.Entities;
using ToDo.Shared.Common;
using ToDo.Shared.Data;
using ToDo.Shared.Requests.UpdateTodoEntry;

namespace Todo.Application.Services
{
    public class TodoManager : ITodoManager
    {
        private readonly IToDoEntryRepository _toDoEntryRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ICommentRepository _commentRepository;

        public TodoManager(IToDoEntryRepository toDoEntryRepository, IItemRepository itemRepository, ICommentRepository commentRepository)
        {
            _toDoEntryRepository = toDoEntryRepository;
            _itemRepository = itemRepository;
            _commentRepository = commentRepository;
        }


        // This service will have the logic of todo app, read write in db

        public Task<TodoEntryDto> GetTodoEntries()
        {
            // Get Todo entries



            throw new NotImplementedException();
        }

        public async Task<TodoEntryDto> CreateTodoEntryAsync(TodoEntryDto? todoEntryDto)
        {

            if (todoEntryDto is null)
            {
                return new TodoEntryDto();
            }

            todoEntryDto.DateTime = DateTime.UtcNow;

            var todoEntry = await _toDoEntryRepository.CreateToDoEntryAsync(todoEntryDto.ToTodoEntry());

            // Write items in db
            if (todoEntryDto.Items is not null)
            {

                foreach (var item in todoEntryDto.Items)
                {
                    if (item is null)
                    {
                        continue;
                    }

                    var tempItem = new Item()
                    {
                        Title = item.Title,
                        Comment = item?.Comment?.ToCommentList(),
                        IsDone = item.IsDone,
                        ToDoEntryId = todoEntry.Id
                    };

                    var newItem = await _itemRepository.CreateItemAsync(tempItem);


                    // Write Comments in db

                    if (item.Comment is not null)
                    {
                        if (item.Comment.Count <= 0)
                        {
                            continue;
                        }
                        foreach (var comment in item.Comment)
                        {
                            var tempComment = new Comment()
                            {

                                Content = comment.Content,
                                Date = comment.Date,
                                ItemId = newItem.Id,
                            };

                            var newComment = await _commentRepository.CreateCommentAsync(tempComment);
                        }
                    }

                }

            }

            return todoEntry.ToTodoEtryDto();

        }

        public async Task<List<TodoEntryDto>> GetAllEntriesAsync()
        {
            var result = await _toDoEntryRepository.GetToDoEntries();
            return result.ToTodoEntryDtoList();
        }

        public async Task<TodoEntryDto> UpdateEntry(string name, DateTime dateTime, TodoEntryUpdateDto updatedTodoEntryDto)
        {
            var todoEntryForUpdate = await _toDoEntryRepository.GetTodoEntryByNameAndDate(name, dateTime);

            if (todoEntryForUpdate == null)
            {
                return new TodoEntryDto();
            }

            todoEntryForUpdate.Name = updatedTodoEntryDto.Name;
            todoEntryForUpdate.Item = updatedTodoEntryDto?.Items?.ToItemList();

            await _toDoEntryRepository.UpdateAsync(todoEntryForUpdate);

            return todoEntryForUpdate.ToTodoEtryDto();
        }

        public async Task<TodoEntryDto> DeleteEntry(TodoEntryDto todoEntryDto)
        {
            throw new NotImplementedException();
        }
    }
}
