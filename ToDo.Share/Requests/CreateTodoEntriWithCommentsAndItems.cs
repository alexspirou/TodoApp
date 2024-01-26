namespace ToDo.Shared.Requests
{
    public record CreateDtoWithCommentsAndItems(TodoEntryCreateOrUpdateDto todo, 
                                                CommentCreateOrUpdateDto comment, 
                                                ItemDtoCreateUpdateDto item);

}