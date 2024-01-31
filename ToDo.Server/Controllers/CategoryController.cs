using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services.Interfaces;
using Todo.Shared.Requests;

namespace ToDo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        private readonly ICategoryService _todoManager; 
        public CategoryController(ILogger<CategoryController> logger, ICategoryService todoManager  )
        {
            _logger = logger;
            _todoManager = todoManager; 
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCategoryAsync(CategoryCreateOrUpdateDto todoEntryDto,CancellationToken cancellationToken  = default)
        {
            var result = await _todoManager.CreateCategoryAsync(todoEntryDto, cancellationToken);

            return Ok(result);
        } 
        
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateCategoryAsync(string name, DateTime date, [FromBody] CategoryCreateOrUpdateDto updatedTodoEntry,CancellationToken cancellationToken  = default)
        {
            var result = await _todoManager.UpdateCategoryAsync(name, date, updatedTodoEntry,cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var result = await _todoManager.GetAllCategoriesAsync(cancellationToken);

            return Ok(result);
        }        
        
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCategoryById(Guid id,CancellationToken cancellationToken = default)
        {
            id = new Guid();

            var result = await _todoManager.GetCategoryById(id, cancellationToken);

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCategoryByIdAsync(Guid id,CancellationToken cancellationToken = default)
        {
            var result = await _todoManager.DeleteCategoryAsync(id, cancellationToken);

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCategoryByNameAndDateAsync(string name, DateTime date,CancellationToken cancellationToken = default)
        {
            var result = await _todoManager.DeleteCategoryAsync(name, date,cancellationToken);

            return Ok(result);
        }        

    }
}
