using Todo.Models.Entities;
using ToDo.Shared.Common;
using ToDo.Shared.Requests.UpdateTodoEntry;

namespace Todo.Application.ExtensionMethods
{
    public static class TodoEntryExetensions
    {

        #region TodoEtryDto
        /// <summary>
        ///  From TodoEntry to TodoEntryDto
        /// </summary>
        /// <param name="todoEntry"></param>
        /// <returns></returns>
        public static TodoEntryDto ToTodoEtryDto(this TodoEntry todoEntry)
        {
            return new TodoEntryDto
            {
                DateTime = todoEntry.Date,
                Name = todoEntry.Name,
                Items = todoEntry?.Item?.ToItemDtoList(),
                
            };
        }
        /// <summary>
        ///  From TodoEntryList to TodoEntryDtoList
        /// </summary>
        /// <param name="todoEntryDtoList"></param>
        /// <returns></returns>
        public static List<TodoEntryDto> ToTodoEntryDtoList(this IEnumerable<TodoEntry> todoEntryDtoList)
        {
            return todoEntryDtoList?.Select(i => i.ToTodoEtryDto()).ToList() ?? new List<TodoEntryDto>();
        }

        #endregion

        #region TodoEntryUpdateDto
        /// <summary>
        /// From TodoEntry to TodoEntryUpdateDto
        /// </summary>
        /// <param name="todoEntry"></param>
        /// <returns></returns>
        public static TodoEntryUpdateDto ToTodoEntryUpdateDto(this TodoEntry todoEntry)
        {
            return new TodoEntryUpdateDto
            {
                Name = todoEntry.Name,
                Items = todoEntry?.Item?.ToItemUpdateDtoList(),
            };
        }

        /// <summary>
        /// From TodoEntryList to TodoEntryUpdateDtoList
        /// </summary>
        /// <param name="todoEntries"></param>
        /// <returns></returns>
        public static List<TodoEntryUpdateDto> ToTodoEntryUpdateDtoList(this IEnumerable<TodoEntry> todoEntries)
        {
            return todoEntries?.Select(i => i.ToTodoEntryUpdateDto()).ToList() ?? new List<TodoEntryUpdateDto>();
        }

        #endregion

        #region TodoEntry
        /// <summary>
        /// From TodoEntryDto to TodoEntry
        /// </summary>
        /// <param name="todoEntry"></param>
        /// <returns></returns>
        public static TodoEntry ToTodoEntry(this TodoEntryDto todoEntry)
        {
            return new TodoEntry
            {
                Date = todoEntry.DateTime,
                Name = todoEntry.Name ?? string.Empty,
                Item = todoEntry?.Items?.ToItemList()
            };
        }
        /// <summary>
        ///  From TodoEntryDtoList to TodoEntryList
        /// </summary>
        /// <param name="todoEntries"></param>
        /// <returns></returns>
        public static List<TodoEntry> ToTodoEntryList(this IEnumerable<TodoEntryDto> todoEntries)
        {
            return todoEntries?.Select(i => i.ToTodoEntry()).ToList() ?? new List<TodoEntry>();
        }
        /// <summary>
        /// From TodoEntryUpdateDto to TodoEntry
        /// </summary>
        /// <param name="todoEntry"></param>
        /// <returns></returns>
        public static TodoEntry ToTodoEntry(this TodoEntryUpdateDto todoEntry)
        {
            return new TodoEntry
            {
                Name = todoEntry.Name ?? string.Empty,
                Item = todoEntry?.Items?.ToItemList()
            };
        }
        /// <summary>
        /// From TodoEntryUpdateDtoList to TodoEntryList 
        /// </summary>
        /// <param name="todoEntries"></param>
        /// <returns></returns>
        public static List<TodoEntry> ToTodoEntryList(this IEnumerable<TodoEntryUpdateDto> todoEntries)
        {
            return todoEntries?.Select(i => i.ToTodoEntry()).ToList() ?? new List<TodoEntry>();
        }
        #endregion
    }
}
