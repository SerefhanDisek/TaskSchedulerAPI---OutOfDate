using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Business.Interfaces
{
    public interface IAuthService
    {
        Task<OperationResult> LoginAsync(UserLoginDto loginDto);
        OperationResult Logout();
        Task<OperationResult> RefreshTokenAsync(TokenRefreshDto tokenRefreshDto);
        Task<OperationResult> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
    }
}
