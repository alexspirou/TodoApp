using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services.Interfaces;

namespace ToDo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1/[action]")]
    public class TodoTaskController : ControllerBase
    {
        private readonly ILogger<TodoTaskController> _logger;

        private readonly ITodoTaskService _itemService;

        public TodoTaskController(ILogger<TodoTaskController> logger, ITodoTaskService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTodoTaskAsync(Guid todoEntryId, TodoTaskDtoCreateUpdateDto newItem)
        {
            var result = await _itemService.CreateTodoTaskAsync(todoEntryId,newItem);

            return Ok(result);
        }
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateTodoTaskAsync(Guid id, [FromBody] TodoTaskDtoCreateUpdateDto newItem)
        {
            var result = await _itemService.UpdateTodoTaskAsync(id, newItem);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllTodoTasksAsync()
        {
            var result = await _itemService.GetAllTodoTasksAsync();

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteTodoTaskAsync(Guid id)
        {
            var result = await _itemService.DeleteTodoTaskAsync(id);

            return Ok(result);
        }

    }
}
