namespace Todo.Models.Entities
{
    public class TodoTask : BaseEntity
    {
        public TodoTask(string title)
        {
            Title = title;
        }
        public string Title { get; set; } 
        public bool IsDone { get; set; }

        // Relationships
        public ICollection<Comment>? Comment { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
