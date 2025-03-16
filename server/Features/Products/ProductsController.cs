using Microsoft.AspNetCore.Mvc;

namespace server.Features.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(
    GetProductsQuery getProductsQuery,
    GetProductByIdQuery getProductByIdQuery,
    CreateProductCommand createProductCommand,
    UpdateProductCommand updateProductCommand) : ControllerBase
{
    private readonly GetProductsQuery _getProductsQuery = getProductsQuery;
    private readonly GetProductByIdQuery _getProductByIdQuery = getProductByIdQuery;
    private readonly CreateProductCommand _createProductCommand = createProductCommand;
    private readonly UpdateProductCommand _updateProductCommand = updateProductCommand;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var products = await _getProductsQuery.ExecuteAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await _getProductByIdQuery.ExecuteAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto productDto)
    {
        var result = await _createProductCommand.ExecuteAsync(productDto);

        if (!result.Success)
        {
            return BadRequest(result.ErrorMessage);
        }

        return CreatedAtAction(nameof(GetProduct), new { id = result.Product!.Id }, result.Product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
    {
        var result = await _updateProductCommand.ExecuteAsync(id, productDto);

        if (!result.Success)
        {
            return result.ErrorMessage switch
            {
                "Product not found" => NotFound(),
                _ => BadRequest(result.ErrorMessage)
            };
        }

        return NoContent();
    }
}