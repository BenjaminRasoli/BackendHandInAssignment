using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Models.Response;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<ResponseResult?> CreateProjectAsync(ProjectForm form)
    {
        try
        {
            if (form == null)
            {
                return ResponseResult.InvalidModel("Project form cannot be null.");
            }

            var projectEntity = ProjectFactory.Map(form);

            if (projectEntity == null)
            {
                return ResponseResult.InvalidModel("Failed to map project entity.");
            }

            await _projectRepository.AddAsync(projectEntity);
            var project = ProjectFactory.Map(projectEntity);


            return ResponseResult<Project>.Ok("Project successfully created.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed(ex.Message);
        }
    }


    public async Task<ResponseResult?> GetProjectsAsync()
    {
        try
        {
            var projectEntities = await _projectRepository.GetAllAsync();

            if (projectEntities == null || !projectEntities.Any())
            {
                return ResponseResult.Failed("No projects found.");
            }

            var projects = projectEntities.Select(ProjectFactory.Map);
            return ResponseResult<IEnumerable<Project>>.Ok("Projects retrieved successfully.", projects!);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed(ex.Message);
        }
    }

    public async Task<ResponseResult?> GetProjectAsync(int id)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(p => p.Id == id);

            if (projectEntity == null)
            {
                return ResponseResult.Failed("No project with that id.");
            }

            var project = ProjectFactory.Map(projectEntity);
            return ResponseResult<Project>.Ok("Project retrieved successfully.", project!);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed(ex.Message);
        }
    }

    public async Task<ResponseResult?> GetProjectAsync(string projectName)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(p => p.ProjectName == projectName);

            if (projectEntity == null)
            {
                return ResponseResult.Failed("No project with that name.");
            }

            var project = ProjectFactory.Map(projectEntity);
            return ResponseResult<Project>.Ok("Project retrieved successfully.", project!);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed(ex.Message);
        }
    }

    public async Task<ResponseResult?> UpdateProjectAsync(ProjectUpdateForm projectUpdateForm)
    {
        try
        {
            if (projectUpdateForm == null)
            {
                return ResponseResult.InvalidModel("Project form cannot be null.");
            }

            var projectEntity = ProjectFactory.Map(projectUpdateForm);

            if (projectEntity == null)
            {
                return ResponseResult.InvalidModel("Failed to map project entity.");
            }

            await _projectRepository.UpdateAsync(projectEntity);

            return ResponseResult<Project>.Ok("Project successfully updated.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed(ex.Message);
        }
    }

    public async Task<ResponseResult?> DeleteProjectAsync(int id)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(p => p.Id == id);

            if (projectEntity == null)
            {
                return ResponseResult.NotFound("Project not found.");
            }

            await _projectRepository.RemoveAsync(projectEntity);

            return ResponseResult.Deleted("Project successfully deleted.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed(ex.Message);
        }
    }

}
