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

        public async Task<TodoEntryResponseDto> CreateTodoEntryAsync(TodoEntryCreateOrUpdateDto newTodoEntryRequest)
        {
            if (newTodoEntryRequest is null)
            {
                return new TodoEntryResponseDto();
            }

            var tempToDoEnty = newTodoEntryRequest.ToTodoEntry();
            tempToDoEnty.Date = DateTime.Now;
            var newTodoEntry = await _toDoEntryRepository.CreateTodoEntryAsync(tempToDoEnty);

            return newTodoEntry.ToTodoEntryRequestDto();

        }
        public async Task<TodoEntryResponseDto> GetTodoEntryById(uint id)
        {
            var result = await _toDoEntryRepository.GetByIdAsync(id);
            return result.ToTodoEntryRequestDto();
        }
        public async Task<List<TodoEntryResponseDto>> GetAllTodoEntriesAsync()
        {
            var result = await _toDoEntryRepository.GetToDoEntriesAsync();
            return result.ToTodoEntryDtoList();
        }

        public async Task<TodoEntryResponseDto> UpdateTodoEntryAsync(string name, DateTime dateTime, TodoEntryCreateOrUpdateDto updatedTodoEntryDto)
        {
            var todoEntryForUpdate = await _toDoEntryRepository.GetTodoEntryByNameAndDateAsync(name, dateTime);

            if (todoEntryForUpdate == null)
            {
                return new TodoEntryResponseDto();
            }

            todoEntryForUpdate.Name = updatedTodoEntryDto.Name;
            await _toDoEntryRepository.UpdateAsync(todoEntryForUpdate);

            return todoEntryForUpdate.ToTodoEntryRequestDto();
        }

        public async Task<TodoEntryResponseDto> DeleteTodoEntryAsync(string name, DateTime dateTime)
        {
            var todoEntryForUpdate = await _toDoEntryRepository.GetTodoEntryByNameAndDateAsync(name, dateTime);

            if (todoEntryForUpdate == null)
            {
                return new TodoEntryResponseDto();
            }

            await _toDoEntryRepository.DeleteAsync(todoEntryForUpdate);

            return todoEntryForUpdate.ToTodoEntryRequestDto();

        }

        public async Task<TodoEntryResponseDto> DeleteTodoEntryAsync(uint id)
        {
            var todoEntryForUpdate = await _toDoEntryRepository.GetByIdAsync(id);

            if (todoEntryForUpdate == null)
            {
                return new TodoEntryResponseDto();
            }

            await _toDoEntryRepository.DeleteAsync(todoEntryForUpdate);

            return todoEntryForUpdate.ToTodoEntryRequestDto();
        }


    }
}
