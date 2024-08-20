using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskSchedulerAPI.Core.DTOs;
using TaskSchedulerAPI.Business.Interfaces;

namespace TaskSchedulerAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        // POST: api/Auth/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.LoginAsync(loginDto);
            if (result.IsSuccess)
            {
                _logger.LogInformation("User logged in successfully.");
                return Ok(new { Token = result.Token, RefreshToken = result.RefreshToken });
            }

            _logger.LogWarning("Login failed.");
            return Unauthorized(result.Message);
        }

        // POST: api/Auth/Logout
        [Authorize]
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            var result = _authService.Logout();
            if (result.IsSuccess)
            {
                _logger.LogInformation("User logged out successfully.");
                return Ok(result.Message);
            }

            _logger.LogWarning("Logout failed.");
            return BadRequest(result.Message);
        }

        // POST: api/Auth/RefreshToken
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRefreshDto tokenRefreshDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RefreshTokenAsync(tokenRefreshDto);
            if (result.IsSuccess)
            {
                _logger.LogInformation("Token refreshed successfully.");
                return Ok(new { Token = result.Token, RefreshToken = result.RefreshToken });
            }

            _logger.LogWarning("Token refresh failed.");
            return Unauthorized(result.Message);
        }

        // POST: api/Auth/ResetPassword
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.ResetPasswordAsync(resetPasswordDto);
            if (result.IsSuccess)
            {
                _logger.LogInformation("Password reset successfully.");
                return Ok(result.Message);
            }

            _logger.LogWarning("Password reset failed.");
            return BadRequest(result.Message);
        }
    }
}

