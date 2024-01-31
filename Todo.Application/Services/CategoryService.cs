using Todo.Application.ExtensionMethods;
using Todo.Application.Services.Interfaces;
using Todo.EFCore.Repositories.Interfaces;
using Todo.Shared.Requests;
using Todo.Shared.Responses;

namespace Todo.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponseDto> CreateCategoryAsync(CategoryCreateOrUpdateDto newTodoEntryRequest, CancellationToken cancellationToken = default)
        {
 

            var tempCategory = newTodoEntryRequest.ToCategory();
            var newCategory = await _categoryRepository.CreateCategoryAsync(tempCategory,cancellationToken);

            return newCategory.ToCategoryResponseDto();

        }
        public async Task<CategoryResponseDto> GetCategoryById(Guid id, CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.GetByIdAsync(id,cancellationToken);
            return category.ToCategoryResponseDto();
        }
        public async Task<List<CategoryResponseDto>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.GetAllCategoriesAsync(cancellationToken);
            return category.ToCategoryResponseDtoList();
        }

        public async Task<CategoryResponseDto> UpdateCategoryAsync(string name, DateTime dateTime, CategoryCreateOrUpdateDto updatedCategory, CancellationToken cancellationToken = default)
        {
            var categoryForUpdate = await _categoryRepository.GetCategoryByNameAndDateAsync(name, dateTime,cancellationToken);

            if (categoryForUpdate == null)
            {
               throw new NullReferenceException(nameof(categoryForUpdate));
            }

            categoryForUpdate.Name = updatedCategory.Name;
            await _categoryRepository.UpdateAsync(categoryForUpdate,cancellationToken);

            return categoryForUpdate.ToCategoryResponseDto();
        }

        public async Task<CategoryResponseDto> DeleteCategoryAsync(string name, DateTime dateTime, CancellationToken cancellationToken = default)
        {
            var categoryToDelete = await _categoryRepository.GetCategoryByNameAndDateAsync(name, dateTime,cancellationToken);

            if (categoryToDelete == null)
            {
                throw new NullReferenceException(nameof(categoryToDelete));
            }

            await _categoryRepository.DeleteAsync(categoryToDelete,cancellationToken);

            return categoryToDelete.ToCategoryResponseDto();

        }

        public async Task<CategoryResponseDto> DeleteCategoryAsync(Guid id,CancellationToken cancellationToken = default)
        {
            var categoryToDelete = await _categoryRepository.GetByIdAsync(id,cancellationToken);

            if (categoryToDelete == null)
            {
                throw new NullReferenceException(nameof(categoryToDelete));
            }

            await _categoryRepository.DeleteAsync(categoryToDelete,cancellationToken);

            return categoryToDelete.ToCategoryResponseDto();
        }


    }
}
