namespace ToDo.Shared.Responses
{
    public class CommentResponsetDto
    {
        public uint Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; } = null!;
    }
}
