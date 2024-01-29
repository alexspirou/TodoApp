using Todo.Application.ExtensionMethods;
using Todo.Application.Services.Interfaces;
using Todo.EFCore.Repositories.Interfaces;
using Todo.Shared.Requests;
using Todo.Shared.Responses;

namespace Todo.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _toDoEntryRepository;

        public CategoryService(ICategoryRepository toDoEntryRepository)
        {
            _toDoEntryRepository = toDoEntryRepository;
        }

        public async Task<CategoryResponseDto> CreateCategoryAsync(CategoryCreateOrUpdateDto newTodoEntryRequest)
        {
            if (newTodoEntryRequest is null)
            {
                return new CategoryResponseDto();
            }

            var tempToDoEnty = newTodoEntryRequest.ToCategory();
            var newTodoEntry = await _toDoEntryRepository.CreateCategoryAsync(tempToDoEnty);

            return newTodoEntry.ToCategoryResponseDto();

        }
        public async Task<CategoryResponseDto> GetCategoryById(Guid id)
        {
            var result = await _toDoEntryRepository.GetByIdAsync(id);
            return result.ToCategoryResponseDto();
        }
        public async Task<List<CategoryResponseDto>> GetAllCategoriesAsync()
        {
            var result = await _toDoEntryRepository.GetAllCategoriesAsync();
            return result.ToCategoryResponseDtoList();
        }

        public async Task<CategoryResponseDto> UpdateCategoryAsync(string name, DateTime dateTime, CategoryCreateOrUpdateDto updatedTodoEntryDto)
        {
            var todoEntryForUpdate = await _toDoEntryRepository.GetCategoryByNameAndDateAsync(name, dateTime);

            if (todoEntryForUpdate == null)
            {
                return new CategoryResponseDto();
            }

            todoEntryForUpdate.Name = updatedTodoEntryDto.Name;
            await _toDoEntryRepository.UpdateAsync(todoEntryForUpdate);

            return todoEntryForUpdate.ToCategoryResponseDto();
        }

        public async Task<CategoryResponseDto> DeleteCategoryAsync(string name, DateTime dateTime)
        {
            var todoEntryForUpdate = await _toDoEntryRepository.GetCategoryByNameAndDateAsync(name, dateTime);

            if (todoEntryForUpdate == null)
            {
                return new CategoryResponseDto();
            }

            await _toDoEntryRepository.DeleteAsync(todoEntryForUpdate);

            return todoEntryForUpdate.ToCategoryResponseDto();

        }

        public async Task<CategoryResponseDto> DeleteCategoryAsync(Guid id)
        {
            var todoEntryForUpdate = await _toDoEntryRepository.GetByIdAsync(id);

            if (todoEntryForUpdate == null)
            {
                return new CategoryResponseDto();
            }

            await _toDoEntryRepository.DeleteAsync(todoEntryForUpdate);

            return todoEntryForUpdate.ToCategoryResponseDto();
        }


    }
}
