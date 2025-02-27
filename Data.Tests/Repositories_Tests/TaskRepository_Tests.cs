using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class TaskRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddTask()
    {
        var context = DataContextSeeder.GetDataContext();
        var taskRepository = new TaskRepository(context);

        var result = await taskRepository.AddAsync(TestData.TaskEntities[0]);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllTasks()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.TaskEntities);
        await context.SaveChangesAsync();

        var taskRepository = new TaskRepository(context);
        var result = await taskRepository.GetAllAsync();

        Assert.Equal(TestData.TaskEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnTask()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.TaskEntities);
        await context.SaveChangesAsync();

        var taskRepository = new TaskRepository(context);
        var result = await taskRepository.GetAsync(x => x.Id == TestData.TaskEntities[0].Id);

        Assert.Equal(TestData.TaskEntities[0].Id, result!.Id);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.TaskEntities);
        await context.SaveChangesAsync();

        var taskRepository = new TaskRepository(context);
        var taskEntity = TestData.TaskEntities[0];
        taskEntity.TaskName = TestData.TaskEntities[0].TaskName;

        var result = await taskRepository.RemoveAsync(taskEntity);

        Assert.True(result);
    }

}

