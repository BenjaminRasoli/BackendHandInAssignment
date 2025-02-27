using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class AddressRepository_Tests
{
    [Fact]

    public async Task Addsync_ShouldAddAddress()
    {
        var context = DataContextSeeder.GetDataContext();
        var addressRepository = new AddressRepository(context);

        var result = await addressRepository.AddAsync(TestData.AddressEntities[0]);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]

    public async Task GetAllAsync_ShouldReturnAllAddresses()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.AddressEntities);
        await context.SaveChangesAsync();

        var addressRepository = new AddressRepository(context);
        var result = await addressRepository.GetAllAsync();

        Assert.Equal(TestData.AddressEntities.Length, result.Count());
    }


    [Fact]

    public async Task GetAsync_ShouldReturnAddress()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.AddressEntities);
        await context.SaveChangesAsync();

        var addressRepository = new AddressRepository(context);
        var result = await addressRepository.GetAsync(x => x.Id == TestData.AddressEntities[0].Id);

        Assert.Equal(TestData.AddressEntities[0].Id, result!.Id);
    }

    [Fact]

    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.AddressEntities);
        await context.SaveChangesAsync();

        var addressRepository = new AddressRepository(context);
        var addressEntity = TestData.AddressEntities[0];
        addressEntity.City = TestData.AddressEntities[0].City;

        var result = await addressRepository.RemoveAsync(addressEntity);

        Assert.True(result);
    }
}

