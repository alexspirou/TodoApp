namespace ToDo.Shared.Responses
{
    public class ItemRequestDto
    {
        public uint Id { get; set; }
        public string? Title { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime Date { get; set; }
        public List<CommentRequestDto>? Comment { get; set; }
    }
}
