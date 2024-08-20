using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Business.Interfaces
{
    public interface ITaskService
    {
        Task<OperationResult> CreateTaskAsync(TaskCreateDto taskCreateDto);
        Task<IEnumerable<TaskDto>> GetAllTasksAsync();
        Task<TaskDto> GetTaskByIdAsync(int id);
        Task<OperationResult> UpdateTaskAsync(int id, TaskUpdateDto taskUpdateDto);
        Task<OperationResult> DeleteTaskAsync(int id);
        Task<OperationResult> ManageTaskAsync(TaskManagementDto taskManagementDto);
    }
}

