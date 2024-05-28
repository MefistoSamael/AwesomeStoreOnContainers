using Catalog.Application;
using Catalog.Domain.Entities;
using Catalog.Infrastructure;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Data.Seeders;
using Catalog.Presentation;
using Catalog.Presentation.Common.Middleware;
using MongoDB.Driver;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPresentationServices();

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

using (var scope = app.Services.CreateScope())
{
    var categories = scope.ServiceProvider.GetService<IMongoCollection<Category>>();
    var products = scope.ServiceProvider.GetService<IMongoCollection<Product>>();
    
    CategoriesSeeder.SeedCategories(categories!);
    //ProductsSeeder.SeedProducts(products!);
}

app.Run();

