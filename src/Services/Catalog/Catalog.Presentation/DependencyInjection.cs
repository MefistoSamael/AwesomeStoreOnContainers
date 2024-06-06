﻿using Catalog.Application.Common.Behaviours;
using Catalog.Application.Common.Jobs;
using Catalog.Presentation.Common.OptionsSetup;
using Catalog.Presentation.Common.Swagger;
using CronEspresso.NETCore;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Reflection;

namespace Catalog.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.ConfigureOptions();

        services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(
                                         new SlugifyParameterTransformer()));
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IUpdateStockCountJob, UpdateStockCountJob>();
        
        services.ConfigureHangfire(configuration);

        return services;
    }

    public static IServiceCollection ConfigureOptions(this IServiceCollection services)
    {
        // KEEP launchSettings.json and applicatoinSettings.json in SYNC
        services.ConfigureOptions<WWWRootOptionsSetup>();
        services.ConfigureOptions<ProductPaginationOptionsSetup>();
        services.ConfigureOptions<CategoryPaginationOptionsSetup>();
        services.ConfigureOptions<StockCountUpdationOptionsSetup>();

        return services;
    }

    public static IServiceCollection ConfigureHangfire(this IServiceCollection services, IConfiguration configuration)
    {
        var restoskPeriod = Convert.ToInt32(configuration["StockCountUpdationOptions:RestockPeriod"]);

        var client = services.BuildServiceProvider().GetService<IRecurringJobManager>();
        client.AddOrUpdate<IUpdateStockCountJob>("StockCountUpdationJob",
        job => job.Execute(),
        "* * * * *");

        return services;
    }
}

