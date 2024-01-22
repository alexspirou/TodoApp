using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Models.Entities;

namespace Todo.EFCore.Context.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            // Primary Key
            builder
                .HasKey(i => i.Id);

            // Properties
            builder
                .Property(i => i.Title)
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
                .HasMany(i => i.Comment)
                .WithOne(c => c.Item)
                .HasForeignKey(i => i.ItemId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);



            builder
                .HasOne(i => i.TodoEntry)
                .WithMany(t => t.Item)
                .HasForeignKey(i => i.ToDoEntryId)
                //.HasForeignKey(i => i.TodoEntry.TodoEntryId)  // Ask : Can I do this?
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}