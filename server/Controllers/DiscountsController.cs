using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DiscountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetDiscounts()
        {
            return await _context.Discounts
                .Include(d => d.Product)
                .Select(d => new
                {
                    d.Id,
                    d.BeginDate,
                    d.EndDate,
                    d.DiscountPercentage,
                    Product = new
                    {
                        d.Product.Id,
                        d.Product.Name
                    }
                })
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Discount>> CreateDiscount(Discount discount)
        {
            // Verify product exists
            var product = await _context.Products.FindAsync(discount.ProductId);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            // Verify dates
            if (discount.BeginDate >= discount.EndDate)
            {
                return BadRequest("End date must be after begin date");
            }

            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiscounts", new { id = discount.Id }, discount);
        }
    }
}