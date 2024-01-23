using System;
using Todo.Application.ExtensionMethods;
using Todo.EFCore.Repositories;
using ToDo.Shared.Requests;
using ToDo.Shared.Responses;

namespace Todo.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly IToDoEntryRepository _toDoEntryRepository;

        public TodoService(IToDoEntryRepository toDoEntryRepository)
        {
            _toDoEntryRepository = toDoEntryRepository;
        }

        public async Task<TodoEntryRequestDto> CreateTodoEntryAsync(TodoEntryCreateOrUpdateDto? todoEntryDto)
        {
            if (todoEntryDto is null)
            {
                return new TodoEntryRequestDto();
            }

            var tempToDoEnty = todoEntryDto.ToTodoEntry();
            tempToDoEnty.Date = DateTime.Now;
            var todoEntry = await _toDoEntryRepository.CreateToDoEntryAsync(tempToDoEnty);

            return todoEntry.ToTodoEntryRequestDto();

        }
        public async Task<TodoEntryRequestDto> GetTodoEntryById(uint id)
        {
            var result = await _toDoEntryRepository.GetByIdAsync(id);
            return result.ToTodoEntryRequestDto();
        }
        public async Task<List<TodoEntryRequestDto>> GetAllTodoEntriesAsync()
        {
            var result = await _toDoEntryRepository.GetToDoEntries();
            return result.ToTodoEntryDtoList();
        }

        public async Task<TodoEntryRequestDto> UpdateTodoEntryAsync(string name, DateTime dateTime, TodoEntryCreateOrUpdateDto updatedTodoEntryDto)
        {
            var todoEntryForUpdate = await _toDoEntryRepository.GetTodoEntryByNameAndDate(name, dateTime);

            if (todoEntryForUpdate == null)
            {
                return new TodoEntryRequestDto();
            }

            todoEntryForUpdate.Name = updatedTodoEntryDto.Name;
            await _toDoEntryRepository.UpdateAsync(todoEntryForUpdate);

            return todoEntryForUpdate.ToTodoEntryRequestDto();
        }

        public async Task<TodoEntryRequestDto> DeleteTodoEntryAsync(string name, DateTime dateTime)
        {
            var todoEntryForUpdate = await _toDoEntryRepository.GetTodoEntryByNameAndDate(name, dateTime);

            if (todoEntryForUpdate == null)
            {
                return new TodoEntryRequestDto();
            }

            await _toDoEntryRepository.DeleteAsync(todoEntryForUpdate);

            return todoEntryForUpdate.ToTodoEntryRequestDto();

        }

        public async Task<TodoEntryRequestDto> DeleteTodoEntryAsync(uint id)
        {
            var todoEntryForUpdate = await _toDoEntryRepository.GetByIdAsync(id);

            if (todoEntryForUpdate == null)
            {
                return new TodoEntryRequestDto();
            }

            await _toDoEntryRepository.DeleteAsync(todoEntryForUpdate);

            return todoEntryForUpdate.ToTodoEntryRequestDto();
        }


    }
}
