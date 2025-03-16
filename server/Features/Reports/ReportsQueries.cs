using Microsoft.EntityFrameworkCore;
using server.Infrastructure.Data;

namespace server.Features.Reports;

public class GetCommissionReportQuery
{
    private readonly ApplicationDbContext _context;

    public GetCommissionReportQuery(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CommissionReportDto> ExecuteAsync(int year, int quarter)
    {
        // Determine date range for the quarter
        var startDate = new DateTime(year, (quarter - 1) * 3 + 1, 1);
        var endDate = startDate.AddMonths(3).AddDays(-1);

        // Get all salespersons who were active during the quarter
        var activeSalespersons = await _context.Salespersons
            .Where(s => s.StartDate <= endDate &&
                      (s.TerminationDate == null || s.TerminationDate >= startDate))
            .ToListAsync();

        // Get all sales for the quarter with related data
        var quarterSales = await _context.Sales
            .Include(s => s.Product)
            .Include(s => s.Customer)
            .Where(s => s.SalesDate >= startDate && s.SalesDate <= endDate)
            .OrderBy(s => s.SalespersonId)
            .ThenByDescending(s => s.SalesDate)
            .ToListAsync();
            
        // Get quarterly summary per salesperson
        var salesByPerson = quarterSales
            .GroupBy(s => s.SalespersonId)
            .Select(g => new
            {
                SalespersonId = g.Key,
                TotalSales = g.Count(),
                TotalRevenue = g.Sum(s => s.SalePrice),
                TotalCommission = g.Sum(s => s.CommissionAmount),
                AverageCommissionRate = g.Average(s => s.CommissionAmount / s.SalePrice * 100),
                HighestSale = g.Max(s => s.SalePrice),
                LowestSale = g.Min(s => s.SalePrice),
                FirstSaleDate = g.Min(s => s.SalesDate),
                LastSaleDate = g.Max(s => s.SalesDate)
            })
            .ToList();

        // Get salesperson details
        var salespersonIds = salesByPerson.Select(s => s.SalespersonId).ToList();
        var salespersons = await _context.Salespersons
            .Where(s => salespersonIds.Contains(s.Id))
            .ToDictionaryAsync(s => s.Id, s => new { s.FirstName, s.LastName, s.StartDate, s.Manager });

        // We'll use the quarterSales for other operations to avoid redundant database calls
        var salesInRange = quarterSales;
            
        // Get all products
        var products = await _context.Products.ToListAsync();
        
        // Join sales with products for detailed analysis
        var salesWithProducts = salesInRange
            .Join(products,
                s => s.ProductId,
                p => p.Id,
                (s, p) => new { Sale = s, Product = p })
            .ToList();
            
        // Get product sales by category
        var productStyleSales = salesWithProducts
            .GroupBy(j => j.Product.Style)
            .Select(g => new ProductStyleSaleDto(
                g.Key,
                g.Count(),
                g.Sum(j => j.Sale.SalePrice),
                g.Sum(j => j.Sale.CommissionAmount),
                g.Average(j => j.Sale.SalePrice)
            ))
            .ToList();
            
        var monthlySales = salesInRange
            .GroupBy(s => new { Month = s.SalesDate.Month, Year = s.SalesDate.Year })
            .Select(g => new MonthlySummaryDto(
                g.Key.Month,
                g.Key.Year,
                g.Count(),
                g.Sum(s => s.SalePrice),
                g.Sum(s => s.CommissionAmount)
            ))
            .OrderBy(m => m.Year)
            .ThenBy(m => m.Month)
            .ToList();

        // Get top products by revenue
        var topProducts = salesWithProducts
            .GroupBy(j => new { j.Product.Id, j.Product.Name, j.Product.Manufacturer })
            .Select(g => new TopProductDto(
                g.Key.Id,
                g.Key.Name,
                g.Key.Manufacturer,
                g.Count(),
                g.Sum(j => j.Sale.SalePrice),
                g.Sum(j => j.Sale.CommissionAmount)
            ))
            .OrderByDescending(p => p.TotalRevenue)
            .Take(5)
            .ToList();

        // Combine data for salesperson report
        var salespersonReport = salesByPerson.Select(s => new SalespersonReportDto(
            s.SalespersonId,
            salespersons.GetValueOrDefault(s.SalespersonId)?.FirstName ?? "Unknown",
            salespersons.GetValueOrDefault(s.SalespersonId)?.LastName ?? "Unknown",
            salespersons.GetValueOrDefault(s.SalespersonId)?.Manager,
            salespersons.GetValueOrDefault(s.SalespersonId)?.StartDate ?? DateTime.MinValue,
            s.TotalSales,
            s.TotalRevenue,
            s.TotalCommission,
            Math.Round(s.AverageCommissionRate, 2),
            s.HighestSale,
            s.LowestSale,
            s.FirstSaleDate,
            s.LastSaleDate,
            quarterSales
                .Where(qs => qs.SalespersonId == s.SalespersonId)
                .Select(qs => new DetailedSaleDto(
                    qs.Id,
                    qs.SalesDate,
                    qs.ProductId,
                    qs.Product.Name,
                    qs.CustomerId,
                    $"{qs.Customer.FirstName} {qs.Customer.LastName}",
                    qs.SalePrice,
                    qs.CommissionAmount,
                    Math.Round(qs.CommissionAmount / qs.SalePrice * 100, 2)
                ))
                .ToList()
        )).ToList();

        // Create a list to hold all salesperson reports
        var allSalespersons = new List<SalespersonReportDto>();

        // Add salespersons with sales
        foreach (var sp in salespersonReport)
        {
            allSalespersons.Add(sp);
        }

        // Add salespersons with no sales
        foreach (var s in activeSalespersons.Where(s => !salespersonIds.Contains(s.Id)))
        {
            allSalespersons.Add(new SalespersonReportDto(
                s.Id,
                s.FirstName,
                s.LastName,
                s.Manager,
                s.StartDate,
                0,
                0.0m,
                0.0m,
                0.0m,
                0.0m,
                0.0m,
                null,
                null,
                new List<DetailedSaleDto>()
            ));
        }

        // Sort by commission
        allSalespersons = allSalespersons
            .OrderByDescending(s => s.TotalCommission)
            .ToList();

        var salespersonsWithSalesCount = salespersonReport.Count;

        var averageCommissionRate = quarterSales.Any()
            ? Math.Round(quarterSales.Average(s => s.CommissionAmount / s.SalePrice * 100), 2)
            : 0;
        
        var averageSalePrice = quarterSales.Any()
            ? Math.Round(quarterSales.Average(s => s.SalePrice), 2)
            : 0;
            
        return new CommissionReportDto(
            year,
            quarter,
            startDate,
            endDate,
            new QuarterSummaryDto(
                quarterSales.Count,
                quarterSales.Sum(s => s.SalePrice),
                quarterSales.Sum(s => s.CommissionAmount),
                averageCommissionRate,
                averageSalePrice,
                allSalespersons.Count,
                salespersonsWithSalesCount
            ),
            productStyleSales,
            monthlySales,
            topProducts,
            allSalespersons
        );
    }
}