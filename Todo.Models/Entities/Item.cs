namespace Todo.Models.Entities
{
    public class Item
    {
        public uint Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; } = null!;
        public bool IsDone { get; set; }

        // Relationships
        public IEnumerable<Comment>? Comment { get; set; }

        public uint ToDoEntryId { get; set; }
        public TodoEntry TodoEntry { get; set; } = null!;
    }
}
