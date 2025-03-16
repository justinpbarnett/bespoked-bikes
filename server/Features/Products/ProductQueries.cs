using server.Common.Interfaces;
using server.Models;

namespace server.Features.Products;

public class GetProductsQuery(IRepository<Product> repository)
{
    private readonly IRepository<Product> _repository = repository;

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

public class GetProductByIdQuery(IRepository<Product> repository)
{
    private readonly IRepository<Product> _repository = repository;

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