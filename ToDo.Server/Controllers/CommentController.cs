using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services.Interfaces;
using Todo.Shared.Requests;

namespace ToDo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1/[action]")]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        private readonly ICommentService _commentService;

        public CommentController(ILogger<CategoryController> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Guid itemId, CommentCreateOrUpdateDto newComment)
        {
            var result = await _commentService.CreateCommentAsync(itemId, newComment);

            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCommentAsync(Guid id, [FromBody] CommentCreateOrUpdateDto updatedComment)
        {
            var result = await _commentService.UpdateCommentAsync(id, updatedComment);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommentsAsync()
        {
            var result = await _commentService.GetAllCommentsAsync();

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCommentAsync(Guid id)
        {
            var result = await _commentService.DeleteCommentAsync(id);

            return Ok(result);
        }


    }
}
