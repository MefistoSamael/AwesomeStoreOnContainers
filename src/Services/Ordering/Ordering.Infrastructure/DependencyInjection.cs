using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Services;
using Ordering.Domain.Repositories;
using Ordering.Infrastructure.Repositories.EntityRepository;
using Ordering.Infrastructure.Services;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IProductService, GRPCProductService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
