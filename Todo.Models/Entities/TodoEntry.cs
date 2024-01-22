namespace Todo.Models.Entities
{
    public class TodoEntry
    {
        public uint Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Item>? Item { get; set; } = new List<Item>();
    }
}
