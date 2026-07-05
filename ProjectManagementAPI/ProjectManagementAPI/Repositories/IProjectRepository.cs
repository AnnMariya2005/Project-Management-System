using ProjectManagementAPI.Models;

namespace ProjectManagementAPI.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjectsAsync();

        Task<Project?> GetProjectByIdAsync(int projectId);

        Task AddProjectAsync(Project project);

        Task UpdateProjectAsync(Project project);

        Task DeleteProjectAsync(int projectId);
    }
}