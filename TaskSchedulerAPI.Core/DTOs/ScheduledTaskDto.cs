namespace TaskSchedulerAPI.Core.DTOs
{
    public class ScheduledTaskDto
    {
        public string JobId { get; set; }
        public string TaskName { get; set; }
        public string CronExpression { get; set; }
        public string TaskDetails { get; set; }
        public string Status { get; set; } 
    }

}
