using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services;
using ToDo.Shared.Requests;

namespace ToDo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1/[action]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;

        private readonly IItemService _itemService;

        public ItemController(ILogger<ToDoController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateItemAsync(uint todoEntryId, ItemDtoCreateUpdateDto newItem)
        {
            var result = await _itemService.CreateItemAsync(todoEntryId,newItem);

            return Ok(result);
        }
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateItemAsync(uint id, [FromBody] ItemDtoCreateUpdateDto newItem)
        {
            var result = await _itemService.UpdateItemAsync(id, newItem);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItemsAsync()
        {
            var result = await _itemService.GetAllItemsAsync();

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItemAsync(uint id)
        {
            var result = await _itemService.DeleteItemAsync(id);

            return Ok(result);
        }

    }
}
