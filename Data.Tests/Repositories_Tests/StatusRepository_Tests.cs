using Data.Contexts;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class StatusRepository_Tests
{
    [Fact]

    public async Task Addsync_ShouldAddStatus()
    {
        var context = DataContextSeeder.GetDataContext();
        var statusRepository = new StatusRepository(context);

        var result = await statusRepository.AddAsync(TestData.StatusEntities[0]);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]

    public async Task GetAllAsync_ShouldReturnAllStatuses()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.StatusEntities);
        await context.SaveChangesAsync();

        var statusRepository = new StatusRepository(context);
        var result = await statusRepository.GetAllAsync();

        Assert.Equal(TestData.StatusEntities.Length, result.Count());
    }


    [Fact]

    public async Task GetAsync_ShouldReturnStatus()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.StatusEntities);
        await context.SaveChangesAsync();

        var statusRepository = new StatusRepository(context);
        var result = await statusRepository.GetAsync(x => x.Id == TestData.StatusEntities[0].Id);

        Assert.Equal(TestData.StatusEntities[0].Id, result!.Id);
    }

    [Fact]

    public async Task UpdateAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.StatusEntities);
        await context.SaveChangesAsync();

        var statusRepository = new StatusRepository(context);
        var statusEntity = TestData.StatusEntities[0];
        statusEntity.StatusName = "not started";

        var result = await statusRepository.UpdateAsync(statusEntity);

        Assert.True(result);
    }

    [Fact]

    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.StatusEntities);
        await context.SaveChangesAsync();

        var statusRepository = new StatusRepository(context);
        var statusEntity = TestData.StatusEntities[0];
        statusEntity.StatusName = "not started";

        var result = await statusRepository.RemoveAsync(statusEntity);

        Assert.True(result);
    }
}

