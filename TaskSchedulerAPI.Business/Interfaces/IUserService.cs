using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Business.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<OperationResult> UpdateUserAsync(int userId, UpdateUserDto updateUserDto);
        Task<OperationResult> DeleteUserAsync(int userId);
        Task<OperationResult> ChangePasswordAsync(string username, ChangePasswordDto changePasswordDto);
        Task<OperationResult> ManageUserAsync(UserManagementDto managementDto);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }

}

