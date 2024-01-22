using Todo.Models.Entities;
using ToDo.Shared.Data;

namespace Todo.Application.ExtensionMethods
{
    public static class ItemExtensions
    {
        #region ItemDtos
        /// <summary>
        /// From Item to ItemDto
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemDto ToItemDto(this Item item)
        {
            return new ItemDto
            {
                Date = item.Date,
                IsDone = item.IsDone,
                Title = item.Title,
                Comment = item?.Comment?.ToCommentDtoList()
            };
        }
        /// <summary>
        /// From ItemList to ItemDtoList
        /// </summary>
        /// <param name="itemList"></param>
        /// <returns></returns>
        public static List<ItemDto> ToItemDtoList(this IEnumerable<Item> itemList)
        {
            return itemList?.Select(i => i.ToItemDto()).ToList() ?? new List<ItemDto>();
        }
        /// <summary>
        /// From Item to ItemDtoUpdateDto
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemDtoUpdateDto ToItemUpdateDto(this Item item)
        {
            return new ItemDtoUpdateDto
            {
                IsDone = item.IsDone,
                Title = item.Title,
                Comments = item?.Comment?.ToCommentUpdateDtoList()
            };
        }
        /// <summary>
        /// From ItemList to ItemDtoUpdateDtoList
        /// </summary>
        /// <param name="itemList"></param>
        /// <returns></returns>
        public static List<ItemDtoUpdateDto> ToItemUpdateDtoList(this IEnumerable<Item> itemList)
        {
            return itemList?.Select(i => i.ToItemUpdateDto()).ToList() ?? new List<ItemDtoUpdateDto>();
        }


        #endregion

        #region Item
        /// <summary>
        /// From ItemDto to List
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        public static Item ToItem(this ItemDto itemDto)
        {
            return new Item
            {
                Title = itemDto.Title,
                Date = itemDto.Date,    
                IsDone = itemDto.IsDone,
                Comment = itemDto?.Comment?.ToCommentList()
            };
        }

        /// <summary>
        /// From ItemDtoUpdateDto to Item
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        public static Item ToItem(this ItemDtoUpdateDto itemDto)
        {
            return new Item
            {
                Title = itemDto.Title,
                IsDone = itemDto.IsDone,

            };
        }
        /// <summary>
        /// From ItemDtoList to ItemList
        /// </summary>
        /// <param name="itemDtoList"></param>
        /// <returns></returns>
        public static List<Item> ToItemList(this IEnumerable<ItemDto> itemDtoList)
        {
            return itemDtoList?.Select(i => i.ToItem()).ToList() ?? new List<Item>();
        }
        /// <summary>
        /// From ItemDtoUpdateDtoList to ItemList
        /// </summary>
        /// <param name="itemDtoList"></param>
        /// <returns></returns>
        public static List<Item> ToItemList(this IEnumerable<ItemDtoUpdateDto> itemDtoList)
        {
            return itemDtoList?.Select(i => i.ToItem()).ToList() ?? new List<Item>();
        }



        #endregion
    }
}
