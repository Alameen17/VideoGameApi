using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VideoGameApi.Data;

var builder = WebApplication.CreateBuilder(args);


// Add this line to see the connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"=== CONNECTION STRING: {connectionString} ===");

// Your existing DbContext registration
builder.Services.AddDbContext<VideoGameDbContext>(options =>
    options.UseSqlServer(connectionString));


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<VideoGameDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Map OpenAPI first
    app.MapOpenApi();

    // Map Scalar with explicit configuration
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();