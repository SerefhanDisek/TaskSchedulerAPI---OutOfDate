using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Business.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllTasksAsync();
        Task<bool> CreateTaskAsync(TaskCreateDto taskDto);
        Task AssignTasksToUsersAsync();

        
    }
}

