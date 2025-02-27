using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class EmployeeRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddEmployee()
    {
        var context = DataContextSeeder.GetDataContext();
        var employeeRepository = new EmployeeRepository(context);

        var result = await employeeRepository.AddAsync(TestData.EmployeeEntities[0]);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllEmployees()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.EmployeeEntities);
        await context.SaveChangesAsync();

        var employeeRepository = new EmployeeRepository(context);
        var result = await employeeRepository.GetAllAsync();

        Assert.Equal(TestData.EmployeeEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnEmployee()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.EmployeeEntities);
        await context.SaveChangesAsync();

        var employeeRepository = new EmployeeRepository(context);
        var result = await employeeRepository.GetAsync(x => x.Id == TestData.EmployeeEntities[0].Id);

        Assert.Equal(TestData.EmployeeEntities[0].Id, result!.Id);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.EmployeeEntities);
        await context.SaveChangesAsync();

        var employeeRepository = new EmployeeRepository(context);
        var employeeEntity = TestData.EmployeeEntities[0];
        employeeEntity.FirstName = TestData.EmployeeEntities[0].FirstName;

        var result = await employeeRepository.RemoveAsync(employeeEntity);

        Assert.True(result);
    }

}

