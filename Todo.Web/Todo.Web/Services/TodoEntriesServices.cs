using Microsoft.AspNetCore.Components;
using Todo.Web.Services.Interfaces;
using ToDo.Shared.Responses;

namespace Todo.Web.Services
{

    public class TodoEntriesServices : ITodoEntriesService
    {
        private readonly HttpClient _httpClient;
        public TodoEntriesServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<TodoEntryResponseDto>> GetAllTodoEntriesAsync()
        {
            var todoEntries = new List<TodoEntryResponseDto>();
            try
            {
                var apiCall = @"https://localhost:7055/api/ToDo/v1/GetAllTodoEntries";
                todoEntries = await _httpClient.GetFromJsonAsync<List<TodoEntryResponseDto>>(apiCall);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
     
            return todoEntries ?? new List<TodoEntryResponseDto>();
        }



    }
}
