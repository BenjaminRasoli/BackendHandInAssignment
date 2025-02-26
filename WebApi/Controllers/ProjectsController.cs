using Azure;
using Business.Interfaces;
using Business.Models;
using Business.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectService projectService) : ControllerBase
    {
        private readonly IProjectService _projectService = projectService;

        [HttpGet]

        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectService.GetProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProject(int id)
        {
            var projects = await _projectService.GetProjectAsync(id);
            return projects == null ? NotFound() : Ok(projects);
        }

        [HttpPost]

        public async Task<IActionResult> CreateProject(ProjectForm form)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            var projects = await _projectService.CreateProjectAsync(form);
            return projects == null ? BadRequest() : Ok(projects);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(ProjectUpdateForm projectUpdateForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _projectService.UpdateProjectAsync(projectUpdateForm);

            if (response!.Success)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectAsync(int id)
        {
            try
            {
                var response = await _projectService.DeleteProjectAsync(id);

                if (response == null || !response.Success)
                {
                    return StatusCode(response?.StatusCode ?? 400, response?.Message ?? "Failed to delete the project.");
                }

                return StatusCode(response.StatusCode, response.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return StatusCode(500, "An unexpected error occurred.");
            }
        }






    }
}
