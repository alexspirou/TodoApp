namespace Todo.Shared.Requests
{
    public record CreateTodoTaskWithCommentsAndItems(   CategoryCreateOrUpdateDto todo, 
                                                        CommentCreateOrUpdateDto comment, 
                                                        TodoTaskDtoCreateUpdateDto item);

}