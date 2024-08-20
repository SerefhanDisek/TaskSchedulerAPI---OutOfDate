using Microsoft.AspNetCore.Mvc;
using TaskSchedulerAPI.Business.Interfaces;
using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly ILogger<ScheduleController> _logger;

        public ScheduleController(IScheduleService scheduleService, ILogger<ScheduleController> logger)
        {
            _scheduleService = scheduleService;
            _logger = logger;
        }

        
        [HttpPost("ScheduleTask")]
        public IActionResult ScheduleTask([FromBody] ScheduleTaskDto scheduleTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobId = _scheduleService.ScheduleTask(scheduleTaskDto);
            if (!string.IsNullOrEmpty(jobId))
            {
                _logger.LogInformation($"Task scheduled successfully with Job ID: {jobId}");
                return Ok(new { JobId = jobId });
            }

            _logger.LogError("Task scheduling failed.");
            return BadRequest("Task scheduling failed.");
        }

        
        [HttpGet("GetScheduledTasks")]
        public IActionResult GetScheduledTasks()
        {
            var tasks = _scheduleService.GetScheduledTasks();
            return Ok(tasks);
        }

        
        [HttpDelete("CancelScheduledTask/{jobId}")]
        public IActionResult CancelScheduledTask(string jobId)
        {
            var result = _scheduleService.CancelScheduledTask(jobId);
            if (result)
            {
                _logger.LogInformation($"Task with Job ID {jobId} cancelled successfully.");
                return Ok($"Task with Job ID {jobId} cancelled successfully.");
            }

            _logger.LogError($"Failed to cancel task with Job ID {jobId}.");
            return BadRequest($"Failed to cancel task with Job ID {jobId}.");
        }
    }
}
