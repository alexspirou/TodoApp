using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services;
using ToDo.Shared.Requests;

namespace ToDo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1/[action]")]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;

        private readonly ICommentService _commentService;

        public CommentController(ILogger<ToDoController> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(uint itemId, CommentCreateOrUpdateDto newComment)
        {
            var result = await _commentService.CreateCommentAsync(itemId, newComment);

            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCommentAsync(uint id, [FromBody] CommentCreateOrUpdateDto updatedComment)
        {
            var result = await _commentService.UpdateComment(id, updatedComment);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var result = await _commentService.GetAllComments();

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCommentAsync(uint id)
        {
            var result = await _commentService.DeleteComment(id);

            return Ok(result);
        }


    }
}
