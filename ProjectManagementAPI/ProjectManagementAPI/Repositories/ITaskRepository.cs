using ProjectManagementAPI.Models;

namespace ProjectManagementAPI.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetAllTasksAsync();

        Task<TaskItem?> GetTaskByIdAsync(int taskId);

        Task AddTaskAsync(TaskItem task);

        Task UpdateTaskAsync(TaskItem task);

        Task DeleteTaskAsync(int id);
    }
}