using Todo.Domain;
using Todo.Fixture;

namespace Todo.UnitTest;

public class TaskModelTest
{
    [Fact]
    public void CreateTask_InformingName_ReturnsTaskObject()
    {
        var taskName = TaskFixture.GenerateRandomTaskName();

        var task = new TaskModel(taskName);

        Assert.NotNull(task);
        Assert.Equal(taskName, task.Name);
        Assert.False(string.IsNullOrEmpty(task.Id));
        Assert.False(task.IsClosed);
    }

    [Fact]
    public void CloseTask_AfterTaskCreated_ReturnsTaskClosed()
    {
        var taskName = TaskFixture.GenerateRandomTaskName();

        var task = new TaskModel(taskName);
        task.Close();

        Assert.NotNull(task);
        Assert.Equal(taskName, task.Name);
        Assert.False(string.IsNullOrEmpty(task.Id));
        Assert.True(task.IsClosed);
    }
}
