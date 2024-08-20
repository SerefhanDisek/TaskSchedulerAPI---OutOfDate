using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Business.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserCreateDto userDto);
        Task<UserDto> AuthenticateUserAsync(string username, string password);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }
}
