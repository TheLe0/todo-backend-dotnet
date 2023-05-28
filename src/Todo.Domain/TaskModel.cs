namespace Todo.Domain;

public class TaskModel : BaseModel
{
    public string Name { get; set; }
    public bool IsClosed { get; set; }

    public TaskModel() : base() {  }

    public TaskModel(string name) :base()
    {
        Name = name;
        IsClosed = false;

        GenerateId();
    }

    public void Close()
    {
        IsClosed = true;
    }
}

