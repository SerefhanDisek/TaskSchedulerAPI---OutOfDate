using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Business.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(string userId);
        Task<OperationResult> UpdateUserAsync(string username, UpdateUserDto updateUserDto);
        Task<OperationResult> DeleteUserAsync(string userId);
        Task<OperationResult> ChangePasswordAsync(string username, ChangePasswordDto changePasswordDto);
    }

}

