﻿using Todo.EFCore.Repositories.Common;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
        Task<Item> CreateItemAsync(Item comment);
        Task<Item> GetItemById(uint id);
        Task<List<Item>> GetAllItems();
    }
}
