using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Models;

namespace ProjectManagementAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            return await _context.Tasks
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int taskId)
        {
            return await _context.Tasks
                .FirstOrDefaultAsync(x => x.TaskId == taskId);
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            var existingTask = await _context.Tasks.FindAsync(task.TaskId);

            if (existingTask == null)
                return;

            existingTask.TaskName = task.TaskName;
            existingTask.ProjectId = task.ProjectId;
            existingTask.AssignedTo = task.AssignedTo;
            existingTask.Priority = task.Priority;
            existingTask.Status = task.Status;
            existingTask.StartDate = task.StartDate;
            existingTask.DueDate = task.DueDate;
            existingTask.EstimatedHours = task.EstimatedHours;
            existingTask.Description = task.Description;
            existingTask.IsActive = task.IsActive;

            // Keep CreatedBy and CreatedDate unchanged

            await _context.SaveChangesAsync();
        }
        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}