namespace server.Features.Dashboard;

public record DashboardSummaryDto(
    decimal TotalRevenue,
    int TotalSales,
    int ActiveSalespersons,
    int InventoryAlerts,
    int LowStockCount,
    int OutOfStockCount,
    decimal RevenueChangePercentage,
    decimal SalesChangePercentage,
    int TotalProducts,
    decimal InventoryValue
);

public record RecentSaleDto(
    int Id,
    DateTime SalesDate,
    decimal SalePrice,
    string Product,
    string Salesperson,
    string Customer
);

public record MonthlySalesDto(
    string Year,
    List<MonthlySalesDataPoint> Data
);

public record MonthlySalesDataPoint(
    string Label,
    decimal Sales,
    decimal Commission
);

public record TopSalespersonDto(
    int Id,
    string Name,
    string Avatar,
    decimal Sales,
    decimal Target
);

public record InventoryAlertDto(
    List<ProductAlertDto> OutOfStock,
    List<ProductAlertDto> LowStock
);

public record ProductAlertDto(
    int Id,
    string Name,
    string Manufacturer,
    int QuantityOnHand,
    string Status,
    int? ReorderLevel = null
);

public record ProductPerformanceDto(
    int Id,
    string Name,
    int Sales,
    decimal Revenue,
    decimal Percentage
);