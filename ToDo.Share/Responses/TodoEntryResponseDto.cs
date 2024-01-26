namespace ToDo.Shared.Responses
{
    public class TodoEntryResponseDto
    {
        public uint Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public ICollection<ItemResponseDto>? Items { get; set; }

    }
}
