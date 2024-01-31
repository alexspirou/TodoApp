namespace Todo.Shared.Responses
{
    public record TodoTaskResponseDto(  Guid Id,
                                        string? Title, 
                                        bool IsDone, 
                                        DateTime Date,
                                        List<CommentResponsetDto>? Comment);
}
