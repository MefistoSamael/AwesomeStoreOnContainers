using Catalog.Presentation.Common.OptionsSetup;
using Catalog.Presentation.Common.Swagger;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Catalog.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        // KEEP launchSettings.json and applicatoinSettings.json in SYNC
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.ConfigureOptions();

        services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(
                                         new SlugifyParameterTransformer()));
        });

        return services;
    }

    public static IServiceCollection ConfigureOptions(this IServiceCollection services)
    {
        services.ConfigureOptions<WWWRootOptionsSetup>();

        return services;
    }
}

