namespace Todo.Models.Entities
{
    public class TodoEntry
    {
        public uint Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
        public IEnumerable<Item>? Item { get; set; } = new List<Item>();
    }
}
