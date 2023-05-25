using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Services;
using Todo.Data;

namespace Todo.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddData();

        services.AddTransient<ITaskService, TaskService>();

        return services;
    }
}

