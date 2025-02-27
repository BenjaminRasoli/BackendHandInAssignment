using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class RoleRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddRole()
    {
        var context = DataContextSeeder.GetDataContext();
        var roleRepository = new RoleRepository(context);

        var result = await roleRepository.AddAsync(TestData.RoleEntities[0]);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllRoles()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.RoleEntities);
        await context.SaveChangesAsync();

        var roleRepository = new RoleRepository(context);
        var result = await roleRepository.GetAllAsync();

        Assert.Equal(TestData.RoleEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnRole()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.RoleEntities);
        await context.SaveChangesAsync();

        var roleRepository = new RoleRepository(context);
        var result = await roleRepository.GetAsync(x => x.Id == TestData.RoleEntities[0].Id);

        Assert.Equal(TestData.RoleEntities[0].Id, result!.Id);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.RoleEntities);
        await context.SaveChangesAsync();

        var roleRepository = new RoleRepository(context);
        var roleEntity = TestData.RoleEntities[0];
        roleEntity.Role = TestData.RoleEntities[0].Role;

        var result = await roleRepository.RemoveAsync(roleEntity);

        Assert.True(result);
    }

}

