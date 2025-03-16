using server.Models;

namespace server.Features.Discounts;

public record DiscountDto(
    int Id,
    int? ProductId,
    DateTime BeginDate,
    DateTime EndDate,
    decimal DiscountPercentage,
    ProductDto? Product,
    bool IsGlobal,
    string? DiscountCode = null)
{
    public bool RequiresCode => !string.IsNullOrEmpty(DiscountCode);
};

public record DiscountCreateDto(
    int? ProductId,
    DateTime BeginDate,
    DateTime EndDate,
    decimal DiscountPercentage,
    bool IsGlobal,
    string? DiscountCode = null
);

public record DiscountUpdateDto(
    int? ProductId,
    DateTime BeginDate,
    DateTime EndDate,
    decimal DiscountPercentage,
    bool IsGlobal,
    string? DiscountCode = null
);

public record ProductDto(
    int Id,
    string Name
);

public record DiscountResponseDto(
    bool Success,
    string? ErrorMessage = null,
    DiscountDto? Discount = null
);
