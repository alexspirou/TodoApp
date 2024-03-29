﻿using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services.Interfaces;

namespace ToDo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1/[action]")]
    public class TodoTaskController : ControllerBase
    {
        private readonly ILogger<TodoTaskController> _logger;

        private readonly ITodoTaskService _itodoTaskService;

        public TodoTaskController(ILogger<TodoTaskController> logger, ITodoTaskService itemService)
        {
            _logger = logger;
            _itodoTaskService = itemService;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTodoTaskAsync(Guid categoryId, TodoTaskDtoCreateUpdateDto newItem, CancellationToken cancellationToken = default)
        {
            var result = await _itodoTaskService.CreateTodoTaskAsync(categoryId,newItem, cancellationToken);

            return Ok(result);
        }
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateTodoTaskAsync(Guid id, [FromBody] TodoTaskDtoCreateUpdateDto newItem, CancellationToken cancellationToken = default)
        {
            var result = await _itodoTaskService.UpdateTodoTaskAsync(id, newItem, cancellationToken);

            return Ok(result);
        }       
        
        
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> MarkTodoTaskAsCompleted(Guid id, CancellationToken cancellationToken = default)
        {
           await _itodoTaskService.MarkTodoTaskAsCompletedAsync(id, cancellationToken);

            return Ok();
        }       
        
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> MarkTodoTaskAsInCompleted(Guid id, CancellationToken cancellationToken = default)
        {
           await _itodoTaskService.MarkTodoTaskAsInCompletedAsync(id, cancellationToken);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllTodoTasksAsync(CancellationToken cancellationToken = default)
        {
            var result = await _itodoTaskService.GetAllTodoTasksAsync(cancellationToken);

            return Ok(result);
        }        
        
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTodoTasksByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
        {
            var result = await _itodoTaskService.GetTodoTasksByCategoryIdAsync(categoryId, cancellationToken);

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteTodoTaskAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _itodoTaskService.DeleteTodoTaskAsync(id, cancellationToken);

            return Ok(result);
        }

    }
}
