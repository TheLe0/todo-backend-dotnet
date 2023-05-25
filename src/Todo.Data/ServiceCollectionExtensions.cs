using Microsoft.Extensions.DependencyInjection;
using Todo.Configuration;
using Todo.Data.Repository;

namespace Todo.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddRepository();

        return services;
    }

    private static IServiceCollection AddRepository(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        var configs = serviceProvider.GetRequiredService<IDatabaseConfiguration>();

        switch (configs.GetDatabaseType())
        {
            case DatabaseType.IN_MEMORY:
                services.AddInMemory();
                break;
        }


        return services;
    }

    private static IServiceCollection AddInMemory(this IServiceCollection services)
    {
        services.AddSingleton<ITaskRepository, TakInMemoryRepository>();

        return services;
    }
}

