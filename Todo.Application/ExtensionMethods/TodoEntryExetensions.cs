using Todo.Models.Entities;
using ToDo.Shared.Requests;
using ToDo.Shared.Responses;

namespace Todo.Application.ExtensionMethods
{
    public static class TodoEntryExetensions
    {

        /// <summary>
        ///  From TodoEntry to TodoEntryDto
        /// </summary>
        /// <param name="todoEntry"></param>
        /// <returns></returns>
        public static TodoEntryResponseDto ToTodoEntryRequestDto(this TodoEntry todoEntry)
        {
            return new TodoEntryResponseDto
            {
                Id = todoEntry.Id,  
                DateTime = todoEntry.Date,
                Name = todoEntry.Name,
                Items = todoEntry?.Item?.ToItemRequestDtoList(),
                
            };
        }
        /// <summary>
        ///  From TodoEntryList to TodoEntryDtoList
        /// </summary>
        /// <param name="todoEntryDtoList"></param>
        /// <returns></returns>
        public static List<TodoEntryResponseDto> ToTodoEntryDtoList(this IEnumerable<TodoEntry> todoEntryDtoList)
        {
            return todoEntryDtoList?.Select(i => i.ToTodoEntryRequestDto()).ToList() ?? new List<TodoEntryResponseDto>();
        }


        /// <summary>
        /// From TodoEntryUpdateDto to TodoEntry
        /// </summary>
        /// <param name="todoEntry"></param>
        /// <returns></returns>
        public static TodoEntry ToTodoEntry(this TodoEntryCreateOrUpdateDto todoEntry)
        {
            return new TodoEntry
            {
                Name = todoEntry.Name ?? string.Empty,
            };
        }
        /// <summary>
        /// From TodoEntryUpdateDtoList to TodoEntryList 
        /// </summary>
        /// <param name="todoEntries"></param>
        /// <returns></returns>
        public static List<TodoEntry> ToTodoEntryList(this IEnumerable<TodoEntryCreateOrUpdateDto> todoEntries)
        {
            return todoEntries?.Select(i => i.ToTodoEntry()).ToList() ?? new List<TodoEntry>();
        }
    }
}
