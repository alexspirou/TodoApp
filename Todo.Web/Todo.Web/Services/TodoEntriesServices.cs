using Todo.Shared.Requests;
using Todo.Shared.Responses;
using Todo.Web.Services.Interfaces;

namespace Todo.Web.Services
{

    public class TodoEntriesServices : ITodoEntriesService
    {
        private readonly HttpClient _httpClient;
        private readonly string _host = "https://localhost:7055";
        public TodoEntriesServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddNewCommentAsync(Guid todoTaskId, CommentCreateOrUpdateDto comment, CancellationToken cancellationToken = default)
        {
            var apiCall = $@"{_host}/api/Comment/v1/CreateComment?todoTaskId={todoTaskId}";

            await _httpClient.PostAsJsonAsync<CommentCreateOrUpdateDto>(apiCall, comment, cancellationToken);

        }

        public async Task<Guid> AddNewTaskAsync(Guid categoryId, TodoTaskDtoCreateUpdateDto todoTask, CancellationToken cancellationToken = default)
        {
            var apiCall = $@"{_host}/api/TodoTask/v1/CreateTodoTask?categoryId={categoryId}";

            var newTask = await _httpClient.PostAsJsonAsync<TodoTaskDtoCreateUpdateDto>(apiCall, todoTask, cancellationToken);

            var result = await newTask.Content.ReadFromJsonAsync<TodoTaskResponseDto>();
            if (result == null)
            {
                throw new NullReferenceException(nameof(result));
            }
            return result.Id;
        }

        public async Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var apiCall = $@"{_host}/api/Category/v1/DeleteCategoryById?id={id}";
            await _httpClient.DeleteFromJsonAsync<CategoryResponseDto>(apiCall, cancellationToken);
        }

        public async Task DeleteTodoTaskAsync(TodoTaskResponseDto todoTask, CancellationToken cancellationToken = default)
        {
            var apiCall = $@"https://localhost:7055/api/TodoTask/v1/DeleteTodoTask?id={todoTask.Id}";
            await _httpClient.DeleteFromJsonAsync<TodoTaskResponseDto>(apiCall, cancellationToken);

        }

        public async Task<List<CategoryResponseDto>> GetAllTodoEntriesAsync(CancellationToken cancellationToken = default)
        {
            var categories = new List<CategoryResponseDto>();
            try
            {
                var apiCall = @"https://localhost:7055/api/Category/v1/GetAllCategories";
                categories = await _httpClient.GetFromJsonAsync<List<CategoryResponseDto>>(apiCall, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return categories ?? new List<CategoryResponseDto>();
        }

        public async Task<CategoryResponseDto> GetCategoryByIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
        {

            var apiCall = $@"{_host}/api/Category/v1/GetCategoryById?id={categoryId}";
            var catgory = await _httpClient.GetFromJsonAsync<CategoryResponseDto>(apiCall, cancellationToken);

            return catgory;
        }

        public async Task<List<TodoTaskResponseDto>> GetTodoTasksByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
        {
            var apiCall = $@"{_host}/api/TodoTask/v1/GetTodoTasksByCategoryId?categoryId={categoryId}";
            var todoTasks = await _httpClient.GetFromJsonAsync<List<TodoTaskResponseDto>>(apiCall, cancellationToken);

            return todoTasks ?? new List<TodoTaskResponseDto>();
        }

        public async Task MarkTodoTaskAsCompletedAsync(Guid todoTaskId, CancellationToken cancellationToken = default)
        {
            var apiCall = $@"{_host}/api/TodoTask/v1/MarkTodoTaskAsCompleted?id={todoTaskId}";

            try
            {
                await _httpClient.PutAsJsonAsync(apiCall, todoTaskId);

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task MarkTodoTaskAsInCompletedAsync(Guid todoTaskId, CancellationToken cancellationToken = default)
        {
            var apiCall = $@"{_host}/api/TodoTask/v1/MarkTodoTaskAsInCompleted?id={todoTaskId}";

            try
            {
                await _httpClient.PutAsJsonAsync(apiCall, todoTaskId);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
