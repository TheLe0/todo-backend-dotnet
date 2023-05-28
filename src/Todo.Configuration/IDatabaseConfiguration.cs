using System;
namespace Todo.Configuration;

public interface IDatabaseConfiguration
{
    DatabaseType GetDatabaseType();
    CosmosDbConfiguration GetCosmosDbConfigurations();
}

