using ToDo.Shared.Requests;
using ToDo.Shared.Responses;

namespace Todo.Application.Services
{
    public interface IItemService
    {
        Task<ItemResponseDto> CreateItemAsync(uint toEntryId, ItemDtoCreateUpdateDto todoEntryDto);
        Task<List<ItemResponseDto>> GetAllItemsAsync();
        Task<ItemResponseDto> GetItemByIdAsync(uint id);
        Task<ItemResponseDto> UpdateItemAsync(uint id, ItemDtoCreateUpdateDto todoEntryDto);
        Task<ItemResponseDto> DeleteItemAsync(uint id);
    }
}
