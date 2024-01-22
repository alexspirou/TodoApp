using ToDo.Shared.Common;

namespace ToDo.Shared.Data
{
    public class ItemDto
    {
        public required string Title { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime Date { get; set; }
        public List<CommentDto>? Comment { get; set; }
    }
}
