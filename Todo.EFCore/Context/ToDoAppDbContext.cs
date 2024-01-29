using Microsoft.EntityFrameworkCore;
using Todo.EFCore.Context.Configurations;
using Todo.Models.Entities;

namespace Todo.EFCore.Context
{
    public class ToDoAppDbContext : DbContext
    {
        public DbSet<Category> TodoEntry { get; set; } = null!;
        public DbSet<TodoTask> Item { get; set; } = null!;
        public DbSet<Comment> Comment { get; set; } = null!;

        public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : base(options)
        {

        }
        public ToDoAppDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();

            //if (!optionsBuilder.IsConfigured)
            //{
            //    // TODO : remove connection string from here
            //}

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TodoTaskConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }

    }
}
