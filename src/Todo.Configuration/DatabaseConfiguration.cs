using System;
namespace Todo.Configuration;

public class DatabaseConfiguration : IDatabaseConfiguration
{
	private readonly DatabaseType _type;

	public DatabaseConfiguration(DatabaseType type)
	{
		_type = type;
	}

	public DatabaseType GetDatabaseType()
	{
		return _type;
	}
}

