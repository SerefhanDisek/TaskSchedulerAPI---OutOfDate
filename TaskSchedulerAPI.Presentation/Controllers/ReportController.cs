using Microsoft.AspNetCore.Mvc;
using TaskSchedulerAPI.Business.Interfaces;
using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly ILogger<ReportController> _logger;

        public ReportController(IReportService reportService, ILogger<ReportController> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        // POST: api/Report/GenerateReport
        [HttpPost("GenerateReport")]
        public async Task<IActionResult> GenerateReport([FromBody] GenerateReportDto generateReportDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _reportService.GenerateReportAsync(generateReportDto);
            if (result.IsSuccess)
            {
                _logger.LogInformation("Report generated successfully.");
                return Ok(new { ReportId = result.ReportId, Message = result.Message });
            }

            _logger.LogError("Failed to generate report.");
            return BadRequest(result.Message);
        }

        // GET: api/Report/GetAllReports
        [HttpGet("GetAllReports")]
        public async Task<IActionResult> GetAllReports()
        {
            var reports = await _reportService.GetAllReportsAsync();
            return Ok(reports);
        }

        // GET: api/Report/GetReportById/{reportId}
        [HttpGet("GetReportById/{reportId}")]
        public async Task<IActionResult> GetReportById(string reportId)
        {
            var report = await _reportService.GetReportByIdAsync(reportId);
            if (report == null)
            {
                _logger.LogWarning($"Report with ID {reportId} not found.");
                return NotFound($"Report with ID {reportId} not found.");
            }

            return Ok(report);
        }
    }
}
