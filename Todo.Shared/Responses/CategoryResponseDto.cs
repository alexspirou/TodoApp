namespace Todo.Shared.Responses
{
    public record CategoryResponseDto(  Guid Id, 
                                        string Name, 
                                        DateTime Date,
                                        ICollection<TodoTaskResponseDto>? TodoTasks);

}
