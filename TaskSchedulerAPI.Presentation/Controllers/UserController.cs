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
}
