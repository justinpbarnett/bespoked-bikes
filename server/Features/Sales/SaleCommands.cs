using Microsoft.EntityFrameworkCore;
using server.Infrastructure.Data;
using server.Models;

namespace server.Features.Sales;

public class CreateSaleCommand
{
    private readonly ApplicationDbContext _context;

    public CreateSaleCommand(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(bool Success, SaleResponseDto? Sale, string? ErrorMessage)> ExecuteAsync(SaleCreateDto saleDto)
    {
        // Get product to calculate commission
        var product = await _context.Products.FindAsync(saleDto.ProductId);
        if (product == null)
        {
            return (false, null, "Product not found");
        }

        // Verify salesperson exists
        var salesperson = await _context.Salespersons.FindAsync(saleDto.SalespersonId);
        if (salesperson == null)
        {
            return (false, null, "Salesperson not found");
        }

        // Verify customer exists
        var customer = await _context.Customers.FindAsync(saleDto.CustomerId);
        if (customer == null)
        {
            return (false, null, "Customer not found");
        }

        // Get all potential active discounts (product-specific and global)
        var query = _context.Discounts
            .Where(d => d.BeginDate <= saleDto.SalesDate && d.EndDate >= saleDto.SalesDate)
            .Where(d => d.ProductId == product.Id || d.ProductId == null);

        // If a discount code was provided, also try to find a matching code-based discount
        Discount? codeBasedDiscount = null;
        if (!string.IsNullOrEmpty(saleDto.DiscountCode))
        {
            codeBasedDiscount = await _context.Discounts
                .Where(d => d.BeginDate <= saleDto.SalesDate && d.EndDate >= saleDto.SalesDate)
                .Where(d => d.DiscountCode == saleDto.DiscountCode)
                .Where(d => d.ProductId == product.Id || d.ProductId == null)
                .OrderByDescending(d => d.DiscountPercentage)
                .FirstOrDefaultAsync();
        }

        // Get the highest automatic discount (non-code based)
        var automaticDiscounts = await query
            .Where(d => string.IsNullOrEmpty(d.DiscountCode))
            .OrderByDescending(d => d.DiscountPercentage)
            .ToListAsync();
        
        var highestAutomaticDiscount = automaticDiscounts.FirstOrDefault();

        // Determine which discount to apply (code-based or automatic, whichever is higher)
        Discount? activeDiscount = null;
        string? appliedDiscountCode = null;

        if (codeBasedDiscount != null && highestAutomaticDiscount != null)
        {
            // Use whichever discount is higher
            activeDiscount = codeBasedDiscount.DiscountPercentage >= highestAutomaticDiscount.DiscountPercentage
                ? codeBasedDiscount
                : highestAutomaticDiscount;
            
            // Only set the applied code if we're using the code-based discount
            if (activeDiscount == codeBasedDiscount)
            {
                appliedDiscountCode = saleDto.DiscountCode;
            }
        }
        else if (codeBasedDiscount != null)
        {
            activeDiscount = codeBasedDiscount;
            appliedDiscountCode = saleDto.DiscountCode;
        }
        else
        {
            activeDiscount = highestAutomaticDiscount;
        }

        decimal originalPrice = product.SalePrice;
        decimal finalPrice = originalPrice;
        decimal discountPercentage = 0;
        int? discountId = null;

        if (activeDiscount != null)
        {
            // Apply discount
            discountPercentage = activeDiscount.DiscountPercentage;
            discountId = activeDiscount.Id;
            finalPrice = originalPrice * (1 - (discountPercentage / 100));
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
            CommissionAmount = commissionAmount,
            OriginalPrice = originalPrice,
            AppliedDiscountId = discountId,
            AppliedDiscountPercentage = discountPercentage,
            AppliedDiscountCode = appliedDiscountCode
        };

        // Reduce quantity on hand
        product.QuantityOnHand--;

        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();

        var result = new SaleResponseDto(
            sale.Id,
            sale.SalesDate,
            sale.SalePrice,
            sale.CommissionAmount,
            sale.ProductId,
            product.Name,
            sale.SalespersonId,
            salesperson.FirstName,
            salesperson.LastName,
            sale.CustomerId,
            customer.FirstName,
            customer.LastName,
            sale.OriginalPrice,
            sale.AppliedDiscountId,
            sale.AppliedDiscountPercentage,
            sale.AppliedDiscountCode
        );

        return (true, result, null);
    }
}