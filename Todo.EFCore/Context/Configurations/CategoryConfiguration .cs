using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Models.Entities;

namespace Todo.EFCore.Context.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Primary Key
            builder
                .ToTable("Category")
                .HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(t => t.Date)
                .IsRequired();

        }
    }
}
