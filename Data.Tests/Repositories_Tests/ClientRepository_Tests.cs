using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class ClientRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddClient()
    {
        var context = DataContextSeeder.GetDataContext();
        var clientRepository = new ClientRepository(context);

        var result = await clientRepository.AddAsync(TestData.ClientEntities[0]);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllClients()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.ClientEntities);
        await context.SaveChangesAsync();

        var clientRepository = new ClientRepository(context);
        var result = await clientRepository.GetAllAsync();

        Assert.Equal(TestData.ClientEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnClient()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.ClientEntities);
        await context.SaveChangesAsync();

        var clientRepository = new ClientRepository(context);
        var result = await clientRepository.GetAsync(x => x.Id == TestData.ClientEntities[0].Id);

        Assert.Equal(TestData.ClientEntities[0].Id, result!.Id);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.ClientEntities);
        await context.SaveChangesAsync();

        var clientRepository = new ClientRepository(context);
        var clientEntity = TestData.ClientEntities[0];
        clientEntity.ClientName = TestData.ClientEntities[0].ClientName;

        var result = await clientRepository.RemoveAsync(clientEntity);

        Assert.True(result);
    }

}

