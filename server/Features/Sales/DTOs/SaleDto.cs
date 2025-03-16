namespace server.Features.Sales.DTOs;

public record SaleCreateDto(
    int ProductId,
    int SalespersonId,
    int CustomerId,
    DateTime SalesDate
);

public record SaleResponseDto(
    int Id,
    DateTime SalesDate,
    decimal SalePrice,
    decimal CommissionAmount,
    ProductDto Product,
    SalespersonDto Salesperson,
    CustomerDto Customer
);

public record ProductDto(int Id, string Name);
public record SalespersonDto(int Id, string FirstName, string LastName);
public record CustomerDto(int Id, string FirstName, string LastName);