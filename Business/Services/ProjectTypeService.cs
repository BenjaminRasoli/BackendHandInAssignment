using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class ProjectTypeService(IProjectTypeRepository projectTypeRepository) : IProjectTypeService
{
    private readonly IProjectTypeRepository _projectTypeRepository = projectTypeRepository;

    public async Task<IEnumerable<ProjectType?>> GetProjectTypesAsync()
    {
        var entities = await _projectTypeRepository.GetAllAsync();
        return entities.Select(ProjectTypeFactory.Map);
    }
}
