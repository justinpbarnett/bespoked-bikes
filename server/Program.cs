using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy
            .WithOrigins("http://localhost:3000", "http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowReactApp");

// Initialize database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

// API Endpoints
// Products
app.MapGet("/api/products", async (ApplicationDbContext db) =>
    await db.Products.ToListAsync());

app.MapGet("/api/products/{id}", async (int id, ApplicationDbContext db) =>
    await db.Products.FindAsync(id) is Product product
        ? Results.Ok(product)
        : Results.NotFound());

app.MapPost("/api/products", async ([FromBody] Product product, ApplicationDbContext db) =>
{
    // Check for duplicates
    if (await db.Products.AnyAsync(p => p.Name == product.Name))
    {
        return Results.BadRequest($"A product with the name '{product.Name}' already exists.");
    }

    db.Products.Add(product);
    await db.SaveChangesAsync();
    return Results.Created($"/api/products/{product.Id}", product);
});

app.MapPut("/api/products/{id}", async (int id, [FromBody] Product product, ApplicationDbContext db) =>
{
    var existingProduct = await db.Products.FindAsync(id);
    if (existingProduct == null)
    {
        return Results.NotFound();
    }

    // Don't allow changing the name if it's already taken
    if (product.Name != existingProduct.Name &&
        await db.Products.AnyAsync(p => p.Name == product.Name))
    {
        return Results.BadRequest($"A product with the name '{product.Name}' already exists.");
    }

    existingProduct.Name = product.Name;
    existingProduct.Manufacturer = product.Manufacturer;
    existingProduct.Style = product.Style;
    existingProduct.PurchasePrice = product.PurchasePrice;
    existingProduct.SalePrice = product.SalePrice;
    existingProduct.QuantityOnHand = product.QuantityOnHand;
    existingProduct.CommissionPercentage = product.CommissionPercentage;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Salespersons
app.MapGet("/api/salespersons", async (ApplicationDbContext db) =>
    await db.Salespersons.ToListAsync());

app.MapGet("/api/salespersons/{id}", async (int id, ApplicationDbContext db) =>
    await db.Salespersons.FindAsync(id) is Salesperson salesperson
        ? Results.Ok(salesperson)
        : Results.NotFound());

app.MapPost("/api/salespersons", async ([FromBody] Salesperson salesperson, ApplicationDbContext db) =>
{
    // Check for duplicate name (case-insensitive) with same address
    // This prevents creating duplicates of the same person with minor naming differences
    if (await db.Salespersons.AnyAsync(s => 
        s.FirstName.ToLower() == salesperson.FirstName.ToLower() && 
        s.LastName.ToLower() == salesperson.LastName.ToLower() && 
        s.Address == salesperson.Address))
    {
        return Results.BadRequest($"A salesperson named '{salesperson.FirstName} {salesperson.LastName}' already exists at this address.");
    }

    db.Salespersons.Add(salesperson);
    await db.SaveChangesAsync();
    return Results.Created($"/api/salespersons/{salesperson.Id}", salesperson);
});

app.MapPut("/api/salespersons/{id}", async (int id, [FromBody] Salesperson salesperson, ApplicationDbContext db) =>
{
    var existingSalesperson = await db.Salespersons.FindAsync(id);
    if (existingSalesperson == null)
    {
        return Results.NotFound();
    }

    // Check for duplicate name (case-insensitive) with same address
    // Only perform this check if name or address has changed
    bool nameChanged = salesperson.FirstName.ToLower() != existingSalesperson.FirstName.ToLower() || 
                        salesperson.LastName.ToLower() != existingSalesperson.LastName.ToLower();
    bool addressChanged = salesperson.Address != existingSalesperson.Address;
    
    if ((nameChanged || addressChanged) &&
        await db.Salespersons.AnyAsync(s => 
            s.Id != id &&
            s.FirstName.ToLower() == salesperson.FirstName.ToLower() && 
            s.LastName.ToLower() == salesperson.LastName.ToLower() && 
            s.Address == salesperson.Address))
    {
        return Results.BadRequest($"A salesperson named '{salesperson.FirstName} {salesperson.LastName}' already exists at this address.");
    }

    existingSalesperson.FirstName = salesperson.FirstName;
    existingSalesperson.LastName = salesperson.LastName;
    existingSalesperson.Address = salesperson.Address;
    existingSalesperson.Phone = salesperson.Phone;
    existingSalesperson.StartDate = salesperson.StartDate;
    existingSalesperson.TerminationDate = salesperson.TerminationDate;
    existingSalesperson.Manager = salesperson.Manager;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Customers
app.MapGet("/api/customers", async (ApplicationDbContext db) =>
    await db.Customers.ToListAsync());

app.MapGet("/api/customers/{id}", async (int id, ApplicationDbContext db) =>
    await db.Customers.FindAsync(id) is Customer customer
        ? Results.Ok(customer)
        : Results.NotFound());

app.MapPost("/api/customers", async ([FromBody] Customer customer, ApplicationDbContext db) =>
{
    db.Customers.Add(customer);
    await db.SaveChangesAsync();
    return Results.Created($"/api/customers/{customer.Id}", customer);
});

// Sales
app.MapGet("/api/sales", async (ApplicationDbContext db) =>
    await db.Sales
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
        .ToListAsync());

app.MapGet("/api/sales/filter", async (DateTime? startDate, DateTime? endDate, ApplicationDbContext db) =>
{
    var query = db.Sales
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
});

app.MapPost("/api/sales", async ([FromBody] SaleCreateDto saleDto, ApplicationDbContext db) =>
{
    // Get product to calculate commission
    var product = await db.Products.FindAsync(saleDto.ProductId);
    if (product == null)
    {
        return Results.NotFound("Product not found");
    }

    // Verify salesperson exists
    var salesperson = await db.Salespersons.FindAsync(saleDto.SalespersonId);
    if (salesperson == null)
    {
        return Results.NotFound("Salesperson not found");
    }

    // Verify customer exists
    var customer = await db.Customers.FindAsync(saleDto.CustomerId);
    if (customer == null)
    {
        return Results.NotFound("Customer not found");
    }

    // Check for active discounts
    var activeDiscount = await db.Discounts
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

    db.Sales.Add(sale);
    await db.SaveChangesAsync();

    return Results.Created($"/api/sales/{sale.Id}", new
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
    });
});

// Quarterly Commission Report
app.MapGet("/api/reports/commission", async (int year, int quarter, ApplicationDbContext db) =>
{
    // Determine date range for the quarter
    var startDate = new DateTime(year, (quarter - 1) * 3 + 1, 1);
    var endDate = startDate.AddMonths(3).AddDays(-1);

    var salesByPerson = await db.Sales
        .Where(s => s.SalesDate >= startDate && s.SalesDate <= endDate)
        .GroupBy(s => s.SalespersonId)
        .Select(g => new
        {
            SalespersonId = g.Key,
            TotalSales = g.Count(),
            TotalRevenue = g.Sum(s => s.SalePrice),
            TotalCommission = g.Sum(s => s.CommissionAmount)
        })
        .ToListAsync();

    // Get salesperson details
    var salespersonIds = salesByPerson.Select(s => s.SalespersonId).ToList();
    var salespersons = await db.Salespersons
        .Where(s => salespersonIds.Contains(s.Id))
        .ToDictionaryAsync(s => s.Id, s => new { s.FirstName, s.LastName });

    // Combine data
    var report = salesByPerson.Select(s => new
    {
        SalespersonId = s.SalespersonId,
        FirstName = salespersons.GetValueOrDefault(s.SalespersonId)?.FirstName ?? "Unknown",
        LastName = salespersons.GetValueOrDefault(s.SalespersonId)?.LastName ?? "Unknown",
        TotalSales = s.TotalSales,
        TotalRevenue = s.TotalRevenue,
        TotalCommission = s.TotalCommission
    }).ToList();

    return new
    {
        Year = year,
        Quarter = quarter,
        StartDate = startDate,
        EndDate = endDate,
        Commissions = report
    };
});

// Discounts
app.MapGet("/api/discounts", async (ApplicationDbContext db) =>
    await db.Discounts
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
        .ToListAsync());

app.MapPost("/api/discounts", async ([FromBody] Discount discount, ApplicationDbContext db) =>
{
    // Verify product exists
    var product = await db.Products.FindAsync(discount.ProductId);
    if (product == null)
    {
        return Results.NotFound("Product not found");
    }

    // Verify dates
    if (discount.BeginDate >= discount.EndDate)
    {
        return Results.BadRequest("End date must be after begin date");
    }

    db.Discounts.Add(discount);
    await db.SaveChangesAsync();
    return Results.Created($"/api/discounts/{discount.Id}", discount);
});

app.Run();

// DTOs
public class SaleCreateDto
{
    public int ProductId { get; set; }
    public int SalespersonId { get; set; }
    public int CustomerId { get; set; }
    public DateTime SalesDate { get; set; }
}
