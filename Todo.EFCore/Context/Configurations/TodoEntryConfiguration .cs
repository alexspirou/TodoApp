using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Models.Entities;

namespace Todo.EFCore.Context.Configurations
{
    public class TodoEntryConfiguration : IEntityTypeConfiguration<TodoEntry>
    {
        public void Configure(EntityTypeBuilder<TodoEntry> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Name)
                .IsRequired();

            builder.Property(t => t.Date)
                .IsRequired();

            // Relationships
            builder.HasMany(t => t.Item)
                .WithOne(i => i.TodoEntry)
                .HasForeignKey(i => i.ToDoEntryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
