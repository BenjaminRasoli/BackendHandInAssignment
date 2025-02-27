using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.SeedData;

public class DataContextSeeder
{
    public static DataContext GetDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new DataContext(options);
        context.Database.EnsureCreated();
        return context;
    }

    public static async Task SeedAsync(DataContext context)
    {
        context.Clients.AddRange(TestData.ClientEntities);

        context.Employees.AddRange(TestData.EmployeeEntities);

        context.TimeLines.AddRange(TestData.TimeLineEntities);

        context.ProjectTypes.AddRange(TestData.ProjectTypeEntities);

        context.Statuses.AddRange(TestData.StatusEntities);


        await context.SaveChangesAsync();
    }

    public static async Task SeedWithProjectsAsync(DataContext context)
    {
        context.Clients.AddRange(TestData.ClientEntities);

        context.Employees.AddRange(TestData.EmployeeEntities);

        context.TimeLines.AddRange(TestData.TimeLineEntities);

        context.ProjectTypes.AddRange(TestData.ProjectTypeEntities);

        context.Statuses.AddRange(TestData.StatusEntities);

        context.Projects.AddRange(TestData.ProjectEntities);

        await context.SaveChangesAsync();
    }
}
