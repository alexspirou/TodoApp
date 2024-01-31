namespace Todo.Shared.Responses
{
    public record CommentResponsetDto(  Guid Id, 
                                        DateTime Date, 
                                        string Content);
}
