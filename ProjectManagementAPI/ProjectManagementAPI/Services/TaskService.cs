using ProjectManagementAPI.DTOs;
using ProjectManagementAPI.Models;
using ProjectManagementAPI.Repositories;

namespace ProjectManagementAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskDetailsDto>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();

            return tasks.Select(t => new TaskDetailsDto
            {
                TaskId = t.TaskId,
                TaskName = t.TaskName,
                ProjectId = t.ProjectId,
                AssignedTo = t.AssignedTo,
                Priority = t.Priority,
                Status = t.Status,
                StartDate = t.StartDate,
                DueDate = t.DueDate,
                EstimatedHours = t.EstimatedHours,
                Description = t.Description,
                IsActive = t.IsActive
            }).ToList();
        }

        public async Task<TaskDetailsDto?> GetTaskByIdAsync(int taskId)
        {
            var t = await _taskRepository.GetTaskByIdAsync(taskId);

            if (t == null)
                return null;

            return new TaskDetailsDto
            {
                TaskId = t.TaskId,
                TaskName = t.TaskName,
                ProjectId = t.ProjectId,
                AssignedTo = t.AssignedTo,
                Priority = t.Priority,
                Status = t.Status,
                StartDate = t.StartDate,
                DueDate = t.DueDate,
                EstimatedHours = t.EstimatedHours,
                Description = t.Description,
                IsActive = t.IsActive
            };
        }

        public async Task AddTaskAsync(AddTaskDto dto)
        {
            var task = new TaskItem
            {
                TaskName = dto.TaskName,
                ProjectId = dto.ProjectId,
                AssignedTo = dto.AssignedTo,
                Priority = dto.Priority,
                Status = dto.Status,
                StartDate = dto.StartDate,
                DueDate = dto.DueDate,
                EstimatedHours = dto.EstimatedHours,
                Description = dto.Description,
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            await _taskRepository.AddTaskAsync(task);
        }

        public async Task UpdateTaskAsync(UpdateTaskDto dto)
        {
            var task = new TaskItem
            {
                TaskId = dto.TaskId,
                TaskName = dto.TaskName,
                ProjectId = dto.ProjectId,
                AssignedTo = dto.AssignedTo,
                Priority = dto.Priority,
                Status = dto.Status,
                StartDate = dto.StartDate,
                DueDate = dto.DueDate,
                EstimatedHours = dto.EstimatedHours,
                Description = dto.Description,

                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,

                IsActive = dto.IsActive
            };

            await _taskRepository.UpdateTaskAsync(task);
        }

        

        public async Task DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteTaskAsync(id);
        }
    }
}