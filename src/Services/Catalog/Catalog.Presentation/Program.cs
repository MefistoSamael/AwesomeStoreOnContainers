using Catalog.Application;
using Catalog.Domain.Entities;
using Catalog.Infrastructure;
using Catalog.Infrastructure.Data.Seeders;
using Catalog.Presentation;
using Catalog.Presentation.Common.Middleware;
using Hangfire;
using EventBus.Infrastructure;
using MongoDB.Driver;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPresentationServices(builder.Configuration);
builder.Services.AddRabbitMqBus();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseHangfireDashboard();

using (var scope = app.Services.CreateScope())
{
    var categories = scope.ServiceProvider.GetService<IMongoCollection<Category>>();
    var products = scope.ServiceProvider.GetService<IMongoCollection<Product>>();
    
    CategoriesSeeder.SeedCategories(categories!);
}

app.Run();

