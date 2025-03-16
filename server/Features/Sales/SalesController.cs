using Microsoft.AspNetCore.Mvc;

namespace server.Features.Sales;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly GetSalesQuery _getSalesQuery;
    private readonly GetSaleDetailsQuery _getSaleDetailsQuery;
    private readonly FilterSalesQuery _filterSalesQuery;
    private readonly CreateSaleCommand _createSaleCommand;

    public SalesController(
        GetSalesQuery getSalesQuery,
        GetSaleDetailsQuery getSaleDetailsQuery,
        FilterSalesQuery filterSalesQuery,
        CreateSaleCommand createSaleCommand)
    {
        _getSalesQuery = getSalesQuery;
        _getSaleDetailsQuery = getSaleDetailsQuery;
        _filterSalesQuery = filterSalesQuery;
        _createSaleCommand = createSaleCommand;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SaleResponseDto>>> GetSales()
    {
        var sales = await _getSalesQuery.ExecuteAsync();
        return Ok(sales);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<SaleDetailsDto>> GetSaleDetails(int id)
    {
        var sale = await _getSaleDetailsQuery.ExecuteAsync(id);
        
        if (sale == null)
        {
            return NotFound();
        }
        
        return sale;
    }

    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<SaleResponseDto>>> FilterSales([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
    {
        var sales = await _filterSalesQuery.ExecuteAsync(startDate, endDate);
        return Ok(sales);
    }

    [HttpPost]
    public async Task<ActionResult<SaleResponseDto>> CreateSale(SaleCreateDto saleDto)
    {
        var result = await _createSaleCommand.ExecuteAsync(saleDto);

        if (!result.Success)
        {
            return NotFound(result.ErrorMessage);
        }

        return CreatedAtAction(nameof(GetSales), new { id = result.Sale!.Id }, result.Sale);
    }
}