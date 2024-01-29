namespace Todo.Shared.Responses
{
    public class CategoryResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public ICollection<TodoTaskResponseDto>? TodoTasks { get; set; }
    }
}
