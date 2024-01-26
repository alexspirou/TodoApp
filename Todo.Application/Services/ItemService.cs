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

        public async Task<ItemResponseDto> CreateItemAsync(uint toEntryId,ItemDtoCreateUpdateDto newItemRequest)
        {
            if (newItemRequest is null)
            {
                return new ItemResponseDto();
            }

            var tempItem = newItemRequest.ToItem();
            tempItem.Date = DateTime.Now;
            tempItem.ToDoEntryId = toEntryId;
            var newItem = await _itemRepository.CreateItemAsync(tempItem);

            return newItem.ToItemRequestDto();
        }

        public async Task<ItemResponseDto> DeleteItemAsync(uint id)
        {
            var itemToDelete = await _itemRepository.GetItemByIdAsync(id);

            if (itemToDelete == null)
            {
                return new ItemResponseDto();
            }

            await _itemRepository.DeleteAsync(itemToDelete);

            return itemToDelete.ToItemRequestDto();
        }

        public async Task<List<ItemResponseDto>> GetAllItemsAsync()
        {
            var items = await _itemRepository.GetAllItemsAsync();
            return items.ToItemRequestDtoList();
        }

        public async Task<ItemResponseDto> GetItemByIdAsync(uint id)
        {
            var item = await _itemRepository.GetItemByIdAsync(id);

            return item.ToItemRequestDto();
        }

        public async Task<ItemResponseDto> UpdateItemAsync(uint id, ItemDtoCreateUpdateDto newItemRequest)
        {
            var itemToUpdate = await _itemRepository.GetItemByIdAsync(id);

            if (itemToUpdate == null)
            {
                return new ItemResponseDto();
            }
            // Update item
            itemToUpdate.Title = newItemRequest.Title;
            itemToUpdate.IsDone = newItemRequest.IsDone;

            await _itemRepository.UpdateAsync(itemToUpdate);

            return itemToUpdate.ToItemRequestDto();
        }
    }
}
