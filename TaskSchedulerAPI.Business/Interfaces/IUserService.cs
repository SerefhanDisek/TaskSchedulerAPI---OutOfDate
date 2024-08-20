using TaskSchedulerAPI.Core.DTOs;
using TaskSchedulerAPI.Core.Entities;

namespace TaskSchedulerAPI.Business.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserCreateDto userDto);
        Task<UserDto> AuthenticateUserAsync(string username, string password);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> LoginUserAsync(UserLoginDto userLoginDto);
        Task<string?> LoginUserAsync(string email);
        Task<object?> UpdateUserAsync(int id, UserUpdateDto userUpdateDto);
        
    }
}
