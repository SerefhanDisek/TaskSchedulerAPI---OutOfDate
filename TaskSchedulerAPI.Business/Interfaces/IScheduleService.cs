using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Business.Interfaces
{
    public interface IScheduleService
    {
        string ScheduleTask(ScheduleTaskDto scheduleTaskDto);
        IEnumerable<ScheduledTaskDto> GetScheduledTasks();
        bool CancelScheduledTask(string jobId);
    }
}
