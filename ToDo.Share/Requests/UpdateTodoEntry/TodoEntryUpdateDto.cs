namespace ToDo.Shared.Requests.UpdateTodoEntry
{
    public class TodoEntryUpdateDto
    {
        public string Name { get; set; } = null!;

        public ICollection<ItemDtoUpdateDto>? Items { get; set; }

    }
}
