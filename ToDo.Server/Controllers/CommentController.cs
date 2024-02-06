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
        public async Task<IActionResult> CreateComment(Guid todoTaskId, CommentCreateOrUpdateDto newComment,CancellationToken cancellationToken = default)
        {
            var result = await _commentService.CreateCommentAsync(todoTaskId, newComment, cancellationToken);

            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCommentAsync(Guid id, [FromBody] CommentCreateOrUpdateDto updatedComment,CancellationToken cancellationToken = default)
        {
            var result = await _commentService.UpdateCommentAsync(id, updatedComment, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommentsAsync(CancellationToken cancellationToken = default)
        {
            var result = await _commentService.GetAllCommentsAsync(cancellationToken);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCommentAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _commentService.DeleteCommentAsync(id, cancellationToken);

            return Ok(result);
        }


    }
}
