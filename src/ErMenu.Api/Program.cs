using ErMenu.Api.DependencyInjection;
using ErMenu.Application;
using ErMenu.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiDependencies(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// OpenAPI
app.MapOpenApi(); //https://localhost:7013/openapi/v1.json



app.UseApiPipeline();


app.Run();

