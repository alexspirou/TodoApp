namespace ToDo.Shared.Responses
{
    public class TodoEntryRequestDto
    {
        public uint Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public ICollection<ItemRequestDto>? Items { get; set; }

    }
}
