namespace Todo.Models.Entities
{
    public class Comment : BaseEntity
    {

        public string Content { get; set; } = null!;

        // Relationships
        public Guid ItemId { get; set; }
        public TodoTask? Item { get; set; } 
    }
}
