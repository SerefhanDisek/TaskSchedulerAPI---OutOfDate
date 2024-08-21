using AutoMapper;
using TaskSchedulerAPI.Core.DTOs;
using TaskSchedulerAPI.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TaskSchedulerAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    
    [Authorize]
    [HttpGet("GetUserById/{userId}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);
        if (user == null)
        {
            _logger.LogWarning($"User with ID {userId} not found.");
            return NotFound($"User with ID {userId} not found.");
        }

        return Ok(user);
    }


    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        
        if (!int.TryParse(User.Identity.Name, out int userId))
        {
            return BadRequest("Invalid user ID.");
        }

        var result = await _userService.UpdateUserAsync(userId, updateUserDto);
        if (result.IsSuccess)
        {
            _logger.LogInformation("User updated successfully.");
            return Ok(result.Message);
        }

        _logger.LogError("Failed to update user.");
        return BadRequest(result.Message);
    }



    [Authorize(Roles = "Admin")]
    [HttpDelete("DeleteUser/{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        var result = await _userService.DeleteUserAsync(userId);
        if (result.IsSuccess)
        {
            _logger.LogInformation($"User with ID {userId} deleted successfully.");
            return Ok(result.Message);
        }

        _logger.LogError($"Failed to delete user with ID {userId}.");
        return BadRequest(result.Message);
    }

    
    [Authorize]
    [HttpPost("ChangePassword")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userService.ChangePasswordAsync(User.Identity.Name, changePasswordDto);
        if (result.IsSuccess)
        {
            _logger.LogInformation("Password changed successfully.");
            return Ok(result.Message);
        }

        _logger.LogError("Failed to change password.");
        return BadRequest(result.Message);
    }
}

