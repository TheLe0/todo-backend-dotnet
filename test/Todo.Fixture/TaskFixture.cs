using System.Drawing;
using Bogus;
using Todo.Domain;

namespace Todo.Fixture;

public static class TaskFixture
{
    public static IEnumerable<TaskModel> AutoGenerate(int number)
    {
        return new Faker<TaskModel>()
        .CustomInstantiator(f =>
        new TaskModel(
            f.Random.String()
        ))
        .Generate(number);
    }

    public static string GenerateRandomTaskName()
    {
        return new Faker()
            .Random.String();
    }
}

