namespace Todo.Configuration;

public class DatabaseConfiguration : IDatabaseConfiguration
{
	private readonly DatabaseType _type;
	private readonly CosmosDbConfigurations _cosmosConfigurations;

	public DatabaseConfiguration(DatabaseType type)
	{
		_type = type;
		_cosmosConfigurations = null;

    }

    public DatabaseConfiguration(DatabaseType type, CosmosDbConfigurations cosmosConfig)
    {
        _type = type;
        _cosmosConfigurations = cosmosConfig;

    }

    public DatabaseType GetDatabaseType()
	{
		return _type;
	}

	public CosmosDbConfigurations GetCosmosDbConfigurations()
	{
		return _cosmosConfigurations;
	}
}

