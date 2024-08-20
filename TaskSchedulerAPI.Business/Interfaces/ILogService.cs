using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Business.Interfaces
{
    public interface ILogService
    {
        Task<IEnumerable<LogDto>> GetLogsAsync();
    }
}
