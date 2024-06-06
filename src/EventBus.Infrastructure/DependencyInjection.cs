using EventBus.Domain.Interfaces;
using EventBus.Infrastructure.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace EventBus.Infrastructure;

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
