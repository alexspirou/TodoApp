using Todo.Shared.Responses;
using Todo.Web.Services.Interfaces;

namespace Todo.Web.Services
{

    public class TodoEntriesServices : ITodoEntriesService
    {
        private readonly HttpClient _httpClient;
        public TodoEntriesServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<CategoryResponseDto>> GetAllTodoEntriesAsync()
        {
            var todoEntries = new List<CategoryResponseDto>();
            try
            {
                var apiCall = @"https://localhost:7055/api/ToDo/v1/GetAllTodoEntries";
                todoEntries = await _httpClient.GetFromJsonAsync<List<CategoryResponseDto>>(apiCall);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
     
            return todoEntries ?? new List<CategoryResponseDto>();
        }



    }
}
