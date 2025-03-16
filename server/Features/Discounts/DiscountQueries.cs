using Microsoft.EntityFrameworkCore;
using server.Infrastructure.Data;

namespace server.Features.Discounts;

public class GetDiscountsQuery(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<DiscountDto>> ExecuteAsync()
    {
        var discounts = await _context.Discounts
            .Include(d => d.Product)
            .OrderByDescending(d => d.BeginDate)
            .Select(d => new DiscountDto(
                d.Id,
                d.ProductId,
                d.BeginDate,
                d.EndDate,
                d.DiscountPercentage,
                d.ProductId.HasValue ? new ProductDto(d.Product!.Id, d.Product.Name) : null,
                d.ProductId == null,
                d.DiscountCode
            ))
            .ToListAsync();

        return discounts;
    }
}

public class GetDiscountByIdQuery(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<DiscountDto?> ExecuteAsync(int id)
    {
        var discount = await _context.Discounts
            .Include(d => d.Product)
            .Where(d => d.Id == id)
            .Select(d => new DiscountDto(
                d.Id,
                d.ProductId,
                d.BeginDate,
                d.EndDate,
                d.DiscountPercentage,
                d.ProductId.HasValue ? new ProductDto(d.Product!.Id, d.Product.Name) : null,
                d.ProductId == null,
                d.DiscountCode
            ))
            .FirstOrDefaultAsync();

        return discount;
    }
}

public class GetActiveDiscountsForProductQuery(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<DiscountDto>> ExecuteAsync(int productId, DateTime date)
    {
        var discounts = await _context.Discounts
            .Include(d => d.Product)
            .Where(d => d.ProductId == productId || d.ProductId == null) // Include both product-specific and global
            .Where(d => d.BeginDate <= date && d.EndDate >= date)
            .OrderByDescending(d => d.DiscountPercentage) // Highest discount first
            .Select(d => new DiscountDto(
                d.Id,
                d.ProductId,
                d.BeginDate,
                d.EndDate,
                d.DiscountPercentage,
                d.ProductId.HasValue ? new ProductDto(d.Product!.Id, d.Product.Name) : null,
                d.ProductId == null,
                d.DiscountCode
            ))
            .ToListAsync();

        return discounts;
    }
}

public class GetGlobalDiscountsQuery(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<DiscountDto>> ExecuteAsync(DateTime? date = null)
    {
        var query = _context.Discounts
            .Where(d => d.ProductId == null); // Only global discounts

        if (date.HasValue)
        {
            query = query.Where(d => d.BeginDate <= date && d.EndDate >= date);
        }

        var discounts = await query
            .OrderByDescending(d => d.BeginDate)
            .Select(d => new DiscountDto(
                d.Id,
                d.ProductId,
                d.BeginDate,
                d.EndDate,
                d.DiscountPercentage,
                null,
                true,
                d.DiscountCode
            ))
            .ToListAsync();

        return discounts;
    }
}
