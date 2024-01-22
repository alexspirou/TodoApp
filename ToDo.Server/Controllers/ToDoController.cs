using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services;
using ToDo.Shared.Common;
using ToDo.Shared.Requests.UpdateTodoEntry;

namespace ToDo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1/[action]")]

    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;

        private readonly ITodoManager _todoManager; 
        public ToDoController(ILogger<ToDoController> logger, ITodoManager todoManager)
        {
            _logger = logger;
            _todoManager = todoManager; 
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateEntry(TodoEntryDto todoEntryDto)
        {
            var result = await _todoManager.CreateTodoEntryAsync(todoEntryDto);

            return Ok(result);
        } 
        
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateTodoEntryAsync(string name, DateTime dateTime, [FromBody] TodoEntryUpdateDto updatedTodoEntry)
        {
            var result = await _todoManager.UpdateEntry(name, dateTime, updatedTodoEntry);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEntries()
        {

            var result = await _todoManager.GetAllEntriesAsync();

            return Ok(result);
        }
    }
}
