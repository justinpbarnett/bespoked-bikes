using Microsoft.EntityFrameworkCore;
using server.Common.Interfaces;
using server.Infrastructure.Data;
using server.Models;

namespace server.Features.Products;

public class UpdateProductCommand
{
    private readonly IRepository<Product> _repository;
    private readonly ApplicationDbContext _context;

    public UpdateProductCommand(IRepository<Product> repository, ApplicationDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<(bool Success, string? ErrorMessage)> ExecuteAsync(int id, ProductDto dto)
    {
        if (id != dto.Id)
        {
            return (false, "ID mismatch between route and payload");
        }

        var existingProduct = await _repository.GetByIdAsync(id);
        if (existingProduct == null)
        {
            return (false, "Product not found");
        }

        // Don't allow changing the name if it's already taken
        if (dto.Name != existingProduct.Name &&
            await _context.Products.AnyAsync(p => p.Name == dto.Name))
        {
            return (false, $"A product with the name '{dto.Name}' already exists.");
        }

        existingProduct.Name = dto.Name;
        existingProduct.Manufacturer = dto.Manufacturer;
        existingProduct.Style = dto.Style;
        existingProduct.PurchasePrice = dto.PurchasePrice;
        existingProduct.SalePrice = dto.SalePrice;
        existingProduct.QuantityOnHand = dto.QuantityOnHand;
        existingProduct.CommissionPercentage = dto.CommissionPercentage;

        await _repository.UpdateAsync(existingProduct);

        return (true, null);
    }
}

public class CreateProductCommand
{
    private readonly IRepository<Product> _repository;
    private readonly ApplicationDbContext _context;

    public CreateProductCommand(IRepository<Product> repository, ApplicationDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<(bool Success, ProductDto? Product, string? ErrorMessage)> ExecuteAsync(CreateProductDto dto)
    {
        // Check for duplicates
        if (await _context.Products.AnyAsync(p => p.Name == dto.Name))
        {
            return (false, null, $"A product with the name '{dto.Name}' already exists.");
        }

        var product = new Product
        {
            Name = dto.Name,
            Manufacturer = dto.Manufacturer,
            Style = dto.Style,
            PurchasePrice = dto.PurchasePrice,
            SalePrice = dto.SalePrice,
            QuantityOnHand = dto.QuantityOnHand,
            CommissionPercentage = dto.CommissionPercentage
        };

        await _repository.AddAsync(product);

        return (true, new ProductDto(
            product.Id,
            product.Name,
            product.Manufacturer,
            product.Style,
            product.PurchasePrice,
            product.SalePrice,
            product.QuantityOnHand,
            product.CommissionPercentage
        ), null);
    }
}