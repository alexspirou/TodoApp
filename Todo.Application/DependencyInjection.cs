using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Services;
using Todo.Application.Services.Interfaces;
using Todo.EFCore.Context;
using Todo.EFCore.Repositories;

namespace Todo.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ITodoTaskService, TodoTaskService>();

            return services;
        }
    }
}
