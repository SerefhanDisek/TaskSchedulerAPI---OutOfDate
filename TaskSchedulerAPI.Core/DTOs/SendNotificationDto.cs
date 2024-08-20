namespace TaskSchedulerAPI.Core.DTOs
{
    public class SendNotificationDto
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime? ScheduledTime { get; set; }
    }
}
