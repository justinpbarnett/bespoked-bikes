using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("commission")]
        public async Task<ActionResult<object>> GetCommissionReport([FromQuery] int year, [FromQuery] int quarter)
        {
            // Determine date range for the quarter
            var startDate = new DateTime(year, (quarter - 1) * 3 + 1, 1);
            var endDate = startDate.AddMonths(3).AddDays(-1);

            // Get all salespersons who were active during the quarter
            var activeSalespersons = await _context.Salespersons
                .Where(s => s.StartDate <= endDate && 
                           (s.TerminationDate == null || s.TerminationDate >= startDate))
                .ToListAsync();

            // Get quarterly summary per salesperson
            var salesByPerson = await _context.Sales
                .Where(s => s.SalesDate >= startDate && s.SalesDate <= endDate)
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
                .ToListAsync();

            // Get detailed sales data for the quarter
            var quarterSales = await _context.Sales
                .Include(s => s.Product)
                .Include(s => s.Customer)
                .Where(s => s.SalesDate >= startDate && s.SalesDate <= endDate)
                .OrderBy(s => s.SalespersonId)
                .ThenByDescending(s => s.SalesDate)
                .ToListAsync();

            // Get salesperson details
            var salespersonIds = salesByPerson.Select(s => s.SalespersonId).ToList();
            var salespersons = await _context.Salespersons
                .Where(s => salespersonIds.Contains(s.Id))
                .ToDictionaryAsync(s => s.Id, s => new { s.FirstName, s.LastName, s.StartDate, s.Manager });

            // Get product sales by category
            var productStyleSales = await _context.Sales
                .Join(_context.Products, 
                    s => s.ProductId, 
                    p => p.Id, 
                    (s, p) => new { Sale = s, Product = p })
                .Where(j => j.Sale.SalesDate >= startDate && j.Sale.SalesDate <= endDate)
                .GroupBy(j => j.Product.Style)
                .Select(g => new
                {
                    Style = g.Key,
                    TotalSales = g.Count(),
                    TotalRevenue = g.Sum(j => j.Sale.SalePrice),
                    TotalCommission = g.Sum(j => j.Sale.CommissionAmount),
                    AveragePrice = g.Average(j => j.Sale.SalePrice)
                })
                .ToListAsync();

            // Get monthly breakdown of sales within the quarter
            var monthlySales = await _context.Sales
                .Where(s => s.SalesDate >= startDate && s.SalesDate <= endDate)
                .GroupBy(s => new { Month = s.SalesDate.Month, Year = s.SalesDate.Year })
                .Select(g => new
                {
                    Month = g.Key.Month,
                    Year = g.Key.Year,
                    TotalSales = g.Count(),
                    TotalRevenue = g.Sum(s => s.SalePrice),
                    TotalCommission = g.Sum(s => s.CommissionAmount)
                })
                .OrderBy(m => m.Year)
                .ThenBy(m => m.Month)
                .ToListAsync();

            // Get top products by revenue
            var topProducts = await _context.Sales
                .Where(s => s.SalesDate >= startDate && s.SalesDate <= endDate)
                .Join(_context.Products,
                    s => s.ProductId,
                    p => p.Id,
                    (s, p) => new { Sale = s, Product = p })
                .GroupBy(j => new { j.Product.Id, j.Product.Name, j.Product.Manufacturer })
                .Select(g => new
                {
                    ProductId = g.Key.Id,
                    ProductName = g.Key.Name,
                    Manufacturer = g.Key.Manufacturer,
                    TotalSales = g.Count(),
                    TotalRevenue = g.Sum(j => j.Sale.SalePrice),
                    TotalCommission = g.Sum(j => j.Sale.CommissionAmount)
                })
                .OrderByDescending(p => p.TotalRevenue)
                .Take(5)
                .ToListAsync();

            // Combine data for salesperson report
            var salespersonReport = salesByPerson.Select(s => new
            {
                SalespersonId = s.SalespersonId,
                FirstName = salespersons.GetValueOrDefault(s.SalespersonId)?.FirstName ?? "Unknown",
                LastName = salespersons.GetValueOrDefault(s.SalespersonId)?.LastName ?? "Unknown",
                Manager = salespersons.GetValueOrDefault(s.SalespersonId)?.Manager,
                StartDate = salespersons.GetValueOrDefault(s.SalespersonId)?.StartDate,
                TotalSales = s.TotalSales,
                TotalRevenue = s.TotalRevenue,
                TotalCommission = s.TotalCommission,
                AverageCommissionRate = Math.Round(s.AverageCommissionRate, 2),
                HighestSale = s.HighestSale,
                LowestSale = s.LowestSale,
                FirstSaleDate = s.FirstSaleDate,
                LastSaleDate = s.LastSaleDate,
                DetailedSales = quarterSales
                    .Where(qs => qs.SalespersonId == s.SalespersonId)
                    .Select(qs => new {
                        SaleId = qs.Id,
                        SalesDate = qs.SalesDate,
                        ProductId = qs.ProductId,
                        ProductName = qs.Product.Name,
                        CustomerId = qs.CustomerId,
                        CustomerName = $"{qs.Customer.FirstName} {qs.Customer.LastName}",
                        SalePrice = qs.SalePrice,
                        CommissionAmount = qs.CommissionAmount,
                        CommissionRate = Math.Round(qs.CommissionAmount / qs.SalePrice * 100, 2)
                    })
                    .ToList()
            }).ToList();

            // Create a list to hold all salesperson reports
            var allSalespersons = new List<object>();
            
            // Add salespersons with sales
            foreach (var sp in salespersonReport)
            {
                allSalespersons.Add(new
                {
                    sp.SalespersonId,
                    sp.FirstName,
                    sp.LastName,
                    sp.Manager,
                    sp.StartDate,
                    sp.TotalSales,
                    sp.TotalRevenue,
                    sp.TotalCommission,
                    sp.AverageCommissionRate,
                    sp.HighestSale,
                    sp.LowestSale,
                    sp.FirstSaleDate,
                    sp.LastSaleDate,
                    sp.DetailedSales
                });
            }
            
            // Add salespersons with no sales
            foreach (var s in activeSalespersons.Where(s => !salespersonIds.Contains(s.Id)))
            {
                allSalespersons.Add(new
                {
                    SalespersonId = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Manager = s.Manager,
                    StartDate = s.StartDate,
                    TotalSales = 0,
                    TotalRevenue = 0.0m,
                    TotalCommission = 0.0m,
                    AverageCommissionRate = 0.0,
                    HighestSale = 0.0m,
                    LowestSale = 0.0m,
                    FirstSaleDate = (DateTime?)null,
                    LastSaleDate = (DateTime?)null,
                    DetailedSales = new List<object>()
                });
            }
            
            // Sort by commission
            allSalespersons = allSalespersons
                .OrderByDescending(s => ((dynamic)s).TotalCommission)
                .ToList();

            var salespersonsWithSalesCount = salespersonReport.Count;

            return new
            {
                Year = year,
                Quarter = quarter,
                StartDate = startDate,
                EndDate = endDate,
                QuarterSummary = new
                {
                    TotalSales = quarterSales.Count,
                    TotalRevenue = quarterSales.Sum(s => s.SalePrice),
                    TotalCommission = quarterSales.Sum(s => s.CommissionAmount),
                    AverageCommissionRate = quarterSales.Any() 
                        ? Math.Round(quarterSales.Average(s => s.CommissionAmount / s.SalePrice * 100), 2) 
                        : 0,
                    AverageSalePrice = quarterSales.Any() 
                        ? Math.Round(quarterSales.Average(s => s.SalePrice), 2) 
                        : 0,
                    SalespersonCount = allSalespersons.Count,
                    SalespersonsWithSales = salespersonsWithSalesCount
                },
                ProductStyles = productStyleSales,
                MonthlySummary = monthlySales,
                TopProducts = topProducts,
                Commissions = allSalespersons
            };
        }
    }
}