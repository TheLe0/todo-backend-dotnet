namespace Todo.Configuration;

public class DatabaseConfiguration : IDatabaseConfiguration
{
	private readonly DatabaseType _type;
	private readonly CosmosDbConfiguration _cosmosConfigurations;

	public DatabaseConfiguration(DatabaseType type)
	{
		_type = type;
		_cosmosConfigurations = null;

    }

    public DatabaseConfiguration(DatabaseType type, CosmosDbConfiguration cosmosConfig)
    {
        _type = type;
        _cosmosConfigurations = cosmosConfig;

    }

    public DatabaseType GetDatabaseType()
	{
		return _type;
	}

	public CosmosDbConfiguration GetCosmosDbConfigurations()
	{
		return _cosmosConfigurations;
	}
}

