using Catalog.Application.Common.Behaviours;
using Catalog.Presentation.Common.OptionsSetup;
using Catalog.Presentation.Common.Swagger;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Reflection;

namespace Catalog.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
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

        return services;
    }

    public static IServiceCollection ConfigureOptions(this IServiceCollection services)
    {
        // KEEP launchSettings.json and applicatoinSettings.json in SYNC
        services.ConfigureOptions<WWWRootOptionsSetup>();
        services.ConfigureOptions<ProductPaginationOptionsSetup>();
        services.ConfigureOptions<CategoryPaginationOptionsSetup>();

        return services;
    }
}

