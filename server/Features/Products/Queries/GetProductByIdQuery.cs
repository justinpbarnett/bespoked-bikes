using server.Common.Interfaces;
using server.Features.Products.DTOs;
using server.Models;

namespace server.Features.Products.Queries;

public class GetProductByIdQuery
{
    private readonly IRepository<Product> _repository;

    public GetProductByIdQuery(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<ProductDto?> ExecuteAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        
        if (product == null)
            return null;
            
        return new ProductDto(
            product.Id,
            product.Name,
            product.Manufacturer,
            product.Style,
            product.PurchasePrice,
            product.SalePrice,
            product.QuantityOnHand,
            product.CommissionPercentage
        );
    }
}