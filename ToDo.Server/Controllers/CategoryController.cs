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
        public CategoryController(ILogger<CategoryController> logger, ICategoryService todoManager)
        {
            _logger = logger;
            _todoManager = todoManager; 
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCategoryAsync(CategoryCreateOrUpdateDto todoEntryDto)
        {
            var result = await _todoManager.CreateCategoryAsync(todoEntryDto);

            return Ok(result);
        } 
        
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateCategoryAsync(string name, DateTime date, [FromBody] CategoryCreateOrUpdateDto updatedTodoEntry)
        {
            var result = await _todoManager.UpdateCategoryAsync(name, date, updatedTodoEntry);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var result = await _todoManager.GetAllCategoriesAsync();

            return Ok(result);
        }        
        
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCategoryById(uint id)
        {
            var result = await _todoManager.GetCategoryById(id);

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCategoryByIdAsync(uint id)
        {
            var result = await _todoManager.DeleteCategoryAsync(id);

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCategoryByNameAndDateAsync(string name, DateTime date)
        {
            var result = await _todoManager.DeleteCategoryAsync(name, date);

            return Ok(result);
        }        

    }
}
