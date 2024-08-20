using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
