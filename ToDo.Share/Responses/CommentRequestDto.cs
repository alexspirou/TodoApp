namespace ToDo.Shared.Responses
{
    public class CommentRequestDto
    {
        public uint Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; } = null!;
    }
}
