namespace TaskSchedulerAPI.Core.DTOs
{
    public class ReportDto
    {
        public string ReportId { get; set; }
        public string ReportType { get; set; }
        public DateTime GeneratedOn { get; set; }
        public string GeneratedBy { get; set; }
        public string ReportData { get; set; }
    }
}
