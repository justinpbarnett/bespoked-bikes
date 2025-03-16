namespace server.Features.Sales;

public record SaleCreateDto(
    int ProductId,
    int SalespersonId,
    int CustomerId,
    DateTime SalesDate,
    string? DiscountCode = null
);

public record SaleResponseDto(
    int Id,
    DateTime SalesDate,
    decimal SalePrice,
    decimal CommissionAmount,
    int ProductId,
    string ProductName,
    int SalespersonId,
    string SalespersonFirstName,
    string SalespersonLastName,
    int CustomerId,
    string CustomerFirstName,
    string CustomerLastName,
    decimal OriginalPrice,
    int? AppliedDiscountId,
    decimal AppliedDiscountPercentage,
    string? AppliedDiscountCode = null
);

public record SaleDetailsDto(
    int Id,
    DateTime SalesDate,
    decimal SalePrice,
    decimal OriginalPrice,
    decimal CommissionAmount,
    ProductDto Product,
    SalespersonDto Salesperson,
    CustomerDto Customer,
    DiscountDto? AppliedDiscount,
    string? AppliedDiscountCode = null
);

public record ProductDto(
    int Id,
    string Name
);

public record SalespersonDto(
    int Id,
    string FirstName,
    string LastName
);

public record CustomerDto(
    int Id,
    string FirstName,
    string LastName
);

public record DiscountDto(
    int Id,
    decimal DiscountPercentage,
    DateTime BeginDate,
    DateTime EndDate,
    string? DiscountCode = null,
    bool RequiresCode = false
);
