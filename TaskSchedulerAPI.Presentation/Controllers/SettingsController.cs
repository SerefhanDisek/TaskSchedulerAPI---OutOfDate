using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskSchedulerAPI.Business.Interfaces;
using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettingsController : ControllerBase
    {
        private readonly IUserSettingsService _userSettingsService;
        private readonly ISystemSettingsService _systemSettingsService;
        private readonly ILogger<SettingsController> _logger;

        public SettingsController(IUserSettingsService userSettingsService, ISystemSettingsService systemSettingsService, ILogger<SettingsController> logger)
        {
            _userSettingsService = userSettingsService;
            _systemSettingsService = systemSettingsService;
            _logger = logger;
        }

        // PUT: api/Settings/UpdateUserSettings
        [Authorize]
        [HttpPut("UpdateUserSettings")]
        public async Task<IActionResult> UpdateUserSettings([FromBody] UpdateUserSettingsDto updateUserSettingsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userSettingsService.UpdateUserSettingsAsync(User.Identity.Name, updateUserSettingsDto);
            if (result.IsSuccess)
            {
                _logger.LogInformation("User settings updated successfully.");
                return Ok(result.Message);
            }

            _logger.LogError("Failed to update user settings.");
            return BadRequest(result.Message);
        }

        // PUT: api/Settings/UpdateSystemSettings
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateSystemSettings")]
        public async Task<IActionResult> UpdateSystemSettings([FromBody] UpdateSystemSettingsDto updateSystemSettingsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _systemSettingsService.UpdateSystemSettingsAsync(updateSystemSettingsDto);
            if (result.IsSuccess)
            {
                _logger.LogInformation("System settings updated successfully.");
                return Ok(result.Message);
            }

            _logger.LogError("Failed to update system settings.");
            return BadRequest(result.Message);
        }
    }
}
