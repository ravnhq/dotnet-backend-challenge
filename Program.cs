using System.Data;
using BackendChallenge.Infrastructure.Database;
using BackendChallenge.Middlewares;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
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

builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = (context) =>
    {
        // Ensure all responses have problem details format
        if (context.ProblemDetails.Status == 404 && string.IsNullOrEmpty(context.ProblemDetails.Title))
        {
            context.ProblemDetails.Title = "Not Found";
            context.ProblemDetails.Detail = "The requested resource was not found.";
        }
    };
});
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.ClientErrorMapping[404].Link = "https://httpstatuses.com/404";
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

app.UseExceptionHandler();
app.UseStatusCodePages();
app.UseHttpsRedirection();
app.MapControllers();

var dbContextFactory = app.Services.GetRequiredService<IDbContextFactory<AppDbContext>>();
using (var context = dbContextFactory.CreateDbContext())
{
    await DbSeeder.SeedAndCreateDbAsync(context);
}

app.Run();

public record AddStudentDto(string FirstName, string LastName, string Phone);

public class AddStudentDtoValidator : AbstractValidator<AddStudentDto>
{
    public AddStudentDtoValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(20);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Phone).MaximumLength(10);
    }
}