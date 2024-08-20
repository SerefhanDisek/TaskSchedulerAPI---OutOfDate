namespace TaskSchedulerAPI.Core.DTOs
{
    public class ScheduleTaskDto
    {
        public string TaskName { get; set; }
        public string CronExpression { get; set; } 
        public string TaskDetails { get; set; }    
    }

}
