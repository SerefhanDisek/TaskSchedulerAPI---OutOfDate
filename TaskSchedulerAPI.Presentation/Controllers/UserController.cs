using AutoMapper;
using TaskSchedulerAPI.Core.DTOs;
using TaskSchedulerAPI.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserCreateDto userDto)
    {
        var result = await _userService.RegisterUserAsync(userDto);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto userDto)
    {
        var token = await _userService.LoginUserAsync(userDto.Email);
        if (!string.IsNullOrEmpty(token))
        {
            return Ok(new { Token = token });
        }
        return Unauthorized();
    }

    /*[HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UserUpdateDto userUpdateDto)
    {
        var result = await _userService.UpdateUserAsync(id, userUpdateDto);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }*/

}





















/*[HttpGet]
public async Task<IActionResult> GetUser(int id)

/*[HttpGet("{id}")]
public async Task<IActionResult> GetUser(int id)
{
    var user = await _userService.GetUserByIdAsync(id);
    if (user != null)
    {
        return Ok(user);
    }
    return NotFound();
}

[HttpPut("{id}")]
public async Task<IActionResult> UpdateUser(int id, UserUpdateDto userDto)
{
    var result = await _userService.UpdateUserAsync(id, userDto);
    if (result)
    {
        return NoContent();
    }
    return BadRequest();
}

[HttpDelete("{id}")]
public async Task<IActionResult> DeleteUser(int id)
{
    var result = await _userService.DeleteUserAsync(id);
    if (result)
    {
        return NoContent();
    }
    return NotFound();
}*/