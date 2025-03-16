using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("summary")]
        public async Task<ActionResult<object>> GetDashboardSummary()
        {
            // Get current month range
            var today = DateTime.Today;
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // Get last month range
            var firstDayOfLastMonth = firstDayOfMonth.AddMonths(-1);
            var lastDayOfLastMonth = firstDayOfMonth.AddDays(-1);

            // Get current month sales
            var currentMonthSales = await _context.Sales
                .Where(s => s.SalesDate >= firstDayOfMonth && s.SalesDate <= lastDayOfMonth)
                .ToListAsync();

            // Get last month sales
            var lastMonthSales = await _context.Sales
                .Where(s => s.SalesDate >= firstDayOfLastMonth && s.SalesDate <= lastDayOfLastMonth)
                .ToListAsync();

            // Calculate totals
            decimal currentMonthRevenue = currentMonthSales.Sum(s => s.SalePrice);
            decimal lastMonthRevenue = lastMonthSales.Sum(s => s.SalePrice);

            // Calculate change percentages
            decimal revenueChangePercentage = lastMonthRevenue == 0 ? 0 :
                ((currentMonthRevenue - lastMonthRevenue) / lastMonthRevenue) * 100;
            decimal salesChangePercentage = lastMonthSales.Count == 0 ? 0 :
                ((decimal)(currentMonthSales.Count - lastMonthSales.Count) / lastMonthSales.Count) * 100;

            // Get active salespersons
            var activeSalespersons = await _context.Salespersons
                .Where(s => s.TerminationDate == null || s.TerminationDate > today)
                .CountAsync();

            // Get inventory alerts
            var lowStockProducts = await _context.Products
                .Where(p => p.QuantityOnHand > 0 && p.QuantityOnHand <= 5)
                .CountAsync();

            var outOfStockProducts = await _context.Products
                .Where(p => p.QuantityOnHand == 0)
                .CountAsync();

            // Get total products
            var totalProducts = await _context.Products.CountAsync();

            // Calculate inventory value
            var inventoryValue = await _context.Products
                .SumAsync(p => p.QuantityOnHand * p.SalePrice);

            return new
            {
                TotalRevenue = currentMonthRevenue,
                TotalSales = currentMonthSales.Count,
                ActiveSalespersons = activeSalespersons,
                InventoryAlerts = lowStockProducts + outOfStockProducts,
                LowStockCount = lowStockProducts,
                OutOfStockCount = outOfStockProducts,
                RevenueChangePercentage = Math.Round(revenueChangePercentage, 1),
                SalesChangePercentage = Math.Round(salesChangePercentage, 1),
                TotalProducts = totalProducts,
                InventoryValue = inventoryValue
            };
        }

        [HttpGet("recent-sales")]
        public async Task<ActionResult<IEnumerable<object>>> GetRecentSales([FromQuery] int count)
        {
            return await _context.Sales
                .Include(s => s.Product)
                .Include(s => s.Salesperson)
                .Include(s => s.Customer)
                .OrderByDescending(s => s.SalesDate)
                .Take(count)
                .Select(s => new
                {
                    s.Id,
                    s.SalesDate,
                    s.SalePrice,
                    Product = s.Product.Name,
                    Salesperson = $"{s.Salesperson.FirstName} {s.Salesperson.LastName}",
                    Customer = $"{s.Customer.FirstName} {s.Customer.LastName}"
                })
                .ToListAsync();
        }

        [HttpGet("monthly-sales")]
        public async Task<ActionResult<object>> GetMonthlySales([FromQuery] string year)
        {
            if (string.IsNullOrEmpty(year))
            {
                return BadRequest("Year parameter is required");
            }

            var salesData = new List<object>();

            // All-time view: get data for each year
            if (year.ToLower() == "all")
            {
                // Get the range of years from the data
                var years = await _context.Sales
                    .GroupBy(s => s.SalesDate.Year)
                    .Select(g => g.Key)
                    .OrderBy(y => y)
                    .ToListAsync();

                // If no data, return empty result
                if (!years.Any())
                {
                    return new
                    {
                        Year = "all",
                        Data = new List<object>()
                    };
                }

                // Create data points for all year-month combinations in chronological order
                var allMonths = new List<(int Year, int Month)>();

                foreach (var dataYear in years)
                {
                    for (int month = 1; month <= 12; month++)
                    {
                        allMonths.Add((dataYear, month));
                    }
                }

                // Sort the months chronologically (oldest to newest)
                allMonths.Sort((a, b) =>
                {
                    int yearComparison = a.Year.CompareTo(b.Year);
                    return yearComparison != 0 ? yearComparison : a.Month.CompareTo(b.Month);
                });

                // Process each month
                foreach (var (dataYear, month) in allMonths)
                {
                    var startDate = new DateTime(dataYear, month, 1);
                    var endDate = startDate.AddMonths(1).AddDays(-1);

                    var monthlySales = await _context.Sales
                        .Where(s => s.SalesDate >= startDate && s.SalesDate <= endDate)
                        .ToListAsync();

                    decimal totalSales = monthlySales.Sum(s => s.SalePrice);
                    decimal totalCommission = monthlySales.Sum(s => s.CommissionAmount);

                    // Only add non-zero months to avoid clutter (optional)
                    if (totalSales > 0 || totalCommission > 0)
                    {
                        salesData.Add(new
                        {
                            Label = $"{startDate.ToString("MMM")} {dataYear}",
                            Sales = totalSales,
                            Commission = totalCommission
                        });
                    }
                }

                return new
                {
                    Year = "all",
                    Data = salesData
                };
            }
            // Specific year parameter might be used for a rolling 12-month view
            else
            {
                // Try to parse year as integer
                if (!int.TryParse(year, out int yearInt))
                {
                    return BadRequest("Invalid year format");
                }

                // Calculate the start and end dates for a rolling 12-month period
                var currentDate = DateTime.Now;

                // Get current month and calculate dates for a rolling 12-month window
                int currentMonth = currentDate.Month;
                int currentYear = currentDate.Year;

                // Build data for the last 12 months in chronological order
                // Start with the oldest month (11 months ago) and go to the current month
                // Loop going from -11 months to 0 (current month) so the array is in chronological order
                for (int i = 11; i >= 0; i--)
                {
                    // Calculate the target month and year (going backwards from current month)
                    var targetDate = currentDate.AddMonths(-i);
                    var startDate = new DateTime(targetDate.Year, targetDate.Month, 1);
                    var endDate = startDate.AddMonths(1).AddDays(-1);

                    var monthlySales = await _context.Sales
                        .Where(s => s.SalesDate >= startDate && s.SalesDate <= endDate)
                        .ToListAsync();

                    decimal totalSales = monthlySales.Sum(s => s.SalePrice);
                    decimal totalCommission = monthlySales.Sum(s => s.CommissionAmount);

                    // Add each month to the array in chronological order
                    // The current month will be the last item (rightmost in the chart)
                    salesData.Add(new
                    {
                        // Simple month label for consistent display (current month will be rightmost)
                        Label = startDate.ToString("MMM"),
                        Sales = totalSales,
                        Commission = totalCommission
                    });
                }

                return new
                {
                    Year = year,
                    Data = salesData
                };
            }
        }

        [HttpGet("top-salespersons")]
        public async Task<ActionResult<IEnumerable<object>>> GetTopSalespersons([FromQuery] int count)
        {
            // Get current quarter dates
            var today = DateTime.Today;
            int currentQuarter = (today.Month - 1) / 3 + 1;
            var startDate = new DateTime(today.Year, (currentQuarter - 1) * 3 + 1, 1);
            var endDate = startDate.AddMonths(3).AddDays(-1);

            var salesByPerson = await _context.Sales
                .Where(s => s.SalesDate >= startDate && s.SalesDate <= endDate)
                .GroupBy(s => s.SalespersonId)
                .Select(g => new
                {
                    SalespersonId = g.Key,
                    TotalSales = g.Sum(s => s.SalePrice),
                    TotalCommission = g.Sum(s => s.CommissionAmount)
                })
                .OrderByDescending(s => s.TotalSales)
                .Take(count)
                .ToListAsync();

            // Get salesperson details
            var salespersonIds = salesByPerson.Select(s => s.SalespersonId).ToList();
            var salespersons = await _context.Salespersons
                .Where(s => salespersonIds.Contains(s.Id))
                .ToDictionaryAsync(s => s.Id, s => new { s.FirstName, s.LastName });

            // Define arbitrary targets based on performance
            const decimal TARGET_MULTIPLIER = 1.2m;

            // Combine data
            var result = salesByPerson.Select(s => new
            {
                Id = s.SalespersonId,
                Name = $"{salespersons.GetValueOrDefault(s.SalespersonId)?.FirstName ?? "Unknown"} {salespersons.GetValueOrDefault(s.SalespersonId)?.LastName ?? "Unknown"}",
                Avatar = $"{salespersons.GetValueOrDefault(s.SalespersonId)?.FirstName?[0] ?? '?'}{salespersons.GetValueOrDefault(s.SalespersonId)?.LastName?[0] ?? '?'}",
                Sales = s.TotalSales,
                Target = s.TotalSales * TARGET_MULTIPLIER // Setting target slightly above actual performance
            }).ToList();

            return result;
        }

        [HttpGet("inventory-alerts")]
        public async Task<ActionResult<object>> GetInventoryAlerts()
        {
            // Get out of stock products
            var outOfStock = await _context.Products
                .Where(p => p.QuantityOnHand == 0)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Manufacturer,
                    p.QuantityOnHand,
                    Status = "Out of Stock"
                })
                .ToListAsync();

            // Get low stock products
            var lowStock = await _context.Products
                .Where(p => p.QuantityOnHand > 0 && p.QuantityOnHand <= 5)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Manufacturer,
                    p.QuantityOnHand,
                    ReorderLevel = 5, // Assuming 5 is the reorder level
                    Status = "Low Stock"
                })
                .ToListAsync();

            return new
            {
                OutOfStock = outOfStock,
                LowStock = lowStock
            };
        }

        [HttpGet("product-performance")]
        public async Task<ActionResult<IEnumerable<object>>> GetProductPerformance()
        {
            // Get current month range
            var today = DateTime.Today;
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // Get monthly sales by product
            var productSales = await _context.Sales
                .Where(s => s.SalesDate >= firstDayOfMonth && s.SalesDate <= lastDayOfMonth)
                .GroupBy(s => s.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalSales = g.Count(),
                    TotalRevenue = g.Sum(s => s.SalePrice)
                })
                .OrderByDescending(p => p.TotalRevenue)
                .Take(5)
                .ToListAsync();

            // Get product details
            var productIds = productSales.Select(p => p.ProductId).ToList();
            var products = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToDictionaryAsync(p => p.Id, p => p.Name);

            // Calculate total revenue for percentage calculation
            decimal totalRevenue = productSales.Sum(p => p.TotalRevenue);

            // Combine data
            var result = productSales.Select(p => new
            {
                Id = p.ProductId,
                Name = products.GetValueOrDefault(p.ProductId) ?? "Unknown",
                Sales = p.TotalSales,
                Revenue = p.TotalRevenue,
                Percentage = totalRevenue == 0 ? 0 : Math.Round((p.TotalRevenue / totalRevenue) * 100, 1)
            }).ToList();

            return result;
        }
    }
}