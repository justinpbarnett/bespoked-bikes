using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using server.Common.Interfaces;
using server.Features.Customers;
using server.Features.Dashboard;
using server.Features.Discounts;
using server.Features.Products;
using server.Features.Reports;
using server.Features.Sales;
using server.Features.Salespersons;
using server.Infrastructure.Data;

namespace server.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add MVC controllers
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        // Configure Swagger
        AddSwagger(builder);

        // Configure Database
        AddDatabase(builder);

        // Register repositories and services
        AddApplicationServices(builder);

        // Configure CORS
        AddCors(builder);

        // Configure Caching and Compression
        AddCachingAndCompression(builder);

        return builder;
    }

    private static void AddApplicationServices(WebApplicationBuilder builder)
    {
        // Register repositories
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Product services
        builder.Services.AddScoped<GetProductsQuery>();
        builder.Services.AddScoped<GetProductByIdQuery>();
        builder.Services.AddScoped<CreateProductCommand>();
        builder.Services.AddScoped<UpdateProductCommand>();

        // Customer services
        builder.Services.AddScoped<GetCustomersQuery>();
        builder.Services.AddScoped<GetCustomerByIdQuery>();
        builder.Services.AddScoped<CreateCustomerCommand>();

        // Salesperson services
        builder.Services.AddScoped<GetSalespersonsQuery>();
        builder.Services.AddScoped<GetSalespersonByIdQuery>();
        builder.Services.AddScoped<CreateSalespersonCommand>();
        builder.Services.AddScoped<UpdateSalespersonCommand>();

        // Sales services
        builder.Services.AddScoped<GetSalesQuery>();
        builder.Services.AddScoped<GetSaleDetailsQuery>();
        builder.Services.AddScoped<FilterSalesQuery>();
        builder.Services.AddScoped<CreateSaleCommand>();

        // Discount services
        builder.Services.AddScoped<GetDiscountsQuery>();
        builder.Services.AddScoped<GetDiscountByIdQuery>();
        builder.Services.AddScoped<GetActiveDiscountsForProductQuery>();
        builder.Services.AddScoped<GetGlobalDiscountsQuery>();
        builder.Services.AddScoped<CreateDiscountCommand>();
        builder.Services.AddScoped<UpdateDiscountCommand>();
        builder.Services.AddScoped<DeleteDiscountCommand>();

        // Dashboard services
        builder.Services.AddScoped<GetDashboardSummaryQuery>();
        builder.Services.AddScoped<GetRecentSalesQuery>();
        builder.Services.AddScoped<GetMonthlySalesQuery>();
        builder.Services.AddScoped<GetTopSalespersonsQuery>();
        builder.Services.AddScoped<GetInventoryAlertsQuery>();
        builder.Services.AddScoped<GetProductPerformanceQuery>();
        
        // Reports services
        builder.Services.AddScoped<GetCommissionReportQuery>();
    }

    private static void AddSwagger(WebApplicationBuilder builder)
    {
        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BeSpoked Bikes API", Version = "v1" });
            });
        }
    }

    private static void AddDatabase(WebApplicationBuilder builder)
    {
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
            ?? builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                sqlOptions.CommandTimeout(30);
            });

            if (!builder.Environment.IsDevelopment())
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        });
    }

    private static void AddCors(WebApplicationBuilder builder)
    {
        var corsOrigins = Environment.GetEnvironmentVariable("CORS_ORIGINS")?.Split(',')
            ?? Array.Empty<string>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowReactApp", policy =>
            {
                policy.SetIsOriginAllowed(origin =>
                {
                    if (string.IsNullOrEmpty(origin)) return false;
                    var uri = new Uri(origin);
                    return corsOrigins.Any(x =>
                        x.Equals(uri.ToString(), StringComparison.OrdinalIgnoreCase) ||
                        x.Equals(uri.Scheme + "://" + uri.Host + ":" + uri.Port, StringComparison.OrdinalIgnoreCase));
                })
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });
        });
    }

    private static void AddCachingAndCompression(WebApplicationBuilder builder)
    {
        builder.Services.AddResponseCaching();

        if (!builder.Environment.IsDevelopment())
        {
            builder.Services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });
        }
    }
}