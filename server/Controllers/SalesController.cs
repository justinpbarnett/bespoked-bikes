using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetSales()
        {
            return await _context.Sales
                .Include(s => s.Product)
                .Include(s => s.Salesperson)
                .Include(s => s.Customer)
                .Select(s => new
                {
                    s.Id,
                    s.SalesDate,
                    s.SalePrice,
                    s.CommissionAmount,
                    Product = new
                    {
                        s.Product.Id,
                        s.Product.Name
                    },
                    Salesperson = new
                    {
                        s.Salesperson.Id,
                        s.Salesperson.FirstName,
                        s.Salesperson.LastName
                    },
                    Customer = new
                    {
                        s.Customer.Id,
                        s.Customer.FirstName,
                        s.Customer.LastName
                    }
                })
                .ToListAsync();
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<object>>> FilterSales([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var query = _context.Sales
                .Include(s => s.Product)
                .Include(s => s.Salesperson)
                .Include(s => s.Customer)
                .AsQueryable();

            if (startDate.HasValue)
            {
                query = query.Where(s => s.SalesDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(s => s.SalesDate <= endDate.Value);
            }

            var result = await query
                .Select(s => new
                {
                    s.Id,
                    s.SalesDate,
                    s.SalePrice,
                    s.CommissionAmount,
                    Product = new
                    {
                        s.Product.Id,
                        s.Product.Name
                    },
                    Salesperson = new
                    {
                        s.Salesperson.Id,
                        s.Salesperson.FirstName,
                        s.Salesperson.LastName
                    },
                    Customer = new
                    {
                        s.Customer.Id,
                        s.Customer.FirstName,
                        s.Customer.LastName
                    }
                })
                .ToListAsync();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateSale(SaleCreateDto saleDto)
        {
            // Get product to calculate commission
            var product = await _context.Products.FindAsync(saleDto.ProductId);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            // Verify salesperson exists
            var salesperson = await _context.Salespersons.FindAsync(saleDto.SalespersonId);
            if (salesperson == null)
            {
                return NotFound("Salesperson not found");
            }

            // Verify customer exists
            var customer = await _context.Customers.FindAsync(saleDto.CustomerId);
            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            // Check for active discounts
            var activeDiscount = await _context.Discounts
                .Where(d => d.ProductId == product.Id)
                .Where(d => d.BeginDate <= saleDto.SalesDate && d.EndDate >= saleDto.SalesDate)
                .OrderByDescending(d => d.DiscountPercentage) // Use highest discount if multiple
                .FirstOrDefaultAsync();

            decimal finalPrice = product.SalePrice;
            if (activeDiscount != null)
            {
                // Apply discount
                finalPrice = product.SalePrice * (1 - (activeDiscount.DiscountPercentage / 100));
            }

            // Calculate commission
            decimal commissionAmount = finalPrice * (product.CommissionPercentage / 100);

            // Create sale record
            var sale = new Sale
            {
                ProductId = product.Id,
                SalespersonId = salesperson.Id,
                CustomerId = customer.Id,
                SalesDate = saleDto.SalesDate,
                SalePrice = finalPrice,
                CommissionAmount = commissionAmount
            };

            // Reduce quantity on hand
            product.QuantityOnHand--;

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            var result = new
            {
                sale.Id,
                sale.SalesDate,
                sale.SalePrice,
                sale.CommissionAmount,
                Product = new
                {
                    product.Id,
                    product.Name
                },
                Salesperson = new
                {
                    salesperson.Id,
                    salesperson.FirstName,
                    salesperson.LastName
                },
                Customer = new
                {
                    customer.Id,
                    customer.FirstName,
                    customer.LastName
                }
            };

            return CreatedAtAction(nameof(GetSales), new { id = sale.Id }, result);
        }
    }
}