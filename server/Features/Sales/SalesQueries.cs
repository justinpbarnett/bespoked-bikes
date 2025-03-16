using Microsoft.EntityFrameworkCore;
using server.Infrastructure.Data;

namespace server.Features.Sales;

public class GetSaleDetailsQuery
{
    private readonly ApplicationDbContext _context;

    public GetSaleDetailsQuery(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SaleDetailsDto?> ExecuteAsync(int id)
    {
        var sale = await _context.Sales
            .Include(s => s.Product)
            .Include(s => s.Salesperson)
            .Include(s => s.Customer)
            .Include(s => s.AppliedDiscount)
            .Where(s => s.Id == id)
            .Select(s => new
            {
                s.Id,
                s.SalesDate,
                s.SalePrice,
                s.OriginalPrice,
                s.CommissionAmount,
                s.AppliedDiscountCode,
                ProductId = s.Product.Id,
                ProductName = s.Product.Name,
                SalespersonId = s.Salesperson.Id,
                SalespersonFirstName = s.Salesperson.FirstName,
                SalespersonLastName = s.Salesperson.LastName,
                CustomerId = s.Customer.Id,
                CustomerFirstName = s.Customer.FirstName,
                CustomerLastName = s.Customer.LastName,
                DiscountId = s.AppliedDiscount != null ? s.AppliedDiscount.Id : (int?)null,
                DiscountPercentage = s.AppliedDiscount != null ? s.AppliedDiscount.DiscountPercentage : 0,
                DiscountBeginDate = s.AppliedDiscount != null ? s.AppliedDiscount.BeginDate : DateTime.MinValue,
                DiscountEndDate = s.AppliedDiscount != null ? s.AppliedDiscount.EndDate : DateTime.MinValue
            })
            .FirstOrDefaultAsync();

        if (sale == null) return null;

        return new SaleDetailsDto(
            sale.Id,
            sale.SalesDate,
            sale.SalePrice,
            sale.OriginalPrice,
            sale.CommissionAmount,
            new ProductDto(sale.ProductId, sale.ProductName),
            new SalespersonDto(sale.SalespersonId, sale.SalespersonFirstName, sale.SalespersonLastName),
            new CustomerDto(sale.CustomerId, sale.CustomerFirstName, sale.CustomerLastName),
            sale.DiscountId.HasValue ? new DiscountDto(
                sale.DiscountId.Value,
                sale.DiscountPercentage,
                sale.DiscountBeginDate,
                sale.DiscountEndDate
            ) : null,
            sale.AppliedDiscountCode
        );
    }
}

public class GetSalesQuery
{
    private readonly ApplicationDbContext _context;

    public GetSalesQuery(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SaleResponseDto>> ExecuteAsync()
    {
        var sales = await _context.Sales
            .Include(s => s.Product)
            .Include(s => s.Salesperson)
            .Include(s => s.Customer)
            .Include(s => s.AppliedDiscount)
            .OrderByDescending(s => s.SalesDate)
            .Select(s => new
            {
                s.Id,
                s.SalesDate,
                s.SalePrice,
                s.CommissionAmount,
                s.ProductId,
                ProductName = s.Product.Name,
                s.SalespersonId,
                SalespersonFirstName = s.Salesperson.FirstName,
                SalespersonLastName = s.Salesperson.LastName,
                s.CustomerId,
                CustomerFirstName = s.Customer.FirstName,
                CustomerLastName = s.Customer.LastName,
                s.OriginalPrice,
                s.AppliedDiscountId,
                s.AppliedDiscountPercentage,
                s.AppliedDiscountCode
            })
            .ToListAsync();

        return sales.Select(s => new SaleResponseDto(
            s.Id,
            s.SalesDate,
            s.SalePrice,
            s.CommissionAmount,
            s.ProductId,
            s.ProductName,
            s.SalespersonId,
            s.SalespersonFirstName,
            s.SalespersonLastName,
            s.CustomerId,
            s.CustomerFirstName,
            s.CustomerLastName,
            s.OriginalPrice,
            s.AppliedDiscountId,
            s.AppliedDiscountPercentage,
            s.AppliedDiscountCode
        ));
    }
}

public class FilterSalesQuery
{
    private readonly ApplicationDbContext _context;

    public FilterSalesQuery(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SaleResponseDto>> ExecuteAsync(DateTime? startDate, DateTime? endDate)
    {
        var query = _context.Sales
            .Include(s => s.Product)
            .Include(s => s.Salesperson)
            .Include(s => s.Customer)
            .Include(s => s.AppliedDiscount)
            .OrderByDescending(s => s.SalesDate)
            .AsQueryable();

        if (startDate.HasValue)
        {
            query = query.Where(s => s.SalesDate >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            query = query.Where(s => s.SalesDate <= endDate.Value);
        }

        var sales = await query
            .Select(s => new
            {
                s.Id,
                s.SalesDate,
                s.SalePrice,
                s.CommissionAmount,
                s.ProductId,
                ProductName = s.Product.Name,
                s.SalespersonId,
                SalespersonFirstName = s.Salesperson.FirstName,
                SalespersonLastName = s.Salesperson.LastName,
                s.CustomerId,
                CustomerFirstName = s.Customer.FirstName,
                CustomerLastName = s.Customer.LastName,
                s.OriginalPrice,
                s.AppliedDiscountId,
                s.AppliedDiscountPercentage,
                s.AppliedDiscountCode
            })
            .ToListAsync();

        return sales.Select(s => new SaleResponseDto(
            s.Id,
            s.SalesDate,
            s.SalePrice,
            s.CommissionAmount,
            s.ProductId,
            s.ProductName,
            s.SalespersonId,
            s.SalespersonFirstName,
            s.SalespersonLastName,
            s.CustomerId,
            s.CustomerFirstName,
            s.CustomerLastName,
            s.OriginalPrice,
            s.AppliedDiscountId,
            s.AppliedDiscountPercentage,
            s.AppliedDiscountCode
        ));
    }
}