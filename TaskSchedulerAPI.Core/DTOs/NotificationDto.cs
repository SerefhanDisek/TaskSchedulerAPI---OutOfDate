namespace TaskSchedulerAPI.Core.DTOs
{
    public class NotificationDto
    {
        public string NotificationId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime SentTime { get; set; }
    }
}
