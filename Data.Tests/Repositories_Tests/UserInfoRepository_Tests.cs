using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class UserInfoRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddUserInfo()
    {
        var context = DataContextSeeder.GetDataContext();
        var userInfoRepository = new UserInfoRepository(context);

        var result = await userInfoRepository.AddAsync(TestData.UserInfoEntities[0]);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllUserInfos()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.UserInfoEntities);
        await context.SaveChangesAsync();

        var userInfoRepository = new UserInfoRepository(context);
        var result = await userInfoRepository.GetAllAsync();

        Assert.Equal(TestData.UserInfoEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnUserInfo()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.UserInfoEntities);
        await context.SaveChangesAsync();

        var userInfoRepository = new UserInfoRepository(context);
        var result = await userInfoRepository.GetAsync(x => x.Id == TestData.UserInfoEntities[0].Id);

        Assert.Equal(TestData.UserInfoEntities[0].Id, result!.Id);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.UserInfoEntities);
        await context.SaveChangesAsync();

        var userInfoRepository = new UserInfoRepository(context);
        var userInfoEntity = TestData.UserInfoEntities[0];
        userInfoEntity.Email = TestData.UserInfoEntities[0].Email;

        var result = await userInfoRepository.RemoveAsync(userInfoEntity);

        Assert.True(result);
    }

}

