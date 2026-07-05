using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.DTOs;
using ProjectManagementAPI.Services;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            return Ok(await _projectService.GetAllProjectsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(AddProjectDto dto)
        {
            await _projectService.AddProjectAsync(dto);

            return Ok(new
            {
                message = "Project added successfully"
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto dto)
        {
            await _projectService.UpdateProjectAsync(dto);

            return Ok(new
            {
                message = "Project updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProjectAsync(id);

            return Ok(new
            {
                message = "Project deleted successfully"
            });
        }
        [HttpGet("dropdown")]
        public async Task<IActionResult> GetProjectDropdown()
        {
            var projects = await _projectService.GetAllProjectsAsync();

            var result = projects.Select(p => new
            {
                p.ProjectId,
                p.ProjectName
            });

            return Ok(result);
        }
    }
}