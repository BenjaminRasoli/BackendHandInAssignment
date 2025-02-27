using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class PaymentRepository_Tests
{
    [Fact]
    public async Task AddAsync_ShouldAddPayment()
    {
        var context = DataContextSeeder.GetDataContext();
        var paymentRepository = new PaymentRepository(context);

        var result = await paymentRepository.AddAsync(TestData.PaymentEntities[0]);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllPayments()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.PaymentEntities);
        await context.SaveChangesAsync();

        var paymentRepository = new PaymentRepository(context);
        var result = await paymentRepository.GetAllAsync();

        Assert.Equal(TestData.PaymentEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnPayment()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.PaymentEntities);
        await context.SaveChangesAsync();

        var paymentRepository = new PaymentRepository(context);
        var result = await paymentRepository.GetAsync(x => x.Id == TestData.PaymentEntities[0].Id);

        Assert.Equal(TestData.PaymentEntities[0].Id, result!.Id);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();

        await context.AddRangeAsync(TestData.PaymentEntities);
        await context.SaveChangesAsync();

        var paymentRepository = new PaymentRepository(context);
        var paymentEntity = TestData.PaymentEntities[0];
        paymentEntity.Amount = TestData.PaymentEntities[0].Amount;

        var result = await paymentRepository.RemoveAsync(paymentEntity);

        Assert.True(result);
    }

}

