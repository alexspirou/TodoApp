using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.EFCore.Context;
using Todo.EFCore.Repositories;
using Todo.EFCore.Repositories.Interfaces;

namespace Todo.EFCore
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddEfcore(this IServiceCollection services, string connectionString)
        {
            // Add dependency injection here

            services.AddDbContext<ToDoAppDbContext>(options =>
            {
                options.UseSqlServer(connectionString, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            }
            );

            //services.AddDbContext<ToDoAppDbContext>(options =>
            //{
            //    options.UseInMemoryDatabase("testMemoryDb");

            //});

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();


            return services;
        }
    }
}
