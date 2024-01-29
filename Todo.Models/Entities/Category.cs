namespace Todo.Models.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<TodoTask>? TodoTasks { get; set; } = new List<TodoTask>();
    }
}
