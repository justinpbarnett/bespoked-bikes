using server.Common.Extensions;
using server.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.ConfigureServices();

var app = builder.Build();

// Configure HTTP request pipeline
app.ConfigureMiddleware();

// Configure API endpoints
app.ConfigureApiEndpoints();

// Initialize database
app.InitializeDatabase();

app.Run();
