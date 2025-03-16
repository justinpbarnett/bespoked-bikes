using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace server.Features.Dashboard;

[ApiController]
[Route("api/[controller]")]
[EnableCors("AllowReactApp")]
public class DashboardController : ControllerBase
{
    private readonly GetDashboardSummaryQuery _getDashboardSummaryQuery;
    private readonly GetRecentSalesQuery _getRecentSalesQuery;
    private readonly GetMonthlySalesQuery _getMonthlySalesQuery;
    private readonly GetTopSalespersonsQuery _getTopSalespersonsQuery;
    private readonly GetInventoryAlertsQuery _getInventoryAlertsQuery;
    private readonly GetProductPerformanceQuery _getProductPerformanceQuery;

    public DashboardController(
        GetDashboardSummaryQuery getDashboardSummaryQuery,
        GetRecentSalesQuery getRecentSalesQuery,
        GetMonthlySalesQuery getMonthlySalesQuery,
        GetTopSalespersonsQuery getTopSalespersonsQuery,
        GetInventoryAlertsQuery getInventoryAlertsQuery,
        GetProductPerformanceQuery getProductPerformanceQuery)
    {
        _getDashboardSummaryQuery = getDashboardSummaryQuery;
        _getRecentSalesQuery = getRecentSalesQuery;
        _getMonthlySalesQuery = getMonthlySalesQuery;
        _getTopSalespersonsQuery = getTopSalespersonsQuery;
        _getInventoryAlertsQuery = getInventoryAlertsQuery;
        _getProductPerformanceQuery = getProductPerformanceQuery;
    }

    [HttpGet("summary")]
    public async Task<ActionResult<DashboardSummaryDto>> GetDashboardSummary()
    {
        var summary = await _getDashboardSummaryQuery.ExecuteAsync();
        return Ok(summary);
    }

    [HttpGet("recent-sales")]
    public async Task<ActionResult<IEnumerable<RecentSaleDto>>> GetRecentSales([FromQuery] int count)
    {
        var sales = await _getRecentSalesQuery.ExecuteAsync(count);
        return Ok(sales);
    }

    [HttpGet("monthly-sales")]
    public async Task<ActionResult<MonthlySalesDto>> GetMonthlySales([FromQuery] string year)
    {
        if (string.IsNullOrEmpty(year))
        {
            return BadRequest("Year parameter is required");
        }

        try
        {
            var salesData = await _getMonthlySalesQuery.ExecuteAsync(year);
            return Ok(salesData);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("top-salespersons")]
    public async Task<ActionResult<IEnumerable<TopSalespersonDto>>> GetTopSalespersons([FromQuery] int count)
    {
        var salespersons = await _getTopSalespersonsQuery.ExecuteAsync(count);
        return Ok(salespersons);
    }

    [HttpGet("inventory-alerts")]
    public async Task<ActionResult<InventoryAlertDto>> GetInventoryAlerts()
    {
        var alerts = await _getInventoryAlertsQuery.ExecuteAsync();
        return Ok(alerts);
    }

    [HttpGet("product-performance")]
    public async Task<ActionResult<IEnumerable<ProductPerformanceDto>>> GetProductPerformance()
    {
        var performance = await _getProductPerformanceQuery.ExecuteAsync();
        return Ok(performance);
    }
}