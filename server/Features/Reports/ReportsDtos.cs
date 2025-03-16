namespace server.Features.Reports;

public record CommissionReportDto(
    int Year,
    int Quarter,
    DateTime StartDate,
    DateTime EndDate,
    QuarterSummaryDto QuarterSummary,
    List<ProductStyleSaleDto> ProductStyles,
    List<MonthlySummaryDto> MonthlySummary,
    List<TopProductDto> TopProducts,
    List<SalespersonReportDto> Commissions
);

public record QuarterSummaryDto(
    int TotalSales,
    decimal TotalRevenue,
    decimal TotalCommission,
    decimal AverageCommissionRate,
    decimal AverageSalePrice,
    int SalespersonCount,
    int SalespersonsWithSales
);

public record ProductStyleSaleDto(
    string Style,
    int TotalSales,
    decimal TotalRevenue,
    decimal TotalCommission,
    decimal AveragePrice
);

public record MonthlySummaryDto(
    int Month,
    int Year,
    int TotalSales,
    decimal TotalRevenue,
    decimal TotalCommission
);

public record TopProductDto(
    int ProductId,
    string ProductName,
    string Manufacturer,
    int TotalSales,
    decimal TotalRevenue,
    decimal TotalCommission
);

public record SalespersonReportDto(
    int SalespersonId,
    string FirstName,
    string LastName,
    string? Manager,
    DateTime StartDate,
    int TotalSales,
    decimal TotalRevenue,
    decimal TotalCommission,
    decimal AverageCommissionRate,
    decimal HighestSale,
    decimal LowestSale,
    DateTime? FirstSaleDate,
    DateTime? LastSaleDate,
    List<DetailedSaleDto> DetailedSales
);

public record DetailedSaleDto(
    int SaleId,
    DateTime SalesDate,
    int ProductId,
    string ProductName,
    int CustomerId,
    string CustomerName,
    decimal SalePrice,
    decimal CommissionAmount,
    decimal CommissionRate
);