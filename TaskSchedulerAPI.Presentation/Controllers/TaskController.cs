using Microsoft.AspNetCore.Mvc;
using TaskSchedulerAPI.Business.Interfaces;
using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ITaskService taskService, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        
        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateDto taskCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _taskService.CreateTaskAsync(taskCreateDto);
            if (result.IsSuccess)
            {
                _logger.LogInformation("Task created successfully.");
                return Ok(result.Message);
            }

            _logger.LogError("Task creation failed.");
            return BadRequest(result.Message);
        }

        
        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        
        [HttpGet("GetTaskById/{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                _logger.LogWarning($"Task with ID {id} not found.");
                return NotFound($"Task with ID {id} not found.");
            }

            return Ok(task);
        }

        
        [HttpPut("UpdateTask/{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskUpdateDto taskUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _taskService.UpdateTaskAsync(id, taskUpdateDto);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"Task with ID {id} updated successfully.");
                return Ok(result.Message);
            }

            _logger.LogError($"Failed to update task with ID {id}.");
            return BadRequest(result.Message);
        }

        
        [HttpDelete("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _taskService.DeleteTaskAsync(id);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"Task with ID {id} deleted successfully.");
                return Ok(result.Message);
            }

            _logger.LogError($"Failed to delete task with ID {id}.");
            return BadRequest(result.Message);
        }
    }
}

