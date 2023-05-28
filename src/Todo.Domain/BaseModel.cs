namespace Todo.Domain;

public abstract class BaseModel
{
    public string Id { get; set; }

    protected void GenerateId()
    {
        Id = Guid.NewGuid().ToString();
    }
}
