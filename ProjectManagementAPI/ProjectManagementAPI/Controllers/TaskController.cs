using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.DTOs;
using ProjectManagementAPI.Services;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(AddTaskDto dto)
        {
            await _taskService.AddTaskAsync(dto);

            return Ok(new
            {
                success = true,
                message = "Task added successfully"
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(UpdateTaskDto dto)
        {
            await _taskService.UpdateTaskAsync(dto);

            return Ok(new
            {
                success = true,
                message = "Task updated successfully"
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);

            return Ok(new
            {
                success = true,
                message = "Task deleted successfully"
            });
        }
    }
}