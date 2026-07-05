using ProjectManagementAPI.DTOs;

namespace ProjectManagementAPI.Services
{
    public interface IProjectService
    {
        Task<List<ProjectDetailsDto>> GetAllProjectsAsync();

        Task<ProjectDetailsDto?> GetProjectByIdAsync(int projectId);

        Task AddProjectAsync(AddProjectDto project);

        Task UpdateProjectAsync(UpdateProjectDto project);

        Task DeleteProjectAsync(int projectId);
    }
}