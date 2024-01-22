using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Models.Entities;

namespace Todo.EFCore.Context.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Primary Key
            builder
                .HasKey(c => c.Id);

            // Properties
            builder
                .Property(c => c.Content)
                .IsRequired();

            builder
                .Property(c => c.Date)
                .IsRequired();
            // Index
            builder
                .HasIndex(c => new { c.Content, c.Date })
                .IsUnique();
                    

            // Relationships
            builder.HasOne(c => c.Item)
                .WithMany(i => i.Comment)
                .HasForeignKey(c => c.ItemId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}