using Catalog.Application.Services;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using Catalog.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connecitonString = configuration["CatalogStoreDatabase:ConnectionString"];
        var dbName = configuration["CatalogStoreDatabase:DatabaseName"];

        var client = new MongoClient(connecitonString);

        services.AddSingleton(client.GetDatabase(dbName).GetCollection<Product>(configuration["CatalogStoreDatabase:ProductCollectionName"]));
        services.AddSingleton(client.GetDatabase(dbName).GetCollection<Category>(configuration["CatalogStoreDatabase:CategoryCollectionName"]));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepostitory, ProductRepository>();
        services.AddScoped<IImageService, ImageService>();

        return services;
    }
}
