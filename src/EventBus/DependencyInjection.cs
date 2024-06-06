using EventBus.Bus;
using EventBus.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EventBus;

public static class DependencyInjection
{
    private static readonly string host = "localhost";
    public static IServiceCollection AddRabbitMqBus(this IServiceCollection services)
    {
        services.AddTransient<IEventBus, RabbitMqBus>(sp =>
        {
            var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
            return new RabbitMqBus(host, scopeFactory);
        });

        return services;
    }
}
