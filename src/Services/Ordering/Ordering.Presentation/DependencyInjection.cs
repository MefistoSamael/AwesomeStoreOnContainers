using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Ordering.Presentation.Common.Swagger;
using System.Reflection;

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

        return services;
    }
}
