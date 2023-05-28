using Newtonsoft.Json;
using Todo.Domain;

namespace Todo.Data.DTO;

public class CosmoModel<T> where T : BaseModel
{
    [JsonProperty("id")]
    public string Id { get; init; }

    [JsonProperty("body")]
    public T Body { get; init; }

    [JsonProperty("partitionKey")]
    public string PartitionKey { get; init; }
}
