using Microsoft.EntityFrameworkCore;
using server.Infrastructure.Data;
using server.Models;

namespace server.Features.Discounts;

public class CreateDiscountCommand
{
    private readonly ApplicationDbContext _context;

    public CreateDiscountCommand(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DiscountResponseDto> ExecuteAsync(DiscountCreateDto discountDto)
    {
        Product? product = null;
        
        // Check if it's a product-specific discount
        if (!discountDto.IsGlobal && discountDto.ProductId.HasValue)
        {
            // Validate product exists
            product = await _context.Products.FindAsync(discountDto.ProductId);
            if (product == null)
            {
                return new DiscountResponseDto(false, "Product not found");
            }
        }
        else if (discountDto.IsGlobal && discountDto.ProductId.HasValue)
        {
            // Can't have both IsGlobal=true and a ProductId
            return new DiscountResponseDto(false, "Global discounts cannot have a specific product");
        }
        
        // Validate discount percentage
        if (discountDto.DiscountPercentage < 0 || discountDto.DiscountPercentage > 100)
        {
            return new DiscountResponseDto(false, "Discount percentage must be between 0 and 100");
        }
        
        // Validate dates
        if (discountDto.BeginDate >= discountDto.EndDate)
        {
            return new DiscountResponseDto(false, "Begin date must be before end date");
        }

        // Create discount
        var discount = new Discount
        {
            ProductId = discountDto.IsGlobal ? null : discountDto.ProductId,
            BeginDate = discountDto.BeginDate,
            EndDate = discountDto.EndDate,
            DiscountPercentage = discountDto.DiscountPercentage,
            DiscountCode = discountDto.DiscountCode
        };

        _context.Discounts.Add(discount);
        await _context.SaveChangesAsync();

        // Return discount with product info if it's product-specific
        ProductDto? productDto = null;
        if (product != null)
        {
            productDto = new ProductDto(product.Id, product.Name);
        }

        var discountResult = new DiscountDto(
            discount.Id,
            discount.ProductId,
            discount.BeginDate,
            discount.EndDate,
            discount.DiscountPercentage,
            productDto,
            discount.IsGlobal,
            discount.DiscountCode
        );

        return new DiscountResponseDto(true, null, discountResult);
    }
}

public class UpdateDiscountCommand
{
    private readonly ApplicationDbContext _context;

    public UpdateDiscountCommand(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DiscountResponseDto> ExecuteAsync(int id, DiscountUpdateDto discountDto)
    {
        // Find discount
        var discount = await _context.Discounts.FindAsync(id);
        if (discount == null)
        {
            return new DiscountResponseDto(false, "Discount not found");
        }
        
        Product? product = null;
        
        // Check if it's a product-specific discount
        if (!discountDto.IsGlobal && discountDto.ProductId.HasValue)
        {
            // Validate product exists
            product = await _context.Products.FindAsync(discountDto.ProductId);
            if (product == null)
            {
                return new DiscountResponseDto(false, "Product not found");
            }
        }
        else if (discountDto.IsGlobal && discountDto.ProductId.HasValue)
        {
            // Can't have both IsGlobal=true and a ProductId
            return new DiscountResponseDto(false, "Global discounts cannot have a specific product");
        }
        
        // Validate discount percentage
        if (discountDto.DiscountPercentage < 0 || discountDto.DiscountPercentage > 100)
        {
            return new DiscountResponseDto(false, "Discount percentage must be between 0 and 100");
        }
        
        // Validate dates
        if (discountDto.BeginDate >= discountDto.EndDate)
        {
            return new DiscountResponseDto(false, "Begin date must be before end date");
        }

        // Update discount
        discount.ProductId = discountDto.IsGlobal ? null : discountDto.ProductId;
        discount.BeginDate = discountDto.BeginDate;
        discount.EndDate = discountDto.EndDate;
        discount.DiscountPercentage = discountDto.DiscountPercentage;
        discount.DiscountCode = discountDto.DiscountCode;

        await _context.SaveChangesAsync();

        // Return discount with product info
        ProductDto? productDto = null;
        if (product != null)
        {
            productDto = new ProductDto(product.Id, product.Name);
        }

        var discountResult = new DiscountDto(
            discount.Id,
            discount.ProductId,
            discount.BeginDate,
            discount.EndDate,
            discount.DiscountPercentage,
            productDto,
            discount.IsGlobal,
            discount.DiscountCode
        );

        return new DiscountResponseDto(true, null, discountResult);
    }
}

public class DeleteDiscountCommand
{
    private readonly ApplicationDbContext _context;

    public DeleteDiscountCommand(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DiscountResponseDto> ExecuteAsync(int id)
    {
        var discount = await _context.Discounts.FindAsync(id);
        if (discount == null)
        {
            return new DiscountResponseDto(false, "Discount not found");
        }

        _context.Discounts.Remove(discount);
        await _context.SaveChangesAsync();

        return new DiscountResponseDto(true);
    }
}
