using Microsoft.AspNetCore.Mvc;
using TaskSchedulerAPI.Business.Interfaces;
using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(INotificationService notificationService, ILogger<NotificationController> logger)
        {
            _notificationService = notificationService;
            _logger = logger;
        }

        // POST: api/Notification/SendNotification
        [HttpPost("SendNotification")]
        public async Task<IActionResult> SendNotification([FromBody] SendNotificationDto sendNotificationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _notificationService.SendNotificationAsync(sendNotificationDto);
            if (result.IsSuccess)
            {
                _logger.LogInformation("Notification sent successfully.");
                return Ok(result.Message);
            }

            _logger.LogError("Failed to send notification.");
            return BadRequest(result.Message);
        }

        // GET: api/Notification/GetUserNotifications/{userId}
        [HttpGet("GetUserNotifications/{userId}")]
        public async Task<IActionResult> GetUserNotifications(string userId)
        {
            var notifications = await _notificationService.GetUserNotificationsAsync(userId);
            return Ok(notifications);
        }

        // PUT: api/Notification/MarkAsRead/{notificationId}
        [HttpPut("MarkAsRead/{notificationId}")]
        public async Task<IActionResult> MarkAsRead(string notificationId)
        {
            var result = await _notificationService.MarkAsReadAsync(notificationId);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"Notification {notificationId} marked as read.");
                return Ok(result.Message);
            }

            _logger.LogError($"Failed to mark notification {notificationId} as read.");
            return BadRequest(result.Message);
        }
    }
}
