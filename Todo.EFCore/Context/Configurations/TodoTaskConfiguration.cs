using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Todo.Models.Entities;

namespace Todo.EFCore.Context.Configurations
{
    public class TodoTaskConfiguration : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            // Primary Key
            builder
                .ToTable("TodoTask")
                .HasKey(i => i.Id);

            // Properties
            builder
                .Property(i => i.Title)
                .HasMaxLength(40)
                .IsRequired();

            builder
                .Property(i => i.Date)
                .IsRequired();

            // Index
            builder
                .HasIndex(i => new { i.Title, i.Date })
                .IsUnique();

            // Relationships
            builder
                .HasOne(i => i.Category)
                .WithMany(t => t.TodoTasks)
                .HasForeignKey(i => i.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}