using ToDo.Shared.Data;

namespace ToDo.Shared.Common
{
    public class TodoEntryDto
    {
        public string Name { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public ICollection<ItemDto>? Items { get; set; }
    }
}
