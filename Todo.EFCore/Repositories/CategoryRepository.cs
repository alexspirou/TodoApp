using Microsoft.EntityFrameworkCore;
using Todo.EFCore.Context;
using Todo.EFCore.Repositories.Common;
using Todo.EFCore.Repositories.Interfaces;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ToDoAppDbContext todoAppContext) : base(todoAppContext)
        {
        }

        public async Task<Category> CreateCategoryAsync(Category entry)
        {
            Context.TodoEntry.Add(entry);
            await SaveAsync();
            return entry;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var result = await Context.TodoEntry
                .AsNoTracking()
                .Include(t => t.TodoTasks).ThenInclude(i => i.Comment)
                .ToListAsync();

            return result;
        }       
        
        public async Task<Category> GetCategoryByNameAndDateAsync(string name, DateTime date)
        {

            var result = await Context.TodoEntry
                .Include(t => t.TodoTasks).ThenInclude(i => i.Comment)
                .Where(t => t.Name.Equals(name) && t.Date == date)
                .FirstOrDefaultAsync();

            return result ?? new Category();
        }

    }
}

