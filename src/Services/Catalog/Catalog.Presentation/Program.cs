using Catalog.Application;
using Catalog.Domain.Entities;
using Catalog.Infrastructure;
using Catalog.Infrastructure.Data.Seeders;
using Catalog.Presentation;
using Catalog.Presentation.Common.Middleware;
using Hangfire;
using Hangfire.Dashboard;
using MassTransit;
using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Driver;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPresentationServices(builder.Configuration);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHangfireDashboard(options: new DashboardOptions()
    {
        Authorization = new[] { new DashboardNoAuthorizationFilter() }
    });
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
}

app.Run();

