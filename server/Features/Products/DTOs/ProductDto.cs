namespace server.Features.Products.DTOs;

public record ProductDto(
    int Id,
    string Name,
    string Manufacturer,
    string Style,
    decimal PurchasePrice,
    decimal SalePrice,
    int QuantityOnHand,
    decimal CommissionPercentage
);

public record CreateProductDto(
    string Name,
    string Manufacturer,
    string Style,
    decimal PurchasePrice,
    decimal SalePrice,
    int QuantityOnHand,
    decimal CommissionPercentage
);