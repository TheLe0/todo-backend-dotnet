namespace Todo.Domain;

public class TaskModel
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public bool IsClosed { get; private set; }

    public TaskModel(string name)
    {
        Name = name;
        Id = Guid.NewGuid().ToString();
        IsClosed = false;
    }

    public void Close()
    {
        IsClosed = true;
    }
}

