using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Ordering.Presentation.Common.OptionsSetup;
using Ordering.Presentation.Common.Swagger;

namespace Ordering.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(
                                         new SlugifyParameterTransformer()));
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.ConfigureOptions<GrpcConnectionOptionsSetup>();

        return services;
    }
}
