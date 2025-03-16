using server.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

app.ConfigureMiddleware();
app.ConfigureApiEndpoints();
app.InitializeDatabase();

app.Run();
