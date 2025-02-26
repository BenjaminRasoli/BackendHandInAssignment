using Business.Models;
using Business.Models.Response;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<ResponseResult?> CreateProjectAsync(ProjectForm form);
        Task<ResponseResult?> DeleteProjectAsync(int id);
        Task<ResponseResult?> GetProjectAsync(int id);
        Task<ResponseResult?> GetProjectAsync(string projectName);
        Task<ResponseResult?> GetProjectsAsync();
        Task<ResponseResult?> UpdateProjectAsync(ProjectUpdateForm projectUpdateForm);
    }
}