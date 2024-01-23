using System;
using Todo.Application.ExtensionMethods;
using Todo.EFCore.Repositories;
using ToDo.Shared.Responses;

namespace Todo.Application.Services
{
    internal class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ItemRequestDto> CreateItemAsync(uint toEntryId,ItemDtoCreateUpdateDto newItem)
        {
            if (newItem is null)
            {
                return new ItemRequestDto();
            }

            var tempItem = newItem.ToItem ();
            tempItem.Date = DateTime.Now;
            tempItem.ToDoEntryId = toEntryId;
            var item = await _itemRepository.CreateItemAsync(tempItem);

            return item.ToItemRequestDto();
        }

        public async Task<ItemRequestDto> DeleteItem(uint id)
        {
            var itemForDelete = await _itemRepository.GetItemById(id);

            if (itemForDelete == null)
            {
                return new ItemRequestDto();
            }

            await _itemRepository.DeleteAsync(itemForDelete);

            return itemForDelete.ToItemRequestDto();
        }

        public async Task<List<ItemRequestDto>> GetAllItems()
        {
            var items = await _itemRepository.GetAllItems();
            return items.ToItemRequestDtoList();
        }

        public async Task<ItemRequestDto> GetItemById(uint id)
        {
            var item = await _itemRepository.GetItemById(id);

            return item.ToItemRequestDto();
        }

        public async Task<ItemRequestDto> UpdateItem(uint id, ItemDtoCreateUpdateDto newItem)
        {
            var itemForUdpate = await _itemRepository.GetItemById(id);

            if (itemForUdpate == null)
            {
                return new ItemRequestDto();
            }
            // Update item
            itemForUdpate.Title = newItem.Title;
            itemForUdpate.IsDone = newItem.IsDone;

            await _itemRepository.UpdateAsync(itemForUdpate);

            return itemForUdpate.ToItemRequestDto();
        }
    }
}
