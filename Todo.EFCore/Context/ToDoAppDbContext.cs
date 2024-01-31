using Microsoft.EntityFrameworkCore;
using Todo.EFCore.Context.Configurations;
using Todo.Models.Entities;

namespace Todo.EFCore.Context
{
    public class ToDoAppDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<TodoTask> TodoTask { get; set; } = null!;
        public DbSet<Comment> Comment { get; set; } = null!;

        public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : base(options)
        {

        }
        public ToDoAppDbContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TodoTaskConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }

    }
}
