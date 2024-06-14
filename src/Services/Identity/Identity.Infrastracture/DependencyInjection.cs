using Identity.Application.Providers;
using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Entities;
using Identity.Infrastracture.Authentication;
using Identity.Infrastracture.Data;
using Identity.Infrastracture.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastracture;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IRefreshTokenProvider, RefreshTokenProvider>();

        services.AddAuthentication().AddJwtBearer();

        return services;
    }
}
