using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class InvoiceRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddInvoice()
    {
        var context = DataContextSeeder.GetDataContext();
        var invoiceRepository = new InvoiceRepository(context);

        var result = await invoiceRepository.AddAsync(TestData.InvoiceEntities[0]);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllInvoices()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.InvoiceEntities);
        await context.SaveChangesAsync();

        var invoiceRepository = new InvoiceRepository(context);
        var result = await invoiceRepository.GetAllAsync();

        Assert.Equal(TestData.InvoiceEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnInvoice()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.InvoiceEntities);
        await context.SaveChangesAsync();

        var invoiceRepository = new InvoiceRepository(context);
        var result = await invoiceRepository.GetAsync(x => x.Id == TestData.InvoiceEntities[0].Id);

        Assert.Equal(TestData.InvoiceEntities[0].Id, result!.Id);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.InvoiceEntities);
        await context.SaveChangesAsync();

        var invoiceRepository = new InvoiceRepository(context);
        var invoiceEntity = TestData.InvoiceEntities[0];
        invoiceEntity.InvoiceNumber = TestData.InvoiceEntities[0].InvoiceNumber;

        var result = await invoiceRepository.RemoveAsync(invoiceEntity);

        Assert.True(result);
    }

}

