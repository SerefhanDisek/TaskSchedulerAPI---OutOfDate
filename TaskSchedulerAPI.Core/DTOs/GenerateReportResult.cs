using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerAPI.Core.DTOs
{
    public class GenerateReportResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string ReportId { get; set; }
    }
}
