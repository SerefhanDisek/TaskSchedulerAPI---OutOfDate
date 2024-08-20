using TaskSchedulerAPI.Core.Entities;

namespace TaskSchedulerAPI.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByUsernameAsync(string username);
        Task<bool> AddAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> SaveChangesAsync();
    }
}

