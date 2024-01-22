namespace Todo.Models.Entities
{
    public class Comment
    {
        public uint Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; } = null!;

        // Relationships
        public uint ItemId { get; set; }
        public Item Item { get; set; } = null!;
    }
}
