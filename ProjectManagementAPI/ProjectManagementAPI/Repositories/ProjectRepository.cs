using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Models;

namespace ProjectManagementAPI.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Project?> GetProjectByIdAsync(int projectId)
        {
            return await _context.Projects
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProjectId == projectId);
        }

        public async Task AddProjectAsync(Project project)
        {
            _context.Projects.Add(project);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteProjectAsync(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);

            if (project == null)
                return;

            _context.Projects.Remove(project);

            await _context.SaveChangesAsync();
        }
    }
}