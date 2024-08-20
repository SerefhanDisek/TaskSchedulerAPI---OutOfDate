namespace TaskSchedulerAPI.Core.DTOs
{
    public class UpdateUserSettingsDto
    {
        public string Language { get; set; }
        public string Theme { get; set; }
        public bool ReceiveNotifications { get; set; }
    }
}
