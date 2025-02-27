using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests
{
    public class ProjectRepository_Tests
    {
        [Fact]
        public async Task AddAsync_ShouldAddProjectAndReturnProject()
        {
            var context = DataContextSeeder.GetDataContext();
            await DataContextSeeder.SeedWithProjectsAsync(context);
            IProjectRepository projectRepository = new ProjectRepository(context);


            var projectEntity = TestData.ProjectEntities[0];

            var result = await projectRepository.AddAsync(projectEntity);

            Assert.NotNull(result);
            Assert.Equal(1, result!.Id);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllProjects()
        {
            var context = DataContextSeeder.GetDataContext();

            await DataContextSeeder.SeedWithProjectsAsync(context);

            IProjectRepository projectRepository = new ProjectRepository(context);
            var result = await projectRepository.GetAllAsync();

            Assert.Equal(TestData.ProjectEntities.Length, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnProject()
        {
            var context = DataContextSeeder.GetDataContext();

            await DataContextSeeder.SeedWithProjectsAsync(context);

            IProjectRepository projectRepository = new ProjectRepository(context);
            var result = await projectRepository.GetAsync(x => x.Id == TestData.ProjectEntities[0].Id);

            Assert.Equal(TestData.ProjectEntities[0].Id, result!.Id);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnTrue()
        {
            var context = DataContextSeeder.GetDataContext();

            await DataContextSeeder.SeedWithProjectsAsync(context);

            IProjectRepository projectRepository = new ProjectRepository(context);
            var projectEntity = TestData.ProjectEntities[0];

            projectEntity.ProjectName = "Updated Project Name";

            var result = await projectRepository.UpdateAsync(projectEntity);

            Assert.True(result);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnTrue()
        {
            var context = DataContextSeeder.GetDataContext();

            await DataContextSeeder.SeedWithProjectsAsync(context);

            IProjectRepository projectRepository = new ProjectRepository(context);
            var projectEntity = TestData.ProjectEntities[0];

            var result = await projectRepository.RemoveAsync(projectEntity);

            Assert.True(result);
        }
    }
}
