using Catalog.Application.Common.Behaviours;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //services.AddMassTransit(busConfigurator =>
        //{
        //    busConfigurator.SetKebabCaseEndpointNameFormatter();

        //    busConfigurator.UsingRabbitMq();
        //});

        return services;
    }
}
