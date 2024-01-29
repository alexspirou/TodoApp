namespace Todo.Models.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = new Guid();
        public DateTime Date { get; set; } = DateTime.Now;

    }
}
