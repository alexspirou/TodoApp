namespace Todo.Shared.Requests
{
    public record CreateDtoWithCommentsAndItems(CategoryCreateOrUpdateDto todo, 
                                                CommentCreateOrUpdateDto comment, 
                                                TodoTaskDtoCreateUpdateDto item);

}