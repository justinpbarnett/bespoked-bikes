using Microsoft.AspNetCore.Mvc;

namespace server.Features.Reports;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly GetCommissionReportQuery _getCommissionReportQuery;

    public ReportsController(GetCommissionReportQuery getCommissionReportQuery)
    {
        _getCommissionReportQuery = getCommissionReportQuery;
    }

    [HttpGet("commission")]
    public async Task<ActionResult<CommissionReportDto>> GetCommissionReport([FromQuery] int year, [FromQuery] int quarter)
    {
        var report = await _getCommissionReportQuery.ExecuteAsync(year, quarter);
        return Ok(report);
    }
}