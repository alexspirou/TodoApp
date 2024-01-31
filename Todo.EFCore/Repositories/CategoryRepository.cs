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

        public async Task<Category> CreateCategoryAsync(Category entry, CancellationToken cancellationToken)
        {
            Context.Category.Add(entry);
            await SaveAsync(cancellationToken);
            return entry;
        }

        public async Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            var result = await Context.Category
                .AsNoTracking()
                .Include(t => t.TodoTasks).ThenInclude(i => i.Comment)
                .ToListAsync(cancellationToken);

            return result;
        }       
        
        public async Task<Category> GetCategoryByNameAndDateAsync(string name, DateTime date, CancellationToken cancellationToken)
        {

            var result = await Context.Category
                .Include(t => t.TodoTasks).ThenInclude(i => i.Comment)
                .Where(t => t.Name.Equals(name) && t.Date == date)
                .FirstOrDefaultAsync(cancellationToken);

            return result ?? new Category();
        }

    }
}

