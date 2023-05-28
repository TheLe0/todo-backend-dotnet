using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Net;
using Todo.Configuration;
using Todo.Data.DTO;
using Todo.Domain;

namespace Todo.Data.Base
{
    public abstract class CosmosDbRepository : IDisposable
    {
        private readonly CosmosDbConfiguration _configuration;
        private CosmosClient _cosmosClient;
        private Database _database;
        private Container _container;

        protected readonly string ContainerId;

        public CosmosDbRepository(IDatabaseConfiguration databaseConfiguration, string containerId)
        {
            _configuration = databaseConfiguration.GetCosmosDbConfigurations();
            ContainerId = containerId;

            InitCosmosClient();
            InitDatabase();
            InitContainer();
        }

        protected async Task<T> AddIfNotExistsAsync<T>(T entity) where T : BaseModel
        {
            ItemResponse<CosmoModel<T>> entityResponse;

            var cosmoEntity = new CosmoModel<T>
            {
                Id = entity.Id,
                Body = entity,
                PartitionKey = _configuration.PartitionKey
            };

            try
            {
                entityResponse = await _container.ReadItemAsync<CosmoModel<T>>(entity.Id, new PartitionKey(_configuration.PartitionKey));
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                entityResponse = await _container.CreateItemAsync(cosmoEntity, new PartitionKey(_configuration.PartitionKey));
            }

            return entityResponse.Resource.Body;
        }

        protected async Task<T> FindById<T>(string id) where T : BaseModel
        {
            try
            {
                var entityResponse = await _container.ReadItemAsync<CosmoModel<T>>(id, new PartitionKey(_configuration.PartitionKey));

                return entityResponse.Resource.Body;

            } 
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        protected async Task<IEnumerable<T>> GetAll<T>() where T : BaseModel
        {
            var sqlQueryText = $"SELECT * FROM c WHERE c.partitionKey = '{_configuration.PartitionKey}'";

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<CosmoModel<T>> queryResultSetIterator = _container.GetItemQueryIterator<CosmoModel<T>>(queryDefinition);

            List<T> entityList = new();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<CosmoModel<T>> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (CosmoModel<T> entity in currentResultSet)
                {
                    entityList.Add(entity.Body);
                }
            }

            return entityList;
        }

        protected async Task<bool> DeleteById<T>(string id) where T : BaseModel
        {
            try
            {
                ItemResponse<CosmoModel<T>> response = await _container.DeleteItemAsync<CosmoModel<T>>(id, new PartitionKey(_configuration.PartitionKey));

                return true;
            }
            catch(CosmosException ex) when(ex.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
        }

        protected async Task<T> Update<T>(T entity) where T : BaseModel
        {
            var cosmoModel = new CosmoModel<T>
            {
                Id = entity.Id,
                Body = entity,
                PartitionKey = _configuration.PartitionKey
            };

            var entityUpdated = await _container.ReplaceItemAsync<CosmoModel<T>>(cosmoModel, entity.Id, new PartitionKey(_configuration.PartitionKey));

            return entityUpdated.Resource.Body;
        }

        private void InitCosmosClient()
        {
            _cosmosClient = new CosmosClient(
                _configuration.EndpointUri,
                _configuration.PrimaryKey,
                new CosmosClientOptions()
                {
                    ApplicationName = _configuration.ApplicationName
                }
            );
        }

        private void InitDatabase()
        {
            Task.Run(async () =>
            {
                _database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(
                    _configuration.DatabaseId
                );
            }).GetAwaiter().GetResult();
        }

        private void InitContainer()
        {
            Task.Run(async () =>
            {
                _container = await _database
                .CreateContainerIfNotExistsAsync(
                    ContainerId, 
                    "/partitionKey"
                );
            }).GetAwaiter().GetResult();
        }

        public void Dispose() => _cosmosClient.Dispose();
    }
}
