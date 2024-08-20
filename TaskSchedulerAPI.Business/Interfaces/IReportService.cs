using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Business.Interfaces
{
    public interface IReportService
    {
        Task<GenerateReportResult> GenerateReportAsync(GenerateReportDto generateReportDto);
        Task<IEnumerable<ReportDto>> GetAllReportsAsync();
        Task<ReportDto> GetReportByIdAsync(string reportId);
    }
}
