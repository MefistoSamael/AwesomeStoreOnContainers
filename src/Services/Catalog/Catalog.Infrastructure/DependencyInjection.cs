using Catalog.Application.Services;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Repositories;
using Catalog.Infrastructure.Services;
using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connecitonString = configuration["CatalogStoreDatabase:ConnectionString"];
        var productsDbName = configuration["CatalogStoreDatabase:DatabaseName"];
        var hangfireDbName = "Jobs";

        var client = new MongoClient(connecitonString);

        services.AddSingleton(client.GetDatabase(productsDbName).GetCollection<Product>(configuration["CatalogStoreDatabase:ProductCollectionName"]));
        services.AddSingleton(client.GetDatabase(productsDbName).GetCollection<Category>(configuration["CatalogStoreDatabase:CategoryCollectionName"]));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepostitory, ProductRepository>();
        services.AddScoped<IImageService, ImageService>();

        services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseMongoStorage(client, hangfireDbName, new MongoStorageOptions
        {
            MigrationOptions = new MongoMigrationOptions
            {
                MigrationStrategy = new MigrateMongoMigrationStrategy(),
                BackupStrategy = new CollectionMongoBackupStrategy()
            },
            Prefix = "hangfire.mongo",
            CheckConnection = true,
            CheckQueuedJobsStrategy = CheckQueuedJobsStrategy.TailNotificationsCollection
        })
        );

        // Add the processing server as IHostedService
        services.AddHangfireServer(serverOptions =>
        {
            serverOptions.ServerName = "Hangfire.Mongo server 1";
        });

        return services;
    }
}
