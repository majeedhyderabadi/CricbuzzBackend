using MatchApi.Api.Endpoints;
using MatchApi.Application;
using MatchApi.Infrastructure;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OpenApi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Layer registrations (Clean Architecture composition root)
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();


// Configure Swagger/OpenAPI


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MatchApi",
        Version = "v1",
        Description = "Clean Architecture minimal API for managing fixtures."
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Enable Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MatchApi v1");
        options.RoutePrefix = "swagger"; // UI served at /swagger
    });
}


app.UseHttpsRedirection();

app.MapFixtureEndpoints();

app.MapGet("/", () => Results.Ok(new { service = "MatchApi", status = "running" }))
    .ExcludeFromDescription();

app.Run();

// Exposed for WebApplicationFactory-based integration tests
public partial class Program { }

