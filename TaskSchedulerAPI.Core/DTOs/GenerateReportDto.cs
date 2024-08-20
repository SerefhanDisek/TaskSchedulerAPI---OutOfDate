using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerAPI.Core.DTOs
{
    public class GenerateReportDto
    {
        public string ReportType { get; set; } // Örn: "TaskCompletionRate", "UserActivity", vb.
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
