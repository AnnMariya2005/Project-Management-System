using ProjectManagementAPI.DTOs;

namespace ProjectManagementAPI.Services
{
    public interface ITaskService
    {
        Task<List<TaskDetailsDto>> GetAllTasksAsync();

        Task<TaskDetailsDto?> GetTaskByIdAsync(int taskId);

        Task AddTaskAsync(AddTaskDto dto);

        Task UpdateTaskAsync(UpdateTaskDto dto);

        Task DeleteTaskAsync(int id);
    }
}