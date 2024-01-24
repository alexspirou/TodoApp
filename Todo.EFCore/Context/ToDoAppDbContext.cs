using Microsoft.EntityFrameworkCore;
using Todo.EFCore.Context.Configurations;
using Todo.Models.Entities;

namespace Todo.EFCore.Context
{
    public class ToDoAppDbContext : DbContext
    {
        public DbSet<TodoEntry> TodoEntry { get; set; } = null!;
        public DbSet<Item> Item { get; set; } = null!;
        public DbSet<Comment> Comment { get; set; } = null!;

        public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : base(options)
        {

        }
        public ToDoAppDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ML-PC28CXTP\\SQLEXPRESS;Initial Catalog=Todo.Db;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

            //if (!optionsBuilder.IsConfigured)
            //{
            //    // TODO : remove connection string from here
            //}

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoEntryConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }

    }
}
