using System;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Configuration
{
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
                int.Parse(System.Environment.GetEnvironmentVariable("DATABASE_TYPE"));

            services.AddSingleton<IDatabaseConfiguration>(X =>
                new DatabaseConfiguration(databaseType)
            );

            return services;
        }
    }
}

