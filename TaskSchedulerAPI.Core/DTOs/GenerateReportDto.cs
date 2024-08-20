namespace TaskSchedulerAPI.Core.DTOs
{
    public class GenerateReportDto
    {
        public string ReportType { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
