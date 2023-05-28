namespace Todo.Configuration;

public class CosmosDbConfiguration
{
    public string PartitionKey { get; set; }
    public string EndpointUri { get; set; }
    public string PrimaryKey { get; set; }
    public string DatabaseId { get; set; }
    public string ApplicationName { get; set; }
}
