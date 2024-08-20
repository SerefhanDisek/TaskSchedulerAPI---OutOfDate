using TaskSchedulerAPI.Core.Entities;
using Task = TaskSchedulerAPI.Core.Entities.Task;

namespace TaskSchedulerAPI.DataAccess.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetAllTasksAsync();
        Task<Task> GetTaskByIdAsync(int taskId);
        Task<bool> AddAsync(Task task);
        Task<IEnumerable<Task>> GetUnassignedTasksAsync();
        Task<bool> SaveChangesAsync();
    }
}
