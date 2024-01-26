using Microsoft.EntityFrameworkCore;
using Todo.EFCore.Context;
using Todo.EFCore.Repositories.Common;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(ToDoAppDbContext todoAppContext) : base(todoAppContext)
        {
        }

        public async Task<Item> CreateItemAsync(Item item)
        {
            Context.Item.Add(item);
            await SaveAsync();
            return item;
        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            var result =
                await Context.Item
                    .AsNoTracking()
                    .Include(i => i.Comment)
                    .ToListAsync();

            return result;
        }

        public async Task<Item> GetItemByIdAsync(uint id)
        {
            var result =
               await Context.Item
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return result ?? new Item();
        }
    }
}
