namespace Todo.Shared.Responses
{
    public class CommentResponsetDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; } = null!;
    }
}
