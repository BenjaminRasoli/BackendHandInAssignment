using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class ContactInfoRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddContactInfo()
    {
        var context = DataContextSeeder.GetDataContext();
        var contactInfoRepository = new ContactInfoRepository(context);

        var result = await contactInfoRepository.AddAsync(TestData.ContactInfoEntities[0]);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllContactInfo()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.ContactInfoEntities);
        await context.SaveChangesAsync();

        var contactInfoRepository = new ContactInfoRepository(context);
        var result = await contactInfoRepository.GetAllAsync();

        Assert.Equal(TestData.ContactInfoEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnContactInfo()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.ContactInfoEntities);
        await context.SaveChangesAsync();

        var contactInfoRepository = new ContactInfoRepository(context);
        var result = await contactInfoRepository.GetAsync(x => x.Id == TestData.ContactInfoEntities[0].Id);

        Assert.Equal(TestData.ContactInfoEntities[0].Id, result!.Id);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.ContactInfoEntities);
        await context.SaveChangesAsync();

        var contactInfoRepository = new ContactInfoRepository(context);
        var contactInfoEntity = TestData.ContactInfoEntities[0];
        contactInfoEntity.Client = TestData.ContactInfoEntities[0].Client;

        var result = await contactInfoRepository.RemoveAsync(contactInfoEntity);

        Assert.True(result);
    }

}

