using Microsoft.AspNetCore.Mvc;

namespace server.Features.Discounts;

[ApiController]
[Route("api/[controller]")]
public class DiscountsController : ControllerBase
{
    private readonly GetDiscountsQuery _getDiscountsQuery;
    private readonly GetDiscountByIdQuery _getDiscountByIdQuery;
    private readonly GetActiveDiscountsForProductQuery _getActiveDiscountsForProductQuery;
    private readonly GetGlobalDiscountsQuery _getGlobalDiscountsQuery;
    private readonly CreateDiscountCommand _createDiscountCommand;
    private readonly UpdateDiscountCommand _updateDiscountCommand;
    private readonly DeleteDiscountCommand _deleteDiscountCommand;

    public DiscountsController(
        GetDiscountsQuery getDiscountsQuery,
        GetDiscountByIdQuery getDiscountByIdQuery,
        GetActiveDiscountsForProductQuery getActiveDiscountsForProductQuery,
        GetGlobalDiscountsQuery getGlobalDiscountsQuery,
        CreateDiscountCommand createDiscountCommand,
        UpdateDiscountCommand updateDiscountCommand,
        DeleteDiscountCommand deleteDiscountCommand)
    {
        _getDiscountsQuery = getDiscountsQuery;
        _getDiscountByIdQuery = getDiscountByIdQuery;
        _getActiveDiscountsForProductQuery = getActiveDiscountsForProductQuery;
        _getGlobalDiscountsQuery = getGlobalDiscountsQuery;
        _createDiscountCommand = createDiscountCommand;
        _updateDiscountCommand = updateDiscountCommand;
        _deleteDiscountCommand = deleteDiscountCommand;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DiscountDto>>> GetDiscounts()
    {
        var discounts = await _getDiscountsQuery.ExecuteAsync();
        return Ok(discounts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DiscountDto>> GetDiscount(int id)
    {
        var discount = await _getDiscountByIdQuery.ExecuteAsync(id);

        if (discount == null)
        {
            return NotFound();
        }

        return discount;
    }

    [HttpGet("active/product/{productId}")]
    public async Task<ActionResult<IEnumerable<DiscountDto>>> GetActiveDiscountsForProduct(int productId, [FromQuery] DateTime? date)
    {
        var activeDate = date ?? DateTime.Now;
        var discounts = await _getActiveDiscountsForProductQuery.ExecuteAsync(productId, activeDate);
        return Ok(discounts);
    }
    
    [HttpGet("global")]
    public async Task<ActionResult<IEnumerable<DiscountDto>>> GetGlobalDiscounts([FromQuery] DateTime? date)
    {
        var discounts = await _getGlobalDiscountsQuery.ExecuteAsync(date);
        return Ok(discounts);
    }

    [HttpPost]
    public async Task<ActionResult<DiscountDto>> CreateDiscount(DiscountCreateDto discountDto)
    {
        var result = await _createDiscountCommand.ExecuteAsync(discountDto);

        if (!result.Success)
        {
            return BadRequest(result.ErrorMessage);
        }

        return CreatedAtAction(nameof(GetDiscount), new { id = result.Discount!.Id }, result.Discount);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDiscount(int id, DiscountUpdateDto discountDto)
    {
        var result = await _updateDiscountCommand.ExecuteAsync(id, discountDto);

        if (!result.Success)
        {
            return result.ErrorMessage switch
            {
                "Discount not found" => NotFound(),
                _ => BadRequest(result.ErrorMessage)
            };
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDiscount(int id)
    {
        var result = await _deleteDiscountCommand.ExecuteAsync(id);

        if (!result.Success)
        {
            return NotFound(result.ErrorMessage);
        }

        return NoContent();
    }
}
