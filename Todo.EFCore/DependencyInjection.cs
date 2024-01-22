using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.EFCore.Context;
using Todo.EFCore.Repositories;

namespace Todo.EFCore
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddEfcore(this IServiceCollection services)
        {
            // Add dependency injection here
            services.AddDbContext<ToDoAppDbContext>(options =>
            {
                var connectionsString = "Data Source=ML-5015Q04\\SQLEXPRESS;Initial Catalog=ToDoApp;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
                options.UseSqlServer(connectionsString, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            }
            );

            services.AddDbContext<ToDoAppDbContext>(options =>
            {
                options.UseInMemoryDatabase("testMemoryDb");

            });

            services.AddScoped<IToDoEntryRepository, ToDoEntryRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();


            return services;
        }
    }
}
