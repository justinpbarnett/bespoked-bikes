using Microsoft.EntityFrameworkCore;
using server.Common.Interfaces;
using server.Features.Products.DTOs;
using server.Infrastructure.Data;
using server.Models;

namespace server.Features.Products.Commands;

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