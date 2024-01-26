using ToDo.Shared.Requests;
using ToDo.Shared.Responses;

namespace Todo.Application.Services
{
    public interface IItemService
    {
        Task<ItemRequestDto> CreateItemAsync(uint toEntryId, ItemDtoCreateUpdateDto todoEntryDto);
        Task<List<ItemRequestDto>> GetAllItemsAsync();
        Task<ItemRequestDto> GetItemById(uint id);
        Task<ItemRequestDto> UpdateItemAsync(uint id, ItemDtoCreateUpdateDto todoEntryDto);
        Task<ItemRequestDto> DeleteItemAsync(uint id);
    }
}
