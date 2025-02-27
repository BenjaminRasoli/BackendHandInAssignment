using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class ServiceRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddService()
    {
        var context = DataContextSeeder.GetDataContext();
        var serviceRepository = new ServiceRepository(context);

        var result = await serviceRepository.AddAsync(TestData.ServiceEntities[0]);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllServices()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.ServiceEntities);
        await context.SaveChangesAsync();

        var serviceRepository = new ServiceRepository(context);
        var result = await serviceRepository.GetAllAsync();

        Assert.Equal(TestData.ServiceEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnService()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.ServiceEntities);
        await context.SaveChangesAsync();

        var serviceRepository = new ServiceRepository(context);
        var result = await serviceRepository.GetAsync(x => x.Id == TestData.ServiceEntities[0].Id);

        Assert.Equal(TestData.ServiceEntities[0].Id, result!.Id);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.ServiceEntities);
        await context.SaveChangesAsync();

        var serviceRepository = new ServiceRepository(context);
        var serviceEntity = TestData.ServiceEntities[0];
        serviceEntity.Name = TestData.ServiceEntities[0].Name;

        var result = await serviceRepository.RemoveAsync(serviceEntity);

        Assert.True(result);
    }

}

