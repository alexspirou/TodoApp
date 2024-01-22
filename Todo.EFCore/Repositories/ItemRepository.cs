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

    }
}
