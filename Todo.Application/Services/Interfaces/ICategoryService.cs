using Todo.Shared.Requests;
using Todo.Shared.Responses;

namespace Todo.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto> CreateCategoryAsync(CategoryCreateOrUpdateDto todoEntryDto);
        Task<List<CategoryResponseDto>> GetAllCategoriesAsync();
        Task<CategoryResponseDto> GetCategoryById(Guid id);
        Task<CategoryResponseDto> UpdateCategoryAsync(string name, DateTime dateTime, CategoryCreateOrUpdateDto todoEntryDto);
        Task<CategoryResponseDto> DeleteCategoryAsync(string name, DateTime dateTime);
        Task<CategoryResponseDto> DeleteCategoryAsync(Guid id);
    }
}
