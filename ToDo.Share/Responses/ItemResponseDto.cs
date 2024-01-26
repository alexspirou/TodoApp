namespace ToDo.Shared.Responses
{
    public class ItemResponseDto
    {
        public uint Id { get; set; }
        public string? Title { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime Date { get; set; }
        public List<CommentResponsetDto>? Comment { get; set; }
    }
}
