using Todo.EFCore.Repositories.Common;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<Category> CreateCategoryAsync(Category entry);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByNameAndDateAsync(string name, DateTime date);
    }
}
