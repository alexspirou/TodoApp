using Todo.Models.Entities;
using Todo.Shared.Requests;
using Todo.Shared.Responses;

namespace Todo.Application.ExtensionMethods
{
    public static class CategoryExetensions
    {

        public static CategoryResponseDto ToCategoryResponseDto(this Category todoEntry)
        {
            return new CategoryResponseDto(todoEntry.Id,
                    todoEntry.Name,
                    todoEntry.Date,
                    todoEntry?.TodoTasks?.ToTodoTaskResponseDtoList());
        }

        public static List<CategoryResponseDto> ToCategoryResponseDtoList(this IEnumerable<Category> category)
        {
            return category?.Select(i => i.ToCategoryResponseDto()).ToList() ?? new List<CategoryResponseDto>();
        }



        public static Category ToCategory(this CategoryCreateOrUpdateDto categoryCreateOrUpdateDto)
        {
            return new Category
            {
                Name = categoryCreateOrUpdateDto.Name ?? string.Empty,
            };
        }

        public static List<Category> ToCategoryList(this IEnumerable<CategoryCreateOrUpdateDto> categoryCreateOrUpdateDtoList)
        {
            return categoryCreateOrUpdateDtoList?.Select(i => i.ToCategory()).ToList() ?? new List<Category>();
        }
    }
}
