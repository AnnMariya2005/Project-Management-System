using ProjectManagementAPI.DTOs;
using ProjectManagementAPI.Models;
using ProjectManagementAPI.Repositories;

namespace ProjectManagementAPI.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectDetailsDto>> GetAllProjectsAsync()
        {
            var projects = await _projectRepository.GetAllProjectsAsync();

            return projects.Select(p => new ProjectDetailsDto
            {
                ProjectId = p.ProjectId,
                ProjectName = p.ProjectName,
                ProjectCode = p.ProjectCode,
                Manager = p.Manager,
                Description = p.Description,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Status = p.Status,
                Budget = p.Budget,
                Notes = p.Notes,
                IsActive = p.IsActive
            }).ToList();
        }

        public async Task<ProjectDetailsDto?> GetProjectByIdAsync(int projectId)
        {
            var p = await _projectRepository.GetProjectByIdAsync(projectId);

            if (p == null)
                return null;

            return new ProjectDetailsDto
            {
                ProjectId = p.ProjectId,
                ProjectName = p.ProjectName,
                ProjectCode = p.ProjectCode,
                Manager = p.Manager,
                Description = p.Description,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Status = p.Status,
                Budget = p.Budget,
                Notes = p.Notes,
                IsActive = p.IsActive
            };
        }

        public async Task AddProjectAsync(AddProjectDto dto)
        {
            var project = new Project
            {
                ProjectName = dto.ProjectName,
                ProjectCode = dto.ProjectCode,
                Manager = dto.Manager,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Status = dto.Status,
                Budget = dto.Budget,
                Notes = dto.Notes,
                CreatedDate = DateTime.Now,
                CreatedBy = dto.CreatedBy,
                IsActive = true
            };

            await _projectRepository.AddProjectAsync(project);
        }

        public async Task UpdateProjectAsync(UpdateProjectDto dto)
        {
            var project = await _projectRepository.GetProjectByIdAsync(dto.ProjectId);

            if (project == null)
                throw new Exception("Project not found");

            project.ProjectName = dto.ProjectName;
            project.ProjectCode = dto.ProjectCode;
            project.Manager = dto.Manager;
            project.Description = dto.Description;
            project.StartDate = dto.StartDate;
            project.EndDate = dto.EndDate;
            project.Status = dto.Status;
            project.Budget = dto.Budget;
            project.Notes = dto.Notes;
            project.IsActive = dto.IsActive;

            // Keep the original CreatedDate and CreatedBy

            await _projectRepository.UpdateProjectAsync(project);
        }
        public async Task DeleteProjectAsync(int projectId)
        {
            await _projectRepository.DeleteProjectAsync(projectId);
        }
    }
}