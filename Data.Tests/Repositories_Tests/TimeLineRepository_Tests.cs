using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class TimeLineRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddTimeline()
    {
        var context = DataContextSeeder.GetDataContext();
        var timelineRepository = new TimeLineRepository(context);

        var result = await timelineRepository.AddAsync(TestData.TimeLineEntities[0]);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllTimelines()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.TimeLineEntities);
        await context.SaveChangesAsync();

        var timelineRepository = new TimeLineRepository(context);
        var result = await timelineRepository.GetAllAsync();

        Assert.Equal(TestData.TimeLineEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnTimeline()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.TimeLineEntities);
        await context.SaveChangesAsync();

        var timelineRepository = new TimeLineRepository(context);
        var result = await timelineRepository.GetAsync(x => x.Id == TestData.TimeLineEntities[0].Id);

        Assert.Equal(TestData.TimeLineEntities[0].Id, result!.Id);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.TimeLineEntities);
        await context.SaveChangesAsync();

        var timelineRepository = new TimeLineRepository(context);
        var timelineEntity = TestData.TimeLineEntities[0];
        timelineEntity.Days = TestData.TimeLineEntities[0].Days;

        var result = await timelineRepository.RemoveAsync(timelineEntity);

        Assert.True(result);
    }

}

