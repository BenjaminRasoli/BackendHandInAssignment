using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class ProjectTypeRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddProjectType()
    {
        var context = DataContextSeeder.GetDataContext();
        var projectTypeRepository = new ProjectTypeRepository(context);

        var result = await projectTypeRepository.AddAsync(TestData.ProjectTypeEntities[0]);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProjectTypes()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.ProjectTypeEntities);
        await context.SaveChangesAsync();

        var projectTypeRepository = new ProjectTypeRepository(context);
        var result = await projectTypeRepository.GetAllAsync();

        Assert.Equal(TestData.ProjectTypeEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnProjectType()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.ProjectTypeEntities);
        await context.SaveChangesAsync();

        var projectTypeRepository = new ProjectTypeRepository(context);
        var result = await projectTypeRepository.GetAsync(x => x.Id == TestData.ProjectTypeEntities[0].Id);

        Assert.Equal(TestData.ProjectTypeEntities[0].Id, result!.Id);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.ProjectTypeEntities);
        await context.SaveChangesAsync();

        var projectTypeRepository = new ProjectTypeRepository(context);
        var projectTypeEntity = TestData.ProjectTypeEntities[0];
        projectTypeEntity.TypeName = TestData.ProjectTypeEntities[0].TypeName;

        var result = await projectTypeRepository.RemoveAsync(projectTypeEntity);

        Assert.True(result);
    }

}

