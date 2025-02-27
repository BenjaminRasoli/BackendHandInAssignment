using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class UserRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddUser()
    {
        var context = DataContextSeeder.GetDataContext();
        var userRepository = new UserRepository(context);

        var result = await userRepository.AddAsync(TestData.UserEntities[0]);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllUsers()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.UserEntities);
        await context.SaveChangesAsync();

        var userRepository = new UserRepository(context);
        var result = await userRepository.GetAllAsync();

        Assert.Equal(TestData.UserEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnUser()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.UserEntities);
        await context.SaveChangesAsync();

        var userRepository = new UserRepository(context);
        var result = await userRepository.GetAsync(x => x.Id == TestData.UserEntities[0].Id);

        Assert.Equal(TestData.UserEntities[0].Id, result!.Id);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.UserEntities);
        await context.SaveChangesAsync();

        var userRepository = new UserRepository(context);
        var userEntity = TestData.UserEntities[0];
        userEntity.Id = TestData.UserEntities[0].Id;

        var result = await userRepository.RemoveAsync(userEntity);

        Assert.True(result);
    }

}

