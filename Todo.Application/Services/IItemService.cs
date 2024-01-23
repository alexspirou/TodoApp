using ToDo.Shared.Requests;
using ToDo.Shared.Responses;

namespace Todo.Application.Services
{
    public interface IItemService
    {
        Task<ItemRequestDto> CreateItemAsync(uint toEntryId, ItemDtoCreateUpdateDto todoEntryDto);
        Task<List<ItemRequestDto>> GetAllItems();
        Task<ItemRequestDto> GetItemById(uint id);
        Task<ItemRequestDto> UpdateItem(uint id, ItemDtoCreateUpdateDto todoEntryDto);
        Task<ItemRequestDto> DeleteItem(uint id);
    }
}
