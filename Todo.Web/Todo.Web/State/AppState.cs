using Microsoft.AspNetCore.Components;
using Todo.Shared.Responses;
using Todo.Web.Services.Interfaces;

namespace Todo.Web.State
{

    public class AppState
    {
        public AppState(ITodoMangerService todoMangerService)
        {
            _todoMangerService = todoMangerService;
        }
        private readonly ITodoMangerService _todoMangerService;

        public delegate void CategoryChanged();
        public event CategoryChanged? CategoryChangedEvent;

        public List<CategoryResponseDto>? Categories { get; set; }

        public void RaiseCategoryChangedEvent()
        {
            CategoryChangedEvent?.Invoke();
        }

        public async Task RefreshCategories()
        {
            Categories = await _todoMangerService.GetAllCategories();
        }

        public void RemoveCategory(Guid categoryId) 
        {
            var categoryToRemove = Categories?.FirstOrDefault(category => category.Id == categoryId);

            if (categoryToRemove != null)
            {
                Categories?.Remove(categoryToRemove);
            }
        }
    }
}
