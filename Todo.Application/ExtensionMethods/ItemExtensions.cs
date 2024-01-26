using Todo.Models.Entities;
using ToDo.Shared.Responses;

namespace Todo.Application.ExtensionMethods
{
    public static class ItemExtensions
    {
        /// <summary>
        /// From Item to ItemRequestDto
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemResponseDto ToItemRequestDto(this Item item)
        {
            return new ItemResponseDto
            {
                Id = item.Id,   
                Date = item.Date,
                IsDone = item.IsDone,
                Title = item.Title,
                Comment = item?.Comment?.ToCommentRequestDtoList()
            };
        }
        /// <summary>
        /// From ItemList to ItemRequestDtoList
        /// </summary>
        /// <param name="itemList"></param>
        /// <returns></returns>
        public static List<ItemResponseDto> ToItemRequestDtoList(this IEnumerable<Item> itemList)
        {
            return itemList?.Select(i => i.ToItemRequestDto()).ToList() ?? new List<ItemResponseDto>();
        }


        /// <summary>
        /// From ItemDtoUpdateDto to Item
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        public static Item ToItem(this ItemDtoCreateUpdateDto itemDto)
        {
            return new Item
            {
                Title = itemDto.Title,
                IsDone = itemDto.IsDone,
            };
        }

        /// <summary>
        /// From ItemDtoUpdateDtoList to ItemList
        /// </summary>
        /// <param name="itemDtoList"></param>
        /// <returns></returns>
        public static List<Item> ToItemList(this IEnumerable<ItemDtoCreateUpdateDto> itemDtoList)
        {
            return itemDtoList?.Select(i => i.ToItem()).ToList() ?? new List<Item>();
        }

    }
}
