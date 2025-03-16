using Microsoft.EntityFrameworkCore;
using server.Infrastructure.Data;
using server.Infrastructure.Middleware;

namespace server.Common.Extensions;

public static class ApplicationExtensions
{
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseResponseCompression();
            app.UseSecurityHeaders();
        }

        app.UseHttpsRedirection();
        app.UseResponseCaching();

        // CORS must be before routing
        app.UseCors("AllowReactApp");

        app.UseRouting();

        return app;
    }

    public static WebApplication ConfigureApiEndpoints(this WebApplication app)
    {
        app.MapControllers();
        return app;
    }

    public static WebApplication InitializeDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
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

        return app;
    }
}