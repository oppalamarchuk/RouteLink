using DotNetEnv;
using RouteLink.Application;
using RouteLink.Infrastructure;

Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddApplication(); 
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/api/health", () => Results.Ok(new
{
    Status = "Healthy",
    Service = "RouteLink.Api",
    UtcNow = DateTime.UtcNow
}));

app.Run();
