using Catalog.Application.Services;
using Catalog.Domain.Abstractions;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using Catalog.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connecitonString = configuration["CatalogStoreDatabase:ConnectionString"];
        var dbName = configuration["CatalogStoreDatabase:DatabaseName"];

        services.AddDbContext<ApplicationDbContext>(options => options.UseMongoDB(connecitonString!, dbName!));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepostitory, ProductRepository>();
        services.AddScoped<IImageService, ImageService>();

        return services;
    }
}
