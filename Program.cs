using BackendChallenge.Infrastructure.Database;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Backend Challenge API",
        Description = "Live coding backend challenge.",
    });
});

builder.Services.AddValidatorsFromAssemblyContaining<Program>();


builder.Services.AddDbContextFactory<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=app.db;");
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Enable Swagger middleware
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend Challenge API v1");
        options.RoutePrefix = "swagger";
        options.DocumentTitle = "Backend Challenge API Documentation";
    });
}

app.UseHttpsRedirection();
app.MapControllers();

var dbContextFactory = app.Services.GetRequiredService<IDbContextFactory<AppDbContext>>();
using (var context = dbContextFactory.CreateDbContext())
{
    await DbSeeder.SeedAndCreateDbAsync(context);
}

app.Run();