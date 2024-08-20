using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskSchedulerAPI.Business.Interfaces;
using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITaskService _taskService;
        private readonly ILogService _logService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IUserService userService, ITaskService taskService, ILogService logService, ILogger<AdminController> logger)
        {
            _userService = userService;
            _taskService = taskService;
            _logService = logService;
            _logger = logger;
        }

        
        [HttpGet("ManageUsers")]
        public async Task<IActionResult> ManageUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        
        [HttpPost("ManageUsers")]
        public async Task<IActionResult> ManageUsers([FromBody] UserManagementDto userManagementDto)
        {
            var result = await _userService.ManageUserAsync(userManagementDto);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"User {userManagementDto.UserId} managed successfully.");
                return Ok(result.Message);
            }

            _logger.LogError($"Failed to manage user {userManagementDto.UserId}.");
            return BadRequest(result.Message);
        }

        
        [HttpGet("ManageTasks")]
        public async Task<IActionResult> ManageTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

       
        [HttpPost("ManageTasks")]
        public async Task<IActionResult> ManageTasks([FromBody] TaskManagementDto taskManagementDto)
        {
            var result = await _taskService.ManageTaskAsync(taskManagementDto);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"Task {taskManagementDto.TaskId} managed successfully.");
                return Ok(result.Message);
            }

            _logger.LogError($"Failed to manage task {taskManagementDto.TaskId}.");
            return BadRequest(result.Message);
        }

        
        [HttpGet("ViewLogs")]
        public async Task<IActionResult> ViewLogs()
        {
            var logs = await _logService.GetLogsAsync();
            return Ok(logs);
        }
    }
}
