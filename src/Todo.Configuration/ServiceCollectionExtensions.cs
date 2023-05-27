using Microsoft.Extensions.DependencyInjection;
using Todo.Configuration.Resources;

namespace Todo.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        services.AddDatabaseConfiguration();

        return services;
    }

    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services)
    {
        var databaseType = (DatabaseType)
            int.Parse(Environment.GetEnvironmentVariable(EnvironmentVariable.DatabaseType));

        var databaseConfig = new DatabaseConfiguration(databaseType);

        if (databaseType == DatabaseType.COSMOS_DB)
        {
            var cosmosDbConfig = new CosmosDbConfigurations
            {
                PartitionKey = Environment.GetEnvironmentVariable(EnvironmentVariable.CosmosDbPartitionKey),
                EndpointUri = Environment.GetEnvironmentVariable(EnvironmentVariable.CosmosDbEndpointUri),
                PrimaryKey = Environment.GetEnvironmentVariable(EnvironmentVariable.CosmosDbPrimaryKey),
                DatabaseId = Environment.GetEnvironmentVariable(EnvironmentVariable.CosmosDbDatabaseId)
            };

            databaseConfig = new DatabaseConfiguration(databaseType, cosmosDbConfig);
        }

        services.AddSingleton<IDatabaseConfiguration>(X => databaseConfig);

        return services;
    }
}

