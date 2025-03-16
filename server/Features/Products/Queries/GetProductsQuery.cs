using server.Common.Interfaces;
using server.Features.Products.DTOs;
using server.Models;

namespace server.Features.Products.Queries;

public class GetProductsQuery
{
    private readonly IRepository<Product> _repository;

    public GetProductsQuery(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductDto>> ExecuteAsync()
    {
        var products = await _repository.GetAllAsync();
        
        return products.Select(p => new ProductDto(
            p.Id,
            p.Name,
            p.Manufacturer,
            p.Style,
            p.PurchasePrice,
            p.SalePrice,
            p.QuantityOnHand,
            p.CommissionPercentage
        ));
    }
}