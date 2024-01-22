using ToDo.Shared.Requests.UpdateTodoEntry;

public class ItemDtoUpdateDto
{
    public string Title { get; set; } = null!;
    public bool IsDone { get; set; }
    public List<CommentUpdateDto>? Comments { get; set; }
}
