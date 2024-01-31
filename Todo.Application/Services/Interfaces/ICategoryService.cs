using Todo.Shared.Requests;
using Todo.Shared.Responses;

namespace Todo.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto> CreateCategoryAsync(CategoryCreateOrUpdateDto todoEntryDto, CancellationToken cancellationToken);
        Task<List<CategoryResponseDto>> GetAllCategoriesAsync(CancellationToken cancellationToken);
        Task<CategoryResponseDto> GetCategoryById(Guid id, CancellationToken cancellationToken);
        Task<CategoryResponseDto> UpdateCategoryAsync(string name, DateTime dateTime, CategoryCreateOrUpdateDto todoEntryDto, CancellationToken cancellationToken);
        Task<CategoryResponseDto> DeleteCategoryAsync(string name, DateTime dateTime, CancellationToken cancellationToken);
        Task<CategoryResponseDto> DeleteCategoryAsync(Guid id, CancellationToken cancellationToken);
    }
}
