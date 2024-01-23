using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services;
using ToDo.Shared.Requests;

namespace ToDo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1/[action]")]
    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;

        private readonly ITodoService _todoManager; 
        public ToDoController(ILogger<ToDoController> logger, ITodoService todoManager)
        {
            _logger = logger;
            _todoManager = todoManager; 
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTodoEntryAsync(TodoEntryCreateOrUpdateDto todoEntryDto)
        {
            var result = await _todoManager.CreateTodoEntryAsync(todoEntryDto);

            return Ok(result);
        } 
        
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateTodoEntryAsync(string name, DateTime date, [FromBody] TodoEntryCreateOrUpdateDto updatedTodoEntry)
        {
            var result = await _todoManager.UpdateTodoEntryAsync(name, date, updatedTodoEntry);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodoEntriesAsync()
        {
            var result = await _todoManager.GetAllTodoEntriesAsync();

            return Ok(result);
        }        
        
        [HttpGet]
        public async Task<IActionResult> GetTodoEntryById(uint id)
        {
            var result = await _todoManager.GetAllTodoEntriesAsync();

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTodoEntryByIdAsync(uint id)
        {
            var result = await _todoManager.DeleteTodoEntryAsync(id);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTodoEntryByNameAndDateAsync(string name, DateTime date)
        {
            var result = await _todoManager.DeleteTodoEntryAsync(name, date);

            return Ok(result);
        }        
        



    }
}
